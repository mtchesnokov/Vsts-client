using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with VSTS Projects
   /// </summary>
   public interface IProjectsService
   {
      /// <summary>
      /// List all projects
      /// </summary>
      /// <returns></returns>
      Task<IEnumerable<Project>> GetAllProjects();
   }
}