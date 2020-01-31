using System;
using System.Configuration;
using Mtch.VstsClient.Config;
using NUnit.Framework;
using StructureMap;

namespace Mtch.VstsClient.IntTests
{
   [TestFixture]
   [Category("IntegrationTest")]
   public abstract class IntegrationTestBase
   {
      public IContainer Container { get; set; }

      public ClientSettings ClientSettings => new ClientSettings
      {
         AccessToken = ConfigurationManager.AppSettings["accessToken"],
         OrganizationName = ConfigurationManager.AppSettings["organizationName"]
      };

      [OneTimeSetUp]
      public void OneTimeSetup()
      {
         Container = new Container(cfg => cfg.Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.StartsWith("Mtch."));
            s.RegisterConcreteTypesAgainstTheFirstInterface();
         }));
      }
   }

   public abstract class IntegrationTestBase<TSUT> : IntegrationTestBase
   {
      public Func<TSUT> SUT => () => Container.With(ClientSettings).GetInstance<TSUT>();
   }
}