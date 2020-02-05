using System;

namespace Tch.VstsClient.Domain.Objects
{
   public class Commit
   {
      public string Id { get; set; }

      public string Author { get; set; }

      public DateTime Date { get; set; }

      public string Comment { get; set; }
   }
}