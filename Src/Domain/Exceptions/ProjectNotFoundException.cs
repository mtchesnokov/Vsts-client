namespace Tch.VstsClient.Domain.Exceptions
{
   public class ProjectNotFoundException : VstsClientExceptionBase
   {
      public string ProjectName { get; set; }

      public ProjectNotFoundException() : base("Requested project cannot be found")
      {
      }
   }
}