using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Interfaces.Helpers;
using Mtch.VstsClient.Services.Helpers;

namespace Mtch.VstsClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IFeedsService" />
   /// </summary>
   public class FeedsService : IFeedsService
   {
      private readonly IObjectHttpService _httpService;

      #region ctor

      public FeedsService(ClientSettings clientSettings) : this(new ObjectHttpService(clientSettings))
      {
      }

      internal FeedsService(IObjectHttpService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Feed[] Value { get; set; }
      }

      public async Task<IEnumerable<Feed>> GetAllFeeds()
      {
         var response = await _httpService.Get<HttpResponse>("/_apis/packaging/feeds?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
         return response.Value;
      }
   }
}