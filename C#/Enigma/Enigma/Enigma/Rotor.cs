using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    partial class EnigmaMachine
    {
        /* This class just do substitutions( without rotorPosition )
         * and save variables( alphabet, stepLetters, 
         * substiotutions) for EnigmaMachine 
         * that will perform all rotations and other 
         * logic; it means that rotors don`t rotate
         * and JUST DO SUBSTITUTIONS using given alphabets
         * 
         * All objects should be created by EnigmaMachine.RotorFactory
         */
        class Rotor
        {
            private string  m_alphabet;
            private string  m_substitutions;    /* this mapped on main alphabet*/
            private string  m_stepLetters;      /* if find this letters then rotate */
            private int[]   m_offsets;          /* need only for rings */
            private int     m_rotorPosition;
            //private int ringPosition;   /* no need for current version */


            // this fields needed for EnigmaMachine 
            public int RotorPosition    { get { return m_rotorPosition; } }
            public string Substitutions { get { return m_substitutions; } }
            public string StepLetters   { get { return m_stepLetters; } }
            public string Alphabet      { get { return m_alphabet; } }


            public Rotor(
                string alphabet, 
                string substitutions, 
                string stepLetters, 
                int startPosition
                )
            {
                if (alphabet == null 
                    || substitutions == null 
                    || stepLetters == null)
                {
                    throw new Exception("Rotor.Rotor alphabet == null " +
                                        "or substitutions == null " +
                                        "or stepLettters == null");
                }
                
                if (alphabet.Length != substitutions.Length)
                {
                    throw new Exception(
                        "Rotor.Rotor alphabet.length != substitutions.length"
                    );
                }

                m_alphabet = alphabet.ToUpper();
                m_stepLetters = stepLetters.ToUpper();
                m_substitutions = substitutions.ToUpper();

                Rotate(startPosition);

                /*
                 * offsets needed only for rings
                 */
                m_offsets = new int[alphabet.Length];
                for (int i = 0; i < alphabet.Length; ++i)
                {
                    int substitutionIndex = alphabet.IndexOf(substitutions[i]);
                    m_offsets[i] = i - substitutionIndex;
                }
            }


            /*
             * Method user to cipher non-reflected signals( indexes )
             * for reflected indexes have another method
             * 
             * Indexes used because EnigmaMachine have much work 
             * with indexes and it is more comfortable way to
             * do this
             * 
             * symIndex is index of letter from m_alphabet
             */
            public int CipherRightSignal(int symIndex)
            {
                if ( symIndex < 0 || m_alphabet.Length <= symIndex )
                {
                    throw new Exception( "CipherRightSignal: bad index!" );
                }
                char encodedSym = m_substitutions[symIndex]; 
                int encodedIndex = m_alphabet.IndexOf( encodedSym );
                return encodedIndex;
            }

            /*
             * Method user to cipher reflected signals( indexes )
             * for non reflected indexes have another method
             * 
             * Indexes used because EnigmaMachine have much work 
             * with indexes and it is more comfortable way to
             * do this
             * 
             * symIndex is index of letter from m_alphabet
             */
            public int CipherReflectedSignal(int symIndex)
            {
                if (symIndex < 0 || m_alphabet.Length <= symIndex)
                {
                    throw new Exception("CipherRightSignal: bad index!");
                }

                char reflectedSym = m_alphabet[symIndex];
                int index = m_substitutions.IndexOf( reflectedSym );
                return index;
            }


            /*
             * EnigmaMachine should care about rotor positions
             * So this method provide logic for it
             */
            public void Rotate(int steps)
            {
                m_rotorPosition += steps;
                while (m_rotorPosition < 0) /* if steps < 0 */
                {
                    m_rotorPosition += m_alphabet.Length; 
                }
                m_rotorPosition %= m_alphabet.Length;
            }
        }
    }
}
