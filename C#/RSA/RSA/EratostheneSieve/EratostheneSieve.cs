using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

// this typedef also defined in form, so if want to change it, change in form too
using Int = System.Int64;

namespace EulerAndFastPower.EratostheneSieve
{
    class EratostheneSieve
    {

        bool[] primarityTable;
        Int topBound;
        List<Int> result;

        public EratostheneSieve()
        { }


        /*
         * This method make boolean table 
         * and convert all 'true' values in boolean
         * table( true represents as prime number )
         * and convert table into Int[]
         */
        public List<Int> FindPrimes(Int topBound)
        {
            if (topBound <= 0)
                throw new Exception("top bound should be more than 0!");

            if (topBound == 1)
                return new List<Int>() { };

            if (topBound == 2)
                return new List<Int>() { 2 };

            // to include max value to list
            topBound++;

            result = new List<Int>();
            primarityTable = GetPrimarityTable(topBound);
            this.topBound = topBound;

            for (Int currentNumber = 2; currentNumber < topBound; ++currentNumber)
                if (primarityTable[currentNumber] != false)
                    RemoveMultipliersAsync(currentNumber);

            FormResultFromTable();
            return result;
        }


        /*
         * Return boolean array where all number marked
         * as true, so in next functions when not prime
         * number will be find true will be overrided by
         * false
         */
        private bool[] GetPrimarityTable(Int topBound)
        {
            bool[] result = new bool[topBound];

            result[0] = false;
            result[1] = false;

            for (Int i = 2; i < topBound; ++i)
                result[i] = true;
            return result;
        }


        /*
         * Just invoke RemoveMultiopliers in another thread
         */
        private void RemoveMultipliersAsync(Int number)
        {
            Thread t = new Thread(new ThreadStart( () => RemoveMultipliers(number) ));
            t.Start();
        }
        
        
        /*
         * Mark all multipled values of 'number' in
         * the primarity table by false
         */
        private void RemoveMultipliers(Int primeNumber)
        {
            for (Int multiplier = primeNumber; multiplier * primeNumber < topBound; ++multiplier)
            {
                Int notPrimeNumber = primeNumber * multiplier;
                primarityTable[notPrimeNumber] = false;
            }
        }


        /*
         * Convert boolean arrays to Int[] with 
         * prime numbers
         */
        private void FormResultFromTable()
        {
            for (Int currentNumber = 2; currentNumber < topBound; ++currentNumber)
                if (primarityTable[currentNumber])
                    result.Add(currentNumber);
        }
    }
}
