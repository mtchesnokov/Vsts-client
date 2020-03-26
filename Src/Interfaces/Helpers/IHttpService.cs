using System.Threading.Tasks;
using Tch.VstsClient.Domain.Helpers;

namespace Tch.VstsClient.Interfaces.Helpers
{
   /// <summary>
   /// This interface represents help service to issue http requests to Dev Ops REST Api
   /// </summary>
   internal interface IHttpService
   {
      /// <summary>
      /// Send http GET request and parse response
      /// </summary>
      /// <param name="relativeUrl">Relative address of endpoint</param>
      /// <param name="baseUrl">Base url of Dev Ops REST Api</param>
      /// <returns></returns>
      Task<HttpResponseDto> Get(string relativeUrl, string baseUrl);
   }
}