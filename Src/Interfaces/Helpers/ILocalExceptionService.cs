using System;
using Tch.VstsClient.Domain.Exceptions;

namespace Tch.VstsClient.Interfaces.Helpers
{
   internal interface ILocalExceptionService
   {
      void TryMatch<TLocalException>(BadStatusCodeReturned originalException, object context = null) 
         where TLocalException : Exception;
   }
}