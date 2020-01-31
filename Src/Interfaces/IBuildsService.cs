using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with VSTS builds
   /// </summary>
   public interface IBuildsService
   {
      /// <summary>
      /// Get all build definition names
      /// </summary>
      /// <param name="projectName">Project name</param>
      /// <returns></returns>
      Task<IEnumerable<string>> GetAllBuildDefinitionNames(string projectName);

      /// <summary>
      /// Get all builds for given project name and (build definition name)
      /// </summary>
      /// <param name="projectName">Project name</param>
      /// <param name="buildDefinitionName">Build definition name</param>
      /// <returns></returns>
      Task<IEnumerable<Build>> GetAllBuilds(string projectName, string buildDefinitionName = null);
   }
}