using System;

namespace Tch.VstsClient.Domain.Objects
{
   /// <summary>
   /// This class represents DevOps commit
   /// </summary>
   public class Commit
   {
      public string Id { get; set; }

      public string Author { get; set; }

      public DateTime Date { get; set; }

      public string Comment { get; set; }
   }
}