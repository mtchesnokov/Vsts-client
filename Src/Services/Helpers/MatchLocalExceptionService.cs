using System;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.Services.Helpers
{
   internal class MatchLocalExceptionService : IMatchLocalExceptionService
   {
      public TTargetException TryMatch<TTargetException>(BadStatusCodeReturned originalException) 
         where TTargetException : Exception
      {
         return null;
      }
   }
}