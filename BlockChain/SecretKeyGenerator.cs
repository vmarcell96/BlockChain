using System.Security.Cryptography;

namespace BlockChain
{
    public static class SecretKeyGenerator
    {
        public static byte[] GenerateSecretKey()
        {
            byte[] secretkey = new Byte[64];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // The array is now filled with cryptographically strong random bytes.
                rng.GetBytes(secretkey);

            }

            return secretkey;
        }
    }
}
