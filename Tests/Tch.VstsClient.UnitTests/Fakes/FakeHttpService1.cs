using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tch.VstsClient.Domain.Helpers;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.UnitTests.Fakes
{
   internal class FakeHttpService1 : IHttpService
   {
      public object ResponseModel { get; set; }

      public Task<HttpResponseDto> Get(string relativeUrl, string baseUrl)
      {
         var httpResponseDto = new HttpResponseDto
         {
            StatusCode = HttpStatusCode.OK,
            Body = JsonConvert.SerializeObject(new {Value = ResponseModel})
         };

         return Task.FromResult(httpResponseDto);
      }
   }
}