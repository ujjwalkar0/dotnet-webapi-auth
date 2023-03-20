using System.Security.Cryptography;
using System.Text;

namespace Auth.Utils
{
    public static class Hashcode
    {
        // const int keySize = 32;
        // const int iterations = 350000;
        // static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string getHashCode(string password)
        {
            using var sha256 = SHA256.Create();
            var secretBytes = Encoding.UTF8.GetBytes(password);
            var secretHash = sha256.ComputeHash(secretBytes);
            return Convert.ToHexString(secretHash);

            // byte[] salt = RandomNumberGenerator.GetBytes(keySize);

            // var hash = Rfc2898DeriveBytes.Pbkdf2(
            //     Encoding.UTF8.GetBytes(password),
            //     salt,
            //     iterations,
            //     hashAlgorithm,
            //     keySize);

            // StringBuilder builder = new StringBuilder();
            // for (int i = 0; i < salt.Length; i++)
            // {
            //     builder.Append(salt[i].ToString("x2"));
            // }
            // return builder.ToString();
        }
    }
}