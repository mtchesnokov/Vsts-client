using System;
using System.Net;
using Mtch.VstsClient.Domain.Objects;

namespace Mtch.VstsClient.Domain.Exceptions
{
   public class BadStatusCodeReturned : Exception
   {
      public HttpStatusCode StatusCode { get; set; }

      public Error Error { get; set; }

      public BadStatusCodeReturned() : base("Requested project cannot be found")
      {
      }
   }
}