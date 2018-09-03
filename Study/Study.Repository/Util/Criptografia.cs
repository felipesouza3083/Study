using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Util
{
    public class Criptografia
    {
        public static string EncriptarSenhaMD5(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //para encriptar, precisamos converter o valor
            //de string para bytes..
            byte[] valorEmBytes = Encoding.UTF8.GetBytes(valor);

            //realizar a criptografia..
            byte[] hash = md5.ComputeHash(valorEmBytes);

            //converter o resultado da criptografia (hash)
            //de formato byte para formato string..
            string resultado = string.Empty;

            //varrer o vetor de bytes
            foreach (byte b in hash)
            {
                resultado += b.ToString("X2");
            }

            //retornando o resultado
            return resultado;
        }

        public string EncriptarSenhaSHA1(string valor)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] valorEmBytes = Encoding.UTF8.GetBytes(valor);

            byte[] hash = sha1.ComputeHash(valorEmBytes);

            string resultado = string.Empty;

            foreach (byte b in hash)
            {
                resultado += b.ToString("X2");
            }

            return resultado;
        }
    }
}

