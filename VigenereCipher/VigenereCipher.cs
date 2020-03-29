using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class VigenereCipher
    {
     
        private char [,] table;

        public VigenereCipher(int asciiStart, int asciiStop)
        {
            createTable(asciiStart, asciiStop);
        }

        public void createTable(int asciiStart, int asciiStop)
        {
            int size = asciiStop - asciiStart;
            table = new char[size, size];

            char[] rowGenerator = new char[size];
           
            //row generator
            for (int i = 0; i < size; i++)
            {
                rowGenerator[i] = (char) (i + asciiStart);
            }

            //shift characters
            int asciiCode; 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    asciiCode = (int) rowGenerator[j] + i;
                    if (asciiCode >= asciiStop)
                        asciiCode = (asciiCode % asciiStop) + asciiStart ; 
                    table[i, j] = (char) asciiCode;
                }
            }
        }

        /* getRow/Column index with specific character
            row index - plaintext
            column index - key
        */
        public int getCharacterIndex(char character, int index)
        {
            int size = table.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                if (table[i, index] == character)
                    return i;
            }
            return -1;
        }

        public string encrypt(string plaintext, string key)
        {
            char[] keyChars = key.ToCharArray();
            char[] plaintextChars = plaintext.ToCharArray();

            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < plaintextChars.Length; i++)
            {
                int plaintextCharTableIndex = getCharacterIndex(plaintextChars[i], 0);
                int keyCharTableIndex = getCharacterIndex(keyChars[i % keyChars.Length], 0);

                encrypted.Append(table[plaintextCharTableIndex, keyCharTableIndex]);
            }

            return encrypted.ToString();
        }

        public string decrypt(string cipher, string key)
        {
            char[] keyChars = key.ToCharArray();
            char[] cipherChars = cipher.ToCharArray();

            StringBuilder decrypted = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                int keyCharTableIndex = getCharacterIndex(keyChars[i % keyChars.Length], 0);
                int cipherCharTableIndex = getCharacterIndex(cipherChars[i], keyCharTableIndex);

                decrypted.Append(table[cipherCharTableIndex, 0]);
            }

            return decrypted.ToString();
        }

        public string tableToString(string separator)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    builder.Append(table[i, j] + separator);
                }

                builder.Append("\r\n");
            }

            return builder.ToString();
        }


    }
}
