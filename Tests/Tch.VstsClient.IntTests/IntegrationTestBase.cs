using System;
using NUnit.Framework;
using StructureMap;
using Tch.VstsClient.Config;

namespace Tch.VstsClient.IntTests
{
   [TestFixture]
   [Category("IntegrationTest")]
   public abstract class IntegrationTestBase
   {
      public IContainer Container { get; set; }

      public ClientSettings ClientSettings => new ClientSettings
      {
         AccessToken = OwnConfigurationManager.GetAppSetting("accessToken"),
         OrganizationName = OwnConfigurationManager.GetAppSetting("organizationName")
      };

      [OneTimeSetUp]
      public void OneTimeSetup()
      {
         Container = new Container(cfg => cfg.Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.StartsWith("Tch."));
            s.RegisterConcreteTypesAgainstTheFirstInterface();
         }));
      }
   }

   public abstract class IntegrationTestBase<TSUT> : IntegrationTestBase
   {
      public Func<TSUT> SUT => () => Container.With(ClientSettings).GetInstance<TSUT>();
   }
}