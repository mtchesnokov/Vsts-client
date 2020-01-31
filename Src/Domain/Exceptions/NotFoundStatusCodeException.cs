using System;
using System.Net;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Domain.Exceptions
{
   public class NotFoundStatusCodeException : Exception
   {
      public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

      public Error Error { get; set; }

      public NotFoundStatusCodeException() : base("External service returned 404 status code")
      {
      }
   }
}