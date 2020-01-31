using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Interfaces
{
   public interface ICommitsService
   {
      Task<IEnumerable<Commit>> GetAllCommits(string projectName, string repositoryId);
   }
}