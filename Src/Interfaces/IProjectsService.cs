using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with DevOps Projects
   /// </summary>
   public interface IProjectsService
   {
      /// <summary>
      /// List all projects in your organization
      /// </summary>
      Task<IEnumerable<Project>> GetAllProjects();
   }
}