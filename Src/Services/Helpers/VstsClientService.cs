using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.Services.Helpers
{
   internal class VstsClientService : IVstsClientService
   {
      private readonly IHttpService _httpService;

      #region ctor

      internal VstsClientService(IHttpService httpService)
      {
         _httpService = httpService;
      }

      public VstsClientService(ClientSettings clientSettings) : this(new HttpService(clientSettings))
      {
      }

      #endregion

      public async Task<TObject> Get<TObject>(string relativeUrl, string baseUrl)
      {
         var httpResponseDto = await _httpService.Get(relativeUrl, baseUrl);

         var statusCode = httpResponseDto.StatusCode;

         if (statusCode == HttpStatusCode.OK)
         {
            return JsonConvert.DeserializeObject<TObject>(httpResponseDto.Body);
         }

         var error = JsonConvert.DeserializeObject<Error>(httpResponseDto.Body);

         if (statusCode == HttpStatusCode.NotFound)
         {
            throw new NotFoundStatusCodeException {Error = error};
         }

         if (statusCode == HttpStatusCode.Unauthorized)
         {
            throw new UnauthorizedException();
         }

         throw new BadStatusCodeReturned {StatusCode = statusCode, Error = error};
      }
   }
}