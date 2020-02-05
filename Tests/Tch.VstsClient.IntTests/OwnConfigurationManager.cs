using System.Configuration;
using System.IO;
using System.Linq;

namespace Tch.VstsClient.IntTests
{
   internal static class OwnConfigurationManager
   {
      public static string GetAppSetting(string appSettingName)
      {
         var allKeys = ConfigurationManager.AppSettings.AllKeys;

         var allValues = allKeys.Select(k => ConfigurationManager.AppSettings[k]);

         if (!allValues.All(string.IsNullOrEmpty))
         {
            return ConfigurationManager.AppSettings[appSettingName];
         }

         var path = "/GitHub/VstsClient.app.config";
         var directory = Path.GetDirectoryName(path);
         var file = Path.GetFileName(path);

         var exeConfigFilename = Path.Combine(Path.GetFullPath(directory + "\\" + file));

         var fileMap = new ExeConfigurationFileMap
         {
            ExeConfigFilename = exeConfigFilename
         };

         var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
         var keyValueConfigurationElement = configuration.AppSettings.Settings[appSettingName];
         return keyValueConfigurationElement.Value;
      }
   }
}