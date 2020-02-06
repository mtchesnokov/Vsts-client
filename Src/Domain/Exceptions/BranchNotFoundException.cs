namespace Tch.VstsClient.Domain.Exceptions
{
   public class BranchNotFoundException : VstsClientExceptionBase
   {
      public string ProjectName { get; set; }

      public string RepositoryId { get; set; }

      public string BranchName { get; set; }

      public BranchNotFoundException() : base("Requested repository cannot be found")
      {
      }
   }
}