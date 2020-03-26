using System.Net;

namespace Tch.VstsClient.Domain.Helpers
{
   /// <summary>
   /// This is help class that represents HTTP response from Dev Ops Api
   /// </summary>
   internal class HttpResponseDto
   {
      /// <summary>
      /// status code of HTTP response
      /// </summary>
      public HttpStatusCode StatusCode { get; set; }

      /// <summary>
      /// HTTP response body as text
      /// </summary>
      public string Body { get; set; }
   }
}