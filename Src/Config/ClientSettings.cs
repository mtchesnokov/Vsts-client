using System;

namespace Tch.VstsClient.Config
{
   /// <summary>
   ///    This class represents credentials needed to be able to connect to DevOps REST Api
   /// </summary>
   public class ClientSettings
   {
      /// <summary>
      ///    Access token
      /// </summary>
      public string AccessToken { get; }

      /// <summary>
      ///    Organization name
      /// </summary>
      public string OrganizationName { get; }

      #region ctor

      public ClientSettings(string organizationName, string accessToken)
      {
         if (string.IsNullOrEmpty(organizationName))
         {
            throw new ArgumentNullException(nameof(organizationName));
         }

         if (string.IsNullOrEmpty(accessToken))
         {
            throw new ArgumentNullException(nameof(accessToken));
         }

         OrganizationName = organizationName;
         AccessToken = accessToken;
      }

      #endregion
   }
}