using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   ///    This interface represents service to work with DevOps repositories
   /// </summary>
   public interface IRepositoriesService
   {
      /// <summary>
      ///    List all GIT repositories under selected project
      /// </summary>
      /// <exception cref="ProjectNotFoundException"></exception>
      Task<IEnumerable<Repository>> GetAllGitRepositories(string projectName);

      /// <summary>
      ///    List all branches in selected repository
      /// </summary>
      /// <param name="projectName"></param>
      /// <param name="repositoryId"></param>
      /// <returns></returns>
      /// <exception cref="ProjectNotFoundException"></exception>
      /// <exception cref="RepositoryNotFoundException"></exception>
      Task<IEnumerable<Branch>> GetAllBranches(string projectName, string repositoryId);

      /// <summary>
      ///    Get all comments
      /// </summary>
      /// <param name="projectName">Project name</param>
      /// <param name="repositoryId">Repository name</param>
      /// <param name="branchName"></param>
      /// <param name="top"></param>
      /// <returns></returns>
      /// <exception cref="ProjectNotFoundException"></exception>
      /// <exception cref="RepositoryNotFoundException"></exception>
      /// <exception cref="BranchNotFoundException"></exception>
      Task<IEnumerable<Commit>> GetAllCommits(string projectName, string repositoryId, string branchName, int top = 1000);
   }
}