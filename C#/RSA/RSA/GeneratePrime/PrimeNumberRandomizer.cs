using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EulerAndFastPower
{
    /*
     * Just provide one method GetRandom
     */
    class PrimeNumberRandomizer
    {
        public PrimeNumberRandomizer()
        { }


        /*
         * Get amount of bits, than convert it 
         * into bytes(add one if some bits where overflowed)
         * than fill that byte array by random numbers 
         * and kicks some excess bytes 
         */
        public BigInteger GetRandom(int bits)
        {
            if (bits < 0)
                throw new Exception("amount of bits must be more than 0");

            if (bits == 0)
                return 0;

            BigInteger result;
            BigInteger maxValue = BigInteger.Pow(2, bits);
            RandomNumberGenerator r = new RNGCryptoServiceProvider();
            Int64 bytes = bits / 8;

            if (bits % 8 != 0)
                ++bytes;

            byte[] bytedNumber = new byte[bytes];
            RabbinMiller tester = new RabbinMiller();


            r.GetBytes(bytedNumber);
            /*
             * getMask return mask for bited & to remove some too big bits
             */
            if (bits % 8 != 0)
            {
                bytedNumber[bytedNumber.Length - 1] &= (byte)getMask(bits % 8);
            }


            result = new BigInteger(bytedNumber);
            
            /*
             * if significant byte will be raises 
             * raise it down
             */
            if (result < 0)
                result *= -1;

            /*
             * if number even plus one because next 
             * code will just add 2 and it will 
             * be infinite loop
             */
            if (result % 2 == 0)
                ++result;

            while (!tester.TestPrime(result))
                result = (result + 2) % maxValue;

            return result;
        }


        /*
         * Get amount of bits that should be raised
         * like if function get 3 then it output 00000111
         * throw exception if get bad data
         */
        private int getMask(int significantBites)
        {
            if (significantBites > 8)
                throw new Exception("Significant bits should be less than 8");

            int result = 0;

            for (int i = 0; i < significantBites; ++i)
                result += (int)Math.Pow(2, i);


            return result;
        }
    }
}
