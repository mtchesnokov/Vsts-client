using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   ///    This interface represents service to work with DevOps Nuget feeds
   /// </summary>
   public interface IPackagesService
   {
      /// <summary>
      /// List all nuget feeds
      /// </summary>
      /// <returns></returns>
      Task<IEnumerable<PackageFeed>> GetAllFeeds();

      /// <summary>
      ///    List all feeds under given project
      /// </summary>
      /// <returns></returns>
      /// <exception cref="FeedNotFoundException"></exception>
      Task<IEnumerable<Package>> GetAllPackages(string feedName);

      /// <summary>
      ///    List all package versions
      /// </summary>
      /// <returns></returns>
      /// <exception cref="FeedNotFoundException"></exception>
      /// <exception cref="PackageNotFoundException"></exception>
      Task<IEnumerable<PackageVersion>> GetAllPackageVersions(string feedName, string packageId);
   }
}