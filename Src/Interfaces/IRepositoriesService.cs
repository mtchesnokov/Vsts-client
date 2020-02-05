using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with DevOps repositories
   /// </summary>
   public interface IRepositoriesService
   {
      /// <summary>
      /// List all GIT repositories under selected project 
      /// </summary>
      Task<IEnumerable<Repository>> GetAllGitRepositories(string projectName);
   }
}