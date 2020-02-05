using System;

namespace Tch.VstsClient.Domain.Objects
{
   /// <summary>
   ///    This class represents VSTS Build
   /// </summary>
   public class Build
   {
      public string BuildNumber { get; set; }

      public BuildDefinition Definition { get; set; }

      public DateTime StartTime { get; set; }

      public DateTime FinishTime { get; set; }

      public RequestedBy RequestedBy { get; set; }

      public string Result { get; set; }

      public string SourceBranch { get; set; }

      public string SourceVersion { get; set; }

      public Repository Repository { get; set; }
   }

   public class RequestedBy
   {
      public string DisplayName { get; set; }
   }
}