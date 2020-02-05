using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   ///    This interface represents service to work with DevOps build definitions
   /// </summary>
   public interface IBuildDefinitionsService
   {
      /// <summary>
      ///    Get all build definitions for given project
      /// </summary>
      /// <param name="projectName">Project name</param>
      Task<IEnumerable<BuildDefinition>> GetAllBuildDefinitions(string projectName);
   }
}