using cesaar.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace cesaar.Cryptors
{
    class XorCryptor : ICryptor
    {
        string upper_alphabet;
        string lower_alphabet;

        int[] keys;


        public XorCryptor(XorConfig conf) : this(conf.Alphabet, conf.Keys)
        { }


        public XorCryptor(string alphabet, int[] keys)
        {
            upper_alphabet = alphabet.ToUpper();
            lower_alphabet = alphabet.ToLower();

            this.keys = keys; 
        }


        string ICryptor.decrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < text.Length; ++i)
                if (lower_alphabet.Contains(text[i]))
                    result[i] = decrypt_lower_char(text[i], keys[i % keys.Length]);

                else if (upper_alphabet.Contains(text[i]))
                    result[i] = decrypt_upper_char(text[i], keys[i % keys.Length]);
            
            return result.ToString();
        }


        private char encrypt_lower_char(char sym, int key)
        {
            int code = convert_lower_char_to_int(sym);
            int ciphered_code = code ^ key % lower_alphabet.Length;

            return convert_int_to_lower_char(ciphered_code);
        }


        private char encrypt_upper_char(char sym, int key)
        {
            int code = convert_upper_char_to_int(sym);
            int ciphered_code = code ^ key % upper_alphabet.Length;

            return convert_int_to_upper_char(ciphered_code);
        }


        private char decrypt_lower_char(char sym, int key)
        {
            return encrypt_lower_char(sym, key);
        }


        private char decrypt_upper_char(char sym, int key)
        {
            return encrypt_upper_char(sym, key);
        }

        
        private char convert_int_to_lower_char(int index)
        {
            return lower_alphabet[index];
        }


        private char convert_int_to_upper_char(int index)
        {
            return upper_alphabet[index];
        }


        private int convert_lower_char_to_int(char symbol)
        {
            return lower_alphabet.IndexOf(symbol);
        }


        private int convert_upper_char_to_int(char symbol)
        {
            return upper_alphabet.IndexOf(symbol);
        }


        string ICryptor.encrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < text.Length; ++i)
                if (lower_alphabet.Contains(text[i]))
                    result[i] = encrypt_lower_char(text[i], keys[i % keys.Length]);
                else if (upper_alphabet.Contains(text[i]))
                    result[i] = encrypt_upper_char(text[i], keys[i % keys.Length]);
            return result.ToString();
        }

    }
}
