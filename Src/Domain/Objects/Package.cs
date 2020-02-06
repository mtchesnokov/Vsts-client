using System;

namespace Tch.VstsClient.Domain.Objects
{
   /// <summary>
   ///    This class represents VSTS Nuget package
   /// </summary>
   public class Package
   {
      public string Id { get; set; }

      public string Name { get; set; }
   }

   public class PackageVersion
   {
      public string Id { get; set; }

      public string Version { get; set; }

      public DateTime PublishDate { get; set; }

      public PackageDependency[] Dependencies { get; set; }
   }

   public class PackageDependency
   {
      public string PackageName { get; set; }

      public string VersionRange { get; set; }
   }
}