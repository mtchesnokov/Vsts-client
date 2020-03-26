using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tch.VstsClient.Config;
using Tch.VstsClient.Domain.Helpers;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.Services.Helpers
{
   /// <summary>
   /// Implementation of <see cref="IHttpService"/>
   /// </summary>
   internal class HttpService : IHttpService
   {
      private readonly ClientSettings _clientSettings;

      #region ctor

      public HttpService(ClientSettings clientSettings)
      {
         _clientSettings = clientSettings;
      }

      #endregion

      public async Task<HttpResponseDto> Get(string relativeUrl, string baseUrl)
      {
         using (var client = new HttpClient())
         {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var basicHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{_clientSettings.AccessToken}"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicHeader);

            using (var httpResponseMessage = await client.GetAsync($"{baseUrl}/{_clientSettings.OrganizationName}{relativeUrl}"))
            {
               var responseStatusCode = httpResponseMessage.StatusCode;
               var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

               return new HttpResponseDto {StatusCode = responseStatusCode, Body = responseBody};
            }
         }
      }
   }
}