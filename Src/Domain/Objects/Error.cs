namespace Tch.VstsClient.Domain.Objects
{
   public class Error
   {
      public string ErrorCode { get; set; }

      public string Message { get; set; }

      public string TypeKey { get; set; }

      public string TypeName { get; set; }
   }
}