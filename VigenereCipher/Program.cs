using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //table contains chars from range 32 - 126 
            VigenereCipher cipher = new VigenereCipher(32, 126);
           
            //print table
            Console.WriteLine(cipher.tableToString(" "));

            //encrypting and decrypting word "MICHIGAN" using key
            string key = ".F#1s!";
            string encrypt = cipher.encrypt("MICHIGAN", key);
            string decrypt = cipher.decrypt(encrypt, key);

            //print results
            Console.WriteLine(encrypt);
            Console.WriteLine(decrypt);

            Console.ReadKey();
        }
    }
}
