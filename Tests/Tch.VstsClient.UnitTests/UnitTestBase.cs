using NUnit.Framework;
using StructureMap;

namespace Tch.VstsClient.UnitTests
{
   [TestFixture]
   public abstract class UnitTestBase
   {
      private IContainer GlobalContainer { get; set; }

      public IContainer Container { get; set; }

      [OneTimeSetUp]
      public void OneTimeSetup()
      {
         GlobalContainer = new Container(cfg => cfg.AddRegistry<MasterRegistry>());
      }

      [SetUp]
      public void SetUp()
      {
         Container = GlobalContainer.GetNestedContainer();
      }

      [TearDown]
      public void TearDown()
      {
         Container?.Dispose();
      }
   }
}