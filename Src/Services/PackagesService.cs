using System.Collections.Generic;
using System.Threading.Tasks;
using Mtch.VstsClient.Config;
using Mtch.VstsClient.Domain.Exceptions;
using Mtch.VstsClient.Domain.Objects;
using Mtch.VstsClient.Interfaces;
using Mtch.VstsClient.Interfaces.Helpers;
using Mtch.VstsClient.Services.Helpers;

namespace Mtch.VstsClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IFeedsService" />
   /// </summary>
   public class PackagesService : IPackagesService
   {
      private readonly IObjectHttpService _httpService;

      #region ctor

      public PackagesService(ClientSettings clientSettings) : this(new ObjectHttpService(clientSettings))
      {
      }

      internal PackagesService(IObjectHttpService httpService)
      {
         _httpService = httpService;
      }

      #endregion

      private class HttpResponse
      {
         public Package[] Value { get; set; }
      }

      public async Task<PackageVersionDetails> GetPackageVersionDetails(string feedName, string packageId, string packageVersion)
      {
         try
         {
            var response = await _httpService.Get<PackageVersionDetails>($"/_apis/packaging/feeds/{feedName}/packages/{packageId}/versions/{packageVersion}?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
            var packages = response;
            return packages;
         }
         catch (BadStatusCodeReturned)
         {
            throw new PackageNotFoundException {PackageId = packageId, VersionNumber = packageVersion, FeedName = feedName};
         }
         catch (NotFoundStatusCodeException e)
         {
            var errorType = e.Error.TypeKey;

            if (errorType.Contains("PackageVersionNotFound"))
            {
               throw new PackageNotFoundException {PackageId = packageId, VersionNumber = packageVersion, FeedName = feedName};
            }

            throw new FeedNotFoundException {FeedName = feedName};
         }
      }

      public async Task<IEnumerable<Package>> GetAllPackages(string feedName)
      {
         try
         {
            var response = await _httpService.Get<HttpResponse>($"/_apis/packaging/feeds/{feedName}/packages?api-version=5.1-preview.1", "https://feeds.dev.azure.com");
            var packages = response.Value;
            return packages;
         }
         catch (NotFoundStatusCodeException)
         {
            throw new FeedNotFoundException {FeedName = feedName};
         }
      }
   }
}