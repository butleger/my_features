using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;

namespace EulerAndFastPower
{
    class FastPowResolver
    {
        public FastPowResolver()
        { }
        

        /*
         * Algo used to calc fast power is
         * 1) Represent power as a bits table
         * 2) Under the first bit place number itself
         * 3) Next calculation use this formula if (pi == 0) ci = ci-1 ^ 2 else ci = ci-1 ^ 2 * num
         * 4) Result of Power will be placed under the last bit
         * 
         * p.s. binaryString uses for simple access to bits
         */
        public BigInteger Power(BigInteger num, BigInteger power, BigInteger module)
        {
            if (num <= 0 || module <= 0 || power <= 0)
                throw new Exception("Num, Power and Module should be more than 0!");

            if (power == 0)
                return 1;

            byte[] BigIArray = power.ToByteArray();

            string binaryString = ConvertBytesToBinaryString(BigIArray);
            BigInteger[] table = new BigInteger[binaryString.Length];

            table[0] = num;

            for (int i = 1; i < binaryString.Length; ++i)
                table[i] = CalcNextValue(table[i - 1], binaryString[i], num, module);

            return table[table.Length - 1];
        }


        /*
         * This function needs to reduce complexity of 
         * code in the loop
         */ 
        private BigInteger CalcNextValue(BigInteger previous, char bit, BigInteger number, BigInteger module)
        {
            if (bit == '0')
                return previous * previous % module;
            else
                return previous * previous * number % module;
        }


        /*
         * Just use to do its job
         */ 
        private string ConvertBytesToBinaryString(byte[] array)
        {
            string result = "";

            foreach (var b in array)
                result += Convert.ToString(b, 2);

            return result;
        }
    }
}
