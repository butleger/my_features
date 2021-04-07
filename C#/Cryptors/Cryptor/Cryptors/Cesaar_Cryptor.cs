using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cesaar
{
    class Cesaar_Cryptor : ICryptor
    {
        int key;
        string lower_alphabet;
        string upper_alphabet;


        public Cesaar_Cryptor(int key, string alphabet)
        {
            key = key % alphabet.Length;
            while (key < 0) key += alphabet.Length;
            this.key = key;
            this.upper_alphabet = alphabet.ToUpper();
            this.lower_alphabet = alphabet.ToLower();
        }


        public Cesaar_Cryptor(CesaarConfig conf) : this(conf.Key, conf.Alphabet)
        { }


        string ICryptor.encrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < result.Length; ++i)
            {
                char sym = result[i];
                int sym_index = 0;

                if (lower_alphabet.Contains(sym))
                {
                    sym_index = lower_alphabet.IndexOf(sym);
                    result[i] = lower_alphabet[(sym_index + key) % lower_alphabet.Length];
                }

                if (upper_alphabet.Contains(sym))
                {
                    sym_index = upper_alphabet.IndexOf(sym);
                    result[i] = upper_alphabet[(sym_index + key) % upper_alphabet.Length];
                }
            }
            return result.ToString();
        }


        string ICryptor.decrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < result.Length; ++i)
            {
                char sym = result[i];
                int sym_index = 0;

                if (lower_alphabet.Contains(sym))
                {
                    sym_index = lower_alphabet.IndexOf(sym);
                    result[i] = lower_alphabet[(sym_index - key + lower_alphabet.Length) % lower_alphabet.Length];
                }

                if (upper_alphabet.Contains(sym))
                {
                    sym_index = upper_alphabet.IndexOf(sym);
                    result[i] = upper_alphabet[(sym_index - key + upper_alphabet.Length) % upper_alphabet.Length];
                }
            }
            return result.ToString();
        }
    }
}
