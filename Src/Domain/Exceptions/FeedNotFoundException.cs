namespace Tch.VstsClient.Domain.Exceptions
{
   public class FeedNotFoundException : VstsClientExceptionBase
   {
      public string FeedName { get; set; }

      public FeedNotFoundException() : base("Requested feed cannot be found")
      {
      }
   }
}