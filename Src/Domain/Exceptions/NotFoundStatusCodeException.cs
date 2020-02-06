using System.Net;
using Tch.VstsClient.Domain.Objects;

namespace Tch.VstsClient.Domain.Exceptions
{
   public class NotFoundStatusCodeException : VstsClientExceptionBase
   {
      public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

      public Error Error { get; set; }

      public NotFoundStatusCodeException() : base("External service returned 404 status code")
      {
      }
   }
}