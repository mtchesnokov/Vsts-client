using System;

namespace Tch.VstsClient.Domain.Exceptions
{
   public class UnauthorizedException : Exception
   {
      public UnauthorizedException() : base("You do not have permission for the selected operation")
      {
      }
   }
}