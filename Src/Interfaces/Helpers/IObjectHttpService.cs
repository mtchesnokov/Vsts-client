using System.Threading.Tasks;

namespace Mtch.VstsClient.Interfaces.Helpers
{
   /// <summary>
   /// This interface represents help service to simplify creating http requests to VSTS REST API
   /// </summary>
   internal interface IObjectHttpService
   {
      /// <summary>
      /// Get object from REST API
      /// </summary>
      /// <typeparam name="TObject"></typeparam>
      /// <param name="relativeUrl"></param>
      /// <param name="baseUrl"></param>
      /// <returns></returns>
      Task<TObject> Get<TObject>(string relativeUrl, string baseUrl = "https://dev.azure.com");
   }
}