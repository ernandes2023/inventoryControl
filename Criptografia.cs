using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace inventoryControl
{
    internal static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            using (var hash = SHA256.Create())                  // Cria uma instância do algoritmo SHA-256.
            {
                var encoding = new UTF8Encoding();              // Cria uma instância da codificação ASCII.
                
                var array = encoding.GetBytes(valor);           // Converte a string de entrada em um array de bytes ASCII.

                array = hash.ComputeHash(array);                // Calcula o hash SHA-1 do array de bytes.

                var strHexa = new StringBuilder();              // Cria um StringBuilder para construir a string hexadecimal do hash.

                foreach (var item in array)                     // Itera sobre cada byte do hash.
                {
                    strHexa.Append(item.ToString("X2"));        // Converte cada byte em uma string hexadecimal de dois dígitos e adiciona ao StringBuilder.
                }
                return strHexa.ToString();                      // Retorna a string hexadecimal completa.
            }
        }
    }
}
