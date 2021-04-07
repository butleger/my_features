using System;
using System.Linq;
using System.Text;
using System.Security;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace cesaar
{
    public class VisionerConfig
    {
        private string alphabet;
        private int[] offsets;
        private string key;
        

        public VisionerConfig(string alphabet, string key)
        {
            this.key = key;
            this.alphabet = alphabet;
            offsets = new int[key.Length];

            for (int i = 0; i < key.Length; ++i)
                offsets[i] = alphabet.IndexOf(key[i]);
        }


        public string Alphabet { get { return alphabet; } }
        public int[] Keys { get { return offsets; } }
    }
}
