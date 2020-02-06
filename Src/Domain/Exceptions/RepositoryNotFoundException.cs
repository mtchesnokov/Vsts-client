namespace Tch.VstsClient.Domain.Exceptions
{
   public class RepositoryNotFoundException : VstsClientExceptionBase
   {
      public string ProjectName { get; set; }

      public string RepositoryId { get; set; }

      public RepositoryNotFoundException() : base("Requested repository cannot be found")
      {
      }
   }
}