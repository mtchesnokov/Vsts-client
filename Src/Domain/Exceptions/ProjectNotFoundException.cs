using System;

namespace Tch.VstsClient.Domain.Exceptions
{
   public class ProjectNotFoundException : Exception
   {
      public string ProjectName { get; set; }

      public ProjectNotFoundException() : base("Requested project cannot be found")
      {
      }
   }
}