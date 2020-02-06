using System;

namespace Tch.VstsClient.Domain.Exceptions
{
   public abstract class VstsClientExceptionBase : Exception
   {
      protected VstsClientExceptionBase(string message) : base(message)
      {
      }
   }
}