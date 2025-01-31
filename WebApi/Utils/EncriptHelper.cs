using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Utils
{
    public static class EncriptHelper
    {
        public static string ConvertToSHA256(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Convert.ToBase64String( sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str)));
            } 
        }
    }
}
