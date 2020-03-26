using System.Threading.Tasks;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Domain.Helpers;
using Tch.VstsClient.Domain.Objects;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.UnitTests.Fakes
{
   internal class FakeHttpService2 : IHttpService
   {
      public Task<HttpResponseDto> Get(string relativeUrl, string baseUrl)
      {
         throw new BadStatusCodeReturned
         {
            Error = new Error
            {
               TypeKey = "ProjectDoesNotExistWithNameException"
            }
         };
      }
   }
}