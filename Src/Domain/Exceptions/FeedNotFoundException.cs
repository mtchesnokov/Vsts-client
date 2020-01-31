using System;

namespace Mtch.VstsClient.Domain.Exceptions
{
   public class FeedNotFoundException : Exception
   {
      public string FeedName { get; set; }

      public FeedNotFoundException() : base("Requested feed cannot be found")
      {
      }
   }
}