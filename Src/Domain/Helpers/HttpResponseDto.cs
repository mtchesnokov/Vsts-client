using System.Net;

namespace Mtch.VstsClient.Domain.Helpers
{
   internal class HttpResponseDto
   {
      public HttpStatusCode StatusCode { get; set; }

      public string Body { get; set; }
   }
}