namespace Tch.VstsClient.Domain.Exceptions
{
   public class UnauthorizedException : VstsClientExceptionBase
   {
      public UnauthorizedException() : base("You do not have permission for the selected operation")
      {
      }
   }
}