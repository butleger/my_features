using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace cesaar
{
    class Visioner_Cryptor : ICryptor
    {
        int[] Keys;
        string upper_alphabet;
        string lower_alphabet;

        public Visioner_Cryptor(int[] Keys, string alphabet)
        {
            this.Keys = Keys;
            lower_alphabet = alphabet.ToLower();
            upper_alphabet = alphabet.ToUpper();
        }


        public Visioner_Cryptor(VisionerConfig conf) : this(conf.Keys, conf.Alphabet)
        { }


        string ICryptor.encrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);
            
            for (int i = 0; i < text.Length; ++i)
            {
                int index, key;

                if (upper_alphabet.Contains(text[i]))
                {
                    index = upper_alphabet.IndexOf(text[i]);
                    key = Keys[i % Keys.Length];
                    result[i] = upper_alphabet[(index + key) % upper_alphabet.Length];
                }

                if (lower_alphabet.Contains(text[i]))
                {
                    index = lower_alphabet.IndexOf(text[i]);
                    key = Keys[i % Keys.Length];
                    result[i] = lower_alphabet[(index + key) % lower_alphabet.Length];
                }
            }
            return result.ToString();
        }


        string ICryptor.decrypt(string text)
        {
            StringBuilder result = new StringBuilder(text);

            for (int i = 0; i < text.Length; ++i)
            {
                int index, key;

                if (upper_alphabet.Contains(text[i]))
                {
                    index = upper_alphabet.IndexOf(text[i]);
                    key = Keys[i % Keys.Length];
                    result[i] = upper_alphabet[(index - key + upper_alphabet.Length) % upper_alphabet.Length];
                }

                if (lower_alphabet.Contains(text[i]))
                {
                    index = lower_alphabet.IndexOf(text[i]);
                    key = Keys[i % Keys.Length];
                    result[i] = lower_alphabet[(index - key + lower_alphabet.Length) % lower_alphabet.Length];
                }
            }
            return result.ToString();
        }
    }
}
