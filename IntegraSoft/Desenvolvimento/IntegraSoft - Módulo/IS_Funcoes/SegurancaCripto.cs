using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IS_Funcoes
{
    public static class SegurancaCripto
    {
        private static string Chave
        {
            get
            {
                return "#VaiCorinthians";
            }
        }

        private static byte[] Salto
        {
            get
            {
                return new byte[] { 0x6e, 0x49, 0x61, 0x76, 0x20, 0x4d, 0x76, 0x65, 0x64, 0x65, 0x76, 0x65, 0x64 };
            }
        }

        public static string Criptografar(string texto)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(texto);

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes cripto = new Rfc2898DeriveBytes(Chave, Salto);
                aes.Key = cripto.GetBytes(32);
                aes.IV = cripto.GetBytes(16);

                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }

                    texto = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return texto;
        }

        public static string Descriptografar(string texto)
        {
            texto = texto.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(texto);

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes cripto = new Rfc2898DeriveBytes(Chave, Salto);
                aes.Key = cripto.GetBytes(32);
                aes.IV = cripto.GetBytes(16);

                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }

                    texto = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }

            return texto;
        }


    }
}
