using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   ///    This interface represents service to work with DevOps builds
   /// </summary>
   public interface IBuildsService
   {
      /// <summary>
      ///    Get all builds for given project name and (optionally build definition name)
      /// </summary>
      /// <param name="projectName">Project name</param>
      /// <param name="buildDefinitionName">Build definition name</param>
      Task<IEnumerable<Build>> GetAllBuilds(string projectName, string buildDefinitionName = null);
   }
}