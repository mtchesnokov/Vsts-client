using System.Threading.Tasks;
using Mtch.VstsClient.Domain.Helpers;

namespace Mtch.VstsClient.Interfaces.Helpers
{
   internal interface IHttpService
   {
      Task<HttpResponseDto> Get(string relativeUrl, string baseUrl);
   }
}