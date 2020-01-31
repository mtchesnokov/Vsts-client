using System.Net;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces.Helpers;
using Newtonsoft.Json;

namespace Mtch.VstsClient.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IObjectHttpService" />
   /// </summary>
   internal class ObjectHttpService : IObjectHttpService
   {
      private readonly IHttpService _httpService;

      #region ctor

      internal ObjectHttpService(IHttpService httpService)
      {
         _httpService = httpService;
      }

      public ObjectHttpService(ClientSettings clientSettings) : this(new HttpService(clientSettings))
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

         throw new BadStatusCodeReturned {StatusCode = statusCode, Error = error};
      }
   }
}