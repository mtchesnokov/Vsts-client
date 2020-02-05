using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces;
using Tch.VstsClient.Interfaces.Helpers;
using Tch.VstsClient.Services.Helpers;

namespace Tch.VstsClient.Services
{
   public class NugetFeedsService : INugetFeedsService
   {
      private readonly IVstsClientService _httpService;

      #region ctor

      public NugetFeedsService(ClientSettings clientSettings) : this(new VstsClientService(clientSettings))
      {
      }

      internal NugetFeedsService(IVstsClientService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public NugetFeed[] Value { get; set; }
      }

      public async Task<IEnumerable<NugetFeed>> GetAllFeeds()
      {
         var response = await _httpService.Get<HttpResponse>("/_apis/packaging/feeds?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
         return response.Value;
      }
   }
}