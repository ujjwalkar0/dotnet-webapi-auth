using System.Security.Cryptography;
using System.Text;

namespace Auth.Utils
{
    public static class Hashcode
    {
        public delegate string HashCode(string password);
        public static HashCode getHashCode = new HashCode(Getsha256Hash);

        public static string Getsha256Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var secretBytes = Encoding.UTF8.GetBytes(password);
            var secretHash = sha256.ComputeHash(secretBytes);
            return Convert.ToHexString(secretHash);
        }
    }
}