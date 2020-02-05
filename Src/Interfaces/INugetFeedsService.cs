using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with DevOps Nuget feeds
   /// </summary>
   public interface INugetFeedsService
   {
      /// <summary>
      /// List all nuget feeds
      /// </summary>
      /// <returns></returns>
      Task<IEnumerable<NugetFeed>> GetAllFeeds();
   }
}