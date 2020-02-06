using System;
using Tch.VstsClient.Domain.Exceptions;

namespace Tch.VstsClient.Interfaces.Helpers
{
   internal interface IMatchLocalExceptionService
   {
      TTargetException TryMatch<TTargetException>(BadStatusCodeReturned originalException)
         where TTargetException : Exception;
   }
}