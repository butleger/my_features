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
     * and can encrypt/decrypt text with keys that it generate by itself
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
         * This method provide RSACryptor with castom keys, but it
         * DONT HAVE checks in it, so if you pass bad numbers it
         * will be your fault and undefined behaviour
         */
        public static RSACryptor UnsafeFactory(BigInteger p, BigInteger q, BigInteger e)
        {
            return new RSACryptor(p, q, e);
        }


        /*
         * Unsafe constructor that dont do checks
         * and just pass q, p and keyLength values to RSA
         */
        private RSACryptor(BigInteger p, BigInteger q, BigInteger e)
        {
            this.p = p;
            this.q = q;
            n = p * q;
            eulerFunctionValue = (p - 1) * (q - 1);
            this.e = e;
            d = GenerateD(eulerFunctionValue, e);
        }


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

            e = GenerateE(keyLength);
            d = GenerateD(eulerFunctionValue, e);
        }


        /*
         * Generate open exponent in RSA
         */
        private BigInteger GenerateE(int keyLength)
        {
            int eBitLength = keyLength / 3;
            PrimeNumberRandomizer rand = new PrimeNumberRandomizer();
            BigInteger result = rand.GetRandom(eBitLength);

            while (BigInteger.GreatestCommonDivisor(eulerFunctionValue, e) != 1)
                result = rand.GetRandom(eBitLength);
            
            return result;
        }


        private BigInteger GenerateD(BigInteger eulerFunctionValue, BigInteger e)
        {
            ExtendedGCD gcd = new ExtendedGCD(eulerFunctionValue, e);
            BigInteger result = gcd.Result.Y;
            while (result < 0) result += eulerFunctionValue;
            return result;
        }


        /*
         * Encrypt all chars in text
         */
        public string Encrypt(string text)
        {
            string result = "";

            foreach (char sym in text)
                result += EncryptChar(sym).ToString() + " ";

            return result;
        }


        /*
         * Main RSA Encryption Algo
         */
        public BigInteger EncryptChar(char sym)
        {
            BigInteger c = (BigInteger)sym;
            return BigInteger.ModPow(c, e, n);
        }


        /*
         * This function get ciphered text with big numbers(that previously be chars)
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
         * Needed for custom encryptions
         */
        public byte[] Decrypt(BigInteger number)
        {
            return BigInteger.ModPow(number, d, N).ToByteArray();
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
            return (char)( BigInteger.ModPow(number, d, n) % alphabetLength );
        }
    }
}
