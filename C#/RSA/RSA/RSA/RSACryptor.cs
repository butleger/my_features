using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerAndFastPower.RSA
{
    /*
     * Main class for RSA algo, its provide all values that RSA needs to generate
     * and can encrypt/decrypt texts with keys that it generate by itself
     */
    class RSACryptor
    {
        BigInteger p;
        BigInteger q;
        BigInteger d;
        BigInteger e;
        BigInteger n;
        BigInteger eulerFunctionValue;


        public BigInteger P { get { return p; } }
        public BigInteger Q { get { return q; } }
        public BigInteger D { get { return d; } }
        public BigInteger E { get { return e; } }
        public BigInteger N { get { return n; } }

        public BigInteger EulerValue { get { return eulerFunctionValue; } }

        int keyLength;


        /*
         * This constructor generate all numbers that RSA needs
         * Take care this function may throw exception
         */
        public RSACryptor(int bitlength)
        {
            if (bitlength <= 0)
                throw new Exception("all is really bad");

            keyLength = bitlength;

            PrimeNumberRandomizer rand = new PrimeNumberRandomizer();

            p = rand.GetRandom(keyLength);
            q = rand.GetRandom(keyLength);
            while (q == p) q = rand.GetRandom(keyLength);

            n = p * q;
            eulerFunctionValue = (p - 1) * (q - 1);

            e = GenerateE();


            /*
             * Generate d parametr through extended gcd 
             */
            ExtendedGCD gcd = new ExtendedGCD(eulerFunctionValue, e);
            d = gcd.Result.Y;
            while (d < 0) d += eulerFunctionValue;
        }


        /*
         * Generate open exponent in RSA
         */
        private BigInteger GenerateE()
        {
            int eBitLength = keyLength / 3;
            PrimeNumberRandomizer rand = new PrimeNumberRandomizer();
            return rand.GetRandom(eBitLength);
        }


        /*
         * Get big text and encrypt every char in it
         */
        public string Encrypt(string text)
        {
            string result = "";

            foreach (char sym in text)
                result += EncryptChar(sym).ToString() + " ";

            return result;
        }


        /*
         * Just encrypt one char into big number through RSA
         */
        private BigInteger EncryptChar(char sym)
        {
            BigInteger c = (BigInteger)sym;
            return BigInteger.ModPow(c, e, n);
        }


        /*
         * This function get ciphered with big numbers(that previously be chars)
         * parse it into array of strings convers string to biginteger and call
         * Decrypt(BigInteger)
         * Take care! This function may throw exception
         */
        public string Decrypt(string cipheredText)
        {
            if (cipheredText == null || cipheredText == "")
                return "";

            string[] stringedCodes = cipheredText.Split(' ', '\n', '\0', '\t');
            string result = "";


            foreach (string stringedNumber in stringedCodes)
            {
                /*
                 * this is just bug with split that i dont fix
                 */
                if (stringedNumber == "")
                    continue;

                BigInteger number;
                try
                {
                    number = BigInteger.Parse(stringedNumber);
                }
                catch
                {
                    throw new Exception("Some shit occured!");
                }
                result += DecryptNumber(number);
            }

            return result;
        }

        /*
         * Algo encrypt symbols into big numbers, 
         * and this function decrypt big numbers into chars back
         */
        private char DecryptNumber(BigInteger number)
        {
            /*
             * "% sizeof" is used to avoid exception when sombedy
             * ruin numbers in uncipher window
             */
            int alphabetLength = (int)Math.Pow(2, 8 * sizeof(char));
            return (char)( BigInteger.ModPow(number, d, n) % alphabetLength);
        }
    }
}
