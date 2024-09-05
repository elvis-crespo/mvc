using System.Security.Cryptography;
using System.Text;

namespace ProjectLogin.Resources
{
    public class Utilities
    {
        public static string EncriptarClave(string clave)
        {
            //string cifrar = clave;

            //byte[] cifrarBytes = Encoding.UTF8.GetBytes(cifrar);

            //byte[] hashValue = SHA256.HashData(cifrarBytes);

            //return Convert.ToHexString(hashValue).ToString();

            StringBuilder sb = new StringBuilder();

            //hash
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(clave));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
