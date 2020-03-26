using System.Net;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Domain.Exceptions
{
   public class BadStatusCodeReturned : VstsClientExceptionBase
   {
      public HttpStatusCode StatusCode { get; set; }

      public Error Error { get; set; }

      public string ResponseBody { get; set; }

      public BadStatusCodeReturned() : base("External service has returned error status code")
      {
      }
   }
}