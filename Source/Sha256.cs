using System.Security.Cryptography;
using System.Text;

namespace FMT.Hash
{
    /// <summary>
    /// Sha256 32bit (uint) implementation of Frostbite Hashing used extensively during its TypeInfo/FieldInfo hash stage
    /// </summary>
    public static class Sha256
    {
        /// <summary>
        public static uint SHA256Hash32_Lowercase(string strVal, string strSeed = "5381")
        {
            string combined = (strVal + strSeed).ToLowerInvariant();
            byte[] data = Encoding.UTF8.GetBytes(combined);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(data);

                // Grab last 4 bytes as big-endian UInt32
                return ((uint)hash[28] << 24) | ((uint)hash[29] << 16) | ((uint)hash[30] << 8) | hash[31];
            }
        }

    }
}
