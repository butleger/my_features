using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cesaar
{
    public class CesaarConfig
    {
        private string alphabet;
        private int key;

        
        public CesaarConfig(string alphabet, int key)
        {
            this.key = key;
            this.alphabet = alphabet;
        }


        public string Alphabet { get{ return alphabet;} }
        public int Key { get { return key; } }

    }
}
