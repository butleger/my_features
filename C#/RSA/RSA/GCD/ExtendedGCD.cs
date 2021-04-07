using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerAndFastPower
{
    class ExtendedGCD
    {
        ExtendedGCDResult result;


        /*
         * Dont check args and call calculating function
         */
        public ExtendedGCD(BigInteger a, BigInteger b)
        {
            if (a <= 0 || b <= 0)
                throw new Exception("A and B must be more than 0");

            CalcResult(a, b);
        }


        /*
         * This function should init result and calc values
         * use recursive gcdex
         * dont know what will be if x and y will not be 0
         */
        private void CalcResult(BigInteger a, BigInteger b)
        {
            BigInteger x = 0;
            BigInteger y = 0;
            BigInteger nod = GCDExt(a, b, ref x, ref y);

            result = new ExtendedGCDResult(y, x, nod);
        }


        /*
         * Recursive implementation of extended GCD
         * Use feature that x and y can be described 
         * recurrently
         */
        private BigInteger GCDExt(BigInteger max, BigInteger min, ref BigInteger x, ref BigInteger y)
        {
            if (min == 0)
            {
                y = 1;
                x = 0;
                return max;
            }

            BigInteger x1 = 0;
            BigInteger y1 = 0;
            BigInteger nod = GCDExt(min, max % min, ref x1, ref y1);
            x = y1 - (max / min) * x1;
            y = x1;

            return nod;
        }


        /*
         * if result dont calculated then you do some bad shit
         * with calc_result function
         */
        public ExtendedGCDResult Result 
        { 
            get 
            {
                if (result == null)
                    throw new Exception("Result not initialized!\n");
                else
                    return result;
            } 
        }
    }
}
