using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerAndFastPower
{
    /*
     * Class implement IPrimaryTester.TestPrime(BigInteger)
     */
    class RabbinMiller : IPrimaryTester
    {
        /*
         * if true show some messages 
         */
        private bool DEBUG;

        public RabbinMiller(bool debug = false)
        { this.DEBUG = debug; }


        /*
         * this class represent number as formula: num = 2^s * t + 1
         */
        private class FactorNumberView
        {
            public BigInteger T { get; set; } // multyplayer
            public BigInteger S { get; set; } // power


            public FactorNumberView(BigInteger number)
            {
                BigInteger temp = number - 1;

                // here we find T and S
                while (temp % 2 == 0)
                {
                    S += 1;
                    temp /= 2;
                }
                T = temp;
            }
        }


        /*
         * Care, this function may throw exception
         * This function implement Rabbin-Miller algo
         * algo itself:
         * 1) Represent number in formula num = 2^S*T + 1
         * 2) Get random a in [2, num]
         * 3) if num % a == 0 then num is not prime (and we find solution)
         * 4) Find b = a^T % num
         * 5) if b == +-1
         * 6) Start Iteration( S times )
         * 7) Find bi = bi-1 ^ 2 % num
         * 8) if bi != -1 for each i < S than number is not prime
         * 9) else go to 2 point (and do it log2(num) times) 
         */
        public bool TestPrime(BigInteger number)
        {
            if (number < 0)
                throw new Exception("Number must be more than 0!");

            if (number == 1)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            FactorNumberView numberView = new FactorNumberView(number);

            BigInteger amountOfWitnesses = new BigInteger(BigInteger.Log(number, 2));
            BigInteger a = 2;

            for (BigInteger i = 2; i < amountOfWitnesses; ++i)
            {
                if (number % a == 0)
                {
                    if (DEBUG)
                        MessageBox.Show($"{a} is the divider of {number}");
                    return false;
                }
                else
                {
                    BigInteger b = BigInteger.ModPow(a, numberView.T, number);
                    
                    if (b != 1 && b != number - 1)
                    {
                        for (BigInteger iteration = 0; iteration < numberView.S - 1; ++iteration)
                        {
                            b = BigInteger.ModPow(b, 2, number);
                            if (b == number - 1)
                                goto MayBePrime;
                        }
                        if (DEBUG)
                            MessageBox.Show($"Not prime because b != {number - 1}");
                        return false;
                    }
                }

            MayBePrime:;
                a = GetRandomNumberLessThan(number);
                if (DEBUG)
                    MessageBox.Show($"a = {a}");
            }

            return true;
        }


        /*
         * Get random byted array, make it less than max by % 
         * and make BigInteger from it
         */
        private BigInteger GetRandomNumberLessThan(BigInteger max)
        {
            RandomNumberGenerator r = new RNGCryptoServiceProvider();
            Int64 bytesLength = max.ToByteArray().Length;
            byte[] bytedNumber = new byte[bytesLength];
            r.GetBytes(bytedNumber);
            
            BigInteger result = new BigInteger(bytedNumber);
            result = result % max;

            if (result <= 1)
                result = GetRandomNumberLessThan(max);
            
            return result;
        }
    }
}
