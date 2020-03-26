namespace Tch.VstsClient.UnitTests.TestExtensions
{
   public static class OverwriteServiceExtension
   {
      public static TService Overwrite<TInterface, TService>(this UnitTestBase test)
         where TService : TInterface, new()
      {
         var instance = new TService();
         test.Container.Inject(typeof(TInterface), instance);
         return instance;
      }
   }
}