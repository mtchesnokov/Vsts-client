using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class PackagesService : IPackagesService
   {
      private readonly IVstsClientService _httpService;
      private readonly ILocalExceptionService _localExceptionService;

      #region ctor

      public PackagesService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings), new LocalExceptionService())
      {
      }

      internal PackagesService(IVstsClientService httpService, ILocalExceptionService localExceptionService)
      {
         _localExceptionService = localExceptionService;
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse1
      {
         public Package[] Value { get; set; }
      }

      private class HttpResponse2
      {
         public PackageFeed[] Value { get; set; }
      }

      private class HttpResponse3
      {
         public PackageVersion[] Value { get; set; }
      }

      public async Task<IEnumerable<PackageFeed>> GetAllFeeds()
      {
         var response = await _httpService.Get<HttpResponse2>("/_apis/packaging/feeds?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
         return response.Value;
      }

      public async Task<IEnumerable<Package>> GetAllPackages(string feedName)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse1>($"/_apis/packaging/feeds/{feedName}/packages?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
            return response.Value;
         }
         catch (BadStatusCodeReturned e)
         {
            _localExceptionService.TryMatch<FeedNotFoundException>(e, new {feedName});
            throw;
         }
      }

      public async Task<IEnumerable<PackageVersion>> GetAllPackageVersions(string feedName, string packageId)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse3>($"/_apis/packaging/feeds/{feedName}/packages/{packageId}/versions", "https://feeds.dev.azure.com");
            return response.Value;
         }
         catch (BadStatusCodeReturned e)
         {
            _localExceptionService.TryMatch<PackageNotFoundException>(e, new {feedName, packageId});
            _localExceptionService.TryMatch<FeedNotFoundException>(e, new {feedName});
            throw;
         }
      }
   }
}