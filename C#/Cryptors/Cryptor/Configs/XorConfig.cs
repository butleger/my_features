using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cesaar.Configs
{
    public class XorConfig
    {
        private string alphabet;
        private int[] keys;
        private byte[] randomed_keys;


        public XorConfig(string alphabet, string key)
        {
            this.alphabet = alphabet;
            keys = new int[key.Length];

            for (int i = 0; i < key.Length; ++i)
                keys[i] = (byte)alphabet.IndexOf(key[i]);
        }


        public XorConfig(string alphabet, byte[] randomed_key)
        {
            this.alphabet = alphabet;
            this.randomed_keys = randomed_key;
            keys = new int[randomed_key.Length];

            for (int i = 0; i < randomed_key.Length; ++i)
                keys[i] = randomed_key[i] % alphabet.Length;
        }


        public string Alphabet { get { return alphabet; } }
        public int[] Keys { get { return keys; } }
        public byte[] RandomedKeys { get { return randomed_keys; } }
    }
}
