using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    partial class EnigmaMachine
    {
        Rotor m_first;
        Rotor m_second;
        Rotor m_third;
        Reflector m_reflector;
        PlugBoard m_commutators;

        // main alphabet
        // using it in RotorFactory and ReflectorFactory
        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Alphabet { get { return alphabet; } }
        
        /*
         * It takes first positions of rotors and its 
         * numbers that STARTS FROM 1!
         * 
         * commutatorsString is string like AB CD OP 
         * and so on...
         */
        public EnigmaMachine(
            RotorTypes firstRotorNumber,    int firstRotorStartPosition,
            RotorTypes secondRotorNumber,   int secondRotorStartPosition,
            RotorTypes thirdRotorNumber,    int thirdRotorStartPosition, 
            ReflectorTypes reflectorNumber,
            string commutatorsString
            )
        {
            /* if yout want to try make all rotors in array
             * can try to uncomment it and rewrite CipherChar
             
            m_rotors = new Rotor[]
            {
                RotorFactory((int)firstRotorNumber,   firstRotorStartPosition),
                RotorFactory((int)secondRotorNumber,  secondRotorStartPosition),
                RotorFactory((int)thirdRotorNumber,   thirdRotorStartPosition),
            };
            */

            m_first  = RotorFactory((int)firstRotorNumber,     firstRotorStartPosition);
            m_second = RotorFactory((int)secondRotorNumber,    secondRotorStartPosition);
            m_third  = RotorFactory((int)thirdRotorNumber,     thirdRotorStartPosition);

            m_reflector = ReflectorFactory( (int)reflectorNumber );

            m_commutators = new PlugBoard(commutatorsString);
        }


        public enum RotorTypes
        {
            First = 1,
            Second,
            Third,
            Fourth,
            Fifth,
            Sixth,
            Seventh,
            Eighth,
            Last = Eighth,
        }


        static private Rotor RotorFactory(  
            int rotorNum, 
            int startPosition
            )
        {
            if (rotorNum < (int)RotorTypes.First || (int)RotorTypes.Last < rotorNum)
            {
                throw new Exception( "RotorFactory: bad rotor number" );
            }

            string[] rotorSubstitutions = new string[]
            {
                "", /* because rotor numbers start from 1 */
                "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
                "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                "ESOVPZJAYQUIRHXLNFTGKDCMWB",
                "VZBRGITYUPSDNHLXAWMJQOFECK",
                "JPGVOUMFYQBENHZRDKASXLICTW",
                "NZJHGRCXMYSWBOUFAIVLPEKQDT",
                "FKQHTLXOCBJSPDZRAMEWNIUYGV"
              //"ABCDEFGHIJKLMNOPQRSTUVWXYZ" /* default alphabet help to compare rotors */
            };

            // letters when some rotor rotate next rotor
            string[] rotorStepLetters = new string[]
            {
                "", /* rotor numbers start from 1 */
                "R",
                "F", // should be F
                "W",
                "K",
                "A",
                "AN",
                "AN",
                "AN",
            };

            return new Rotor( alphabet, rotorSubstitutions[rotorNum], 
                rotorStepLetters[rotorNum], startPosition );
        }


        public enum ReflectorTypes { First = 0, B = First, C, Last = C }

        /*
         * Main factory of Rotors
         * Would be better if you will create them using this
         */
        private static Reflector ReflectorFactory(int reflectorNumber)
        {
            if (reflectorNumber < (int)ReflectorTypes.First || (int)ReflectorTypes.Last < reflectorNumber)
            {
                throw new Exception( "ReflectorFactory: bad reflector number!" );
            }

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string[] reflectorSubstitutions = new string[]
            {
                "yruhqsldpxngokmiebfzcwvjat",
                "fvpjiaoyedrzxwgctkuqsbnmhl"
            };

            return new Reflector( alphabet, reflectorSubstitutions[reflectorNumber] );
        }

        /*
         * Just cipher all char and 
         * make big text from them 
         */
        public string CipherText(string text)
        {
            string result = "";
            foreach (char sym in text)
            {
                result += new string( CipherChar(sym), 1 );
            }
            return result;
        }


        /*
         * Main Enigma algorithm
         * 
         * Here will be many comments with string report
         * it is artifact of debug, think it may be usefull in future
         */
        private char CipherChar(char sym)
        {
            // if uncomment it, it may crush
            if (!alphabet.Contains( Char.ToUpper( sym ) ))
            {
                return sym;
            }

            sym = m_commutators.Commutate(sym);

            m_first.Rotate( 1 ); /* first rotor rotate on each letter */
            // symIndex always be index of main alphabet
            int symIndex = m_first.Alphabet.IndexOf(sym);
            // string report = $"[START] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";

            symIndex += m_first.RotorPosition;
            symIndex %= m_first.Alphabet.Length;
            
            if ( m_first.StepLetters.Contains(m_first.Alphabet[m_first.RotorPosition]))
            {
                // report += "[SECOND ROTOR] Rotated by first\n";
                m_second.Rotate(1);
            }
            // report += $"[FIRST ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_first.CipherRightSignal( symIndex );
            // report += $"[FIRST ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_first.RotorPosition;
            symIndex += m_second.RotorPosition;
            symIndex += m_second.Alphabet.Length;
            symIndex %= m_second.Alphabet.Length;

            if (m_second.StepLetters.Contains(m_second.Alphabet[m_second.RotorPosition]))
            {
                // report += "[THIRD ROTOR] Rotated by second\n";
                m_third.Rotate(1);
            }
            // report += $"[SECOND ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_second.CipherRightSignal( symIndex );
            // report += $"[SECOND ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_second.RotorPosition;
            symIndex += m_third.RotorPosition;
            symIndex += m_third.Alphabet.Length;
            symIndex %= m_third.Alphabet.Length;


            // report += $"[THIRD ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_third.CipherRightSignal( symIndex );
            // report += $"[THIRD ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_third.RotorPosition;
            symIndex += m_third.Alphabet.Length;
            symIndex %= m_third.Alphabet.Length;


            // report += $"[REFLECTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_reflector.Reflect( symIndex );
            // report += $"[REFLECTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex += m_third.RotorPosition;
            symIndex %= m_third.Alphabet.Length;


            // report += $"[THIRD ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_third.CipherReflectedSignal( symIndex );
            // report += $"[THIRD ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_third.RotorPosition;
            symIndex += m_second.RotorPosition;
            symIndex += m_second.Alphabet.Length;
            symIndex %= m_second.Alphabet.Length;


            // report += $"[SECOND ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_second.CipherReflectedSignal( symIndex );
            // report += $"[SECOND ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_second.RotorPosition;
            symIndex += m_first.RotorPosition;
            symIndex += m_first.Alphabet.Length;
            symIndex %= m_first.Alphabet.Length;


            // report += $"[FIRST ROTOR INPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex = m_first.CipherReflectedSignal( symIndex );
            // report += $"[FIRST ROTOR OUTPUT] symindex = {symIndex}( {m_first.Alphabet[symIndex]} )\n";
            symIndex -= m_first.RotorPosition;
            symIndex += m_first.Alphabet.Length;
            symIndex %= m_first.Alphabet.Length;

            // report += $"[END]symIndex = {symIndex}, result = {m_first.Alphabet[symIndex]}\n";
            // MessageBox.Show(report);
            char notCommutatedResult = m_first.Alphabet[symIndex];
            // MessageBox.Show($"notCommutatedResult = {m_first.Alphabet[symIndex]}\n");
            return m_commutators.Commutate( notCommutatedResult );
        }


        /*
         * Ciphering and Unciphering are similar 
         * in this algo
         */
        public string UncipherText(string text)
        {
            return CipherText(text);
        }
    }
}
