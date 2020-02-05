using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class CommitsService : ICommitsService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public CommitsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal CommitsService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public CommitDto[] Value { get; set; }
      }

      private class CommitDto
      {
         public string CommitId { get; set; }

         public string Comment { get; set; }

         public AuthorDto Author { get; set; }
      }

      private class AuthorDto
      {
         public string Name { get; set; }

         public DateTime Date { get; set; }
      }

      public async Task<IEnumerable<Commit>> GetAllCommits(string projectName, string repositoryId)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse>($"/{projectName}/_apis/git/repositories/{repositoryId}/commits?searchCriteria.$top=1000");

            return response.Value.Select(x => new Commit {Author = x.Author.Name, Date = x.Author.Date, Comment = x.Comment, Id = x.CommitId});
         }
         catch (NotFoundStatusCodeException e)
         {
            if (e.Error.TypeKey.Contains("ProjectDoesNotExist"))
            {
               throw new ProjectNotFoundException {ProjectName = projectName};
            }

            throw new RepositoryNotFoundException {RepositoryId = repositoryId, ProjectName = projectName};
         }
      }
   }
}