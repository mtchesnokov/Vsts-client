using System.Threading.Tasks;

namespace Tch.VstsClient.Interfaces.Helpers
{
   /// <summary>
   /// This interface represents help service to get data from DevOps REST Api
   /// </summary>
   internal interface IVstsClientService
   {
      /// <summary>
      /// Get object from DevOps REST Api
      /// </summary>
      /// <typeparam name="TObject"></typeparam>
      /// <param name="relativeUrl">Relative address of endpoint</param>
      /// <param name="baseUrl">Base address of REST Api</param>
      /// <returns></returns>
      Task<TObject> Get<TObject>(string relativeUrl, string baseUrl = "https://dev.azure.com");
   }
}