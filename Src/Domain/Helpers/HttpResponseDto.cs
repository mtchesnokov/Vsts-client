using System.Net;

namespace Tch.VstsClient.Domain.Helpers
{
   internal class HttpResponseDto
   {
      public HttpStatusCode StatusCode { get; set; }

      public string Body { get; set; }
   }
}