using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Interfaces
{
   /// <summary>
   /// This interface represents service to work with VSTS feeds
   /// </summary>
   public interface IFeedsService
   {
      /// <summary>
      /// List all feeds under given project 
      /// </summary>
      /// <returns></returns>
      Task<IEnumerable<Feed>> GetAllFeeds();
   }
}