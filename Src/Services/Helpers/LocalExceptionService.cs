using System;
using System.Collections.Generic;
using System.Reflection;
using Tch.VstsClient.Domain.Exceptions;
using Tch.VstsClient.Interfaces.Helpers;

namespace Tch.VstsClient.Services.Helpers
{
   internal class LocalExceptionService : ILocalExceptionService
   {
      private static readonly IDictionary<string, Type> _map = new Dictionary<string, Type>
      {
         {"ProjectDoesNotExistWithNameException", typeof(ProjectNotFoundException)},
         {"GitRepositoryNotFoundException", typeof(RepositoryNotFoundException)},
         {"FeedIdNotFoundException", typeof(FeedNotFoundException)},
         {"InvalidPackageIdException", typeof(PackageNotFoundException)},
         {"GitUnresolvableToCommitException", typeof(BranchNotFoundException)}
      };

      public void TryMatch<TTargetException>(BadStatusCodeReturned originalException, object context)
         where TTargetException : Exception
      {
         var externalExceptionType = originalException.Error.TypeKey;

         if (!_map.ContainsKey(externalExceptionType))
         {
            return;
         }

         var result = Activator.CreateInstance(_map[externalExceptionType]) as TTargetException;

         if (result == null)
         {
            return;
         }

         if (context != null)
         {
            AddContext(result, context);
         }

         throw result;
      }

      private static void AddContext(Exception result, object context)
      {
         var contextProps = context.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

         var exceptionProps = result.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

         foreach (var contextProp in contextProps)
         {
            foreach (var exceptionProp in exceptionProps)
            {
               if (string.Equals(contextProp.Name, exceptionProp.Name, StringComparison.InvariantCultureIgnoreCase))
               {
                  var value2set = contextProp.GetValue(context);
                  exceptionProp.SetValue(result, value2set);
               }
            }
         }
      }
   }
}