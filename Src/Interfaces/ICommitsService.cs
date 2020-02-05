using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   public interface ICommitsService
   {
      Task<IEnumerable<Commit>> GetAllCommits(string projectName, string repositoryId);
   }
}