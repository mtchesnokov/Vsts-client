using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with VSTS GIT repositories
   /// </summary>
   public interface IRepositoriesService
   {
      /// <summary>
      /// List all GIT repositories under given project 
      /// </summary>
      /// <param name="projectName">Selected project name</param>
      /// <returns></returns>
      Task<IEnumerable<Repository>> GetAllRepositories(string projectName);
   }
}