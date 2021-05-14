using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class PlugBoard
    {
        private Dictionary<char, char> m_commutators;

        /*
         * stringedCommutators is a string like AB CA GG DC
         * from which commutators will be made
         */
        public PlugBoard(string stringedCommutators)
        {
            if (stringedCommutators == null)
            {
                throw new Exception("PlugBoard(): stringedCommutators is null!");
            }

            string uppedCommutators = stringedCommutators.ToUpper();
            string[] commutators = uppedCommutators.Split(' ', '\t', '\n');

            m_commutators = new Dictionary<char, char>();
            
            if (stringedCommutators != "")
            {
                foreach (var stringedCommutator in commutators)
                {
                    m_commutators.Add(stringedCommutator[0], stringedCommutator[1]);
                    m_commutators.Add(stringedCommutator[1], stringedCommutator[0]);
                }
            }
        }


        /*
         * if have this key 
         * return commutated value
         * else 
         * return default symbol( key itself )
         */
        public char Commutate(char key)
        {
            key = Char.ToUpper(key);
            if (!m_commutators.ContainsKey(key))
            {
                return key;
            }
            else
            {
                return m_commutators[key];
            }
        }
    }
}
