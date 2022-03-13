using System.Security.Cryptography;
using System.Text;

namespace FeriaVirtual.API.Helpers
{
    public static class SecurePaswordHasher
    {
        public static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            byte[] hasBytes;

            hasBytes = SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hasBytes);
        }
    }
}
