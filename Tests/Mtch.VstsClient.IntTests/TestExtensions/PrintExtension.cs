using System;
using Newtonsoft.Json;

namespace Mtch.VstsClient.IntTests.TestExtensions
{
   /// <summary>
   /// Handy extension to print object to console
   /// </summary>
   public static class PrintExtension
   {
      public static void Print(this object obj)
      {
         Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}