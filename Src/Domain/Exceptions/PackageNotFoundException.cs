using System;

namespace Mtch.VstsClient.Domain.Exceptions
{
   public class PackageNotFoundException : Exception
   {
      public string FeedName { get; set; }

      public string PackageId { get; set; }

      public string VersionNumber { get; set; }

      public PackageNotFoundException() : base("Requested package cannot be found")
      {
      }
   }
}