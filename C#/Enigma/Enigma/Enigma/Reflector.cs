using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    partial class EnigmaMachine
    {
        /*
         * Just map one symbol to
         * another for EnigmaMachine
         * ( if it in the alphabet, else skip )
         */
        class Reflector
        {
            string m_alphabet;          /* use only lower symbols */
            string m_reflectedAlphabet; /* use only lower symbols */


            public Reflector(string alphabet, string reflectedAlphabet)
            {
                if (alphabet == null || reflectedAlphabet == null)
                    throw new Exception("Reflector.Reflector alphabet is null " +
                                        "or reflectedAlphabet is null");
                if (alphabet.Length != reflectedAlphabet.Length)
                    throw new Exception("Reflector.Reflector alphabet.Length " +
                                        "!= reflectedAlphabet.Length");

                this.m_alphabet = alphabet.ToLower();
                this.m_reflectedAlphabet = reflectedAlphabet.ToLower();
            }

            /*
             * Just get one symbol and map it to another
             * ( if it in the alphabet, else skip )
             * return index of main alpha
             */
            public int Reflect(int symIndex)
            { 

                // skip non-alpha symbols(spaces and others)
                if ( symIndex < 0 || m_alphabet.Length <= symIndex)
                {
                    throw new Exception( "Reflect: bad index!" );
                }
                
                char relectedSym    = m_reflectedAlphabet[symIndex];
                int reflectedIndex  = m_alphabet.IndexOf( relectedSym );
                return reflectedIndex;
            }
        }
    }
}
