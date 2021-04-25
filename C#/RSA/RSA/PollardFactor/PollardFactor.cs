using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA.PollardFactor
{
    class PollardFactor
    {
        delegate BigInteger Polynom(BigInteger x, BigInteger number);

        /*
         * If you want to add new polynom
         * for algo you can put it here
         */
        Polynom[] polynoms = new Polynom[]
        {
            (x, number) => { return (x * x + 1) % number; },
            (x, number) => { return (x * x - 1) % number; }
        };


        public PollardFactor()
        { }

        
        /*
         * This method should start private 
         * GetOneDivider in the several Tasks
         * with different polynoms
         */ 
        public (BigInteger, BigInteger) GetOneDivider(BigInteger number)
        {
            int amountOfPolynoms = polynoms.Length;
            Task<(BigInteger, BigInteger)>[] tasks = new Task<(BigInteger, BigInteger)>[amountOfPolynoms];
            for (int i = 0; i < amountOfPolynoms; ++i)
            {
                int j = i; // need to properly closure function
                tasks[i] = new Task<(BigInteger, BigInteger)>(() => { return GetOneDivider( number, polynoms[j] ); } );
            }

            foreach (var task in tasks)
                task.Start();

            int taskIndex = Task.WaitAny(tasks);
            return tasks[taskIndex].Result;
        }


        /*
         * Find only one divider of number and amount of iterations,
         * this is main rho-pollard algo in this class
         */
        private (BigInteger, BigInteger) GetOneDivider(BigInteger number, Polynom NextX)
        {
            if (number < 2 || NextX == null)
                throw new Exception("GetOneDivider number < 2 or passed Polynom equal to null");
            BigInteger x = GetFirstX(number);
            BigInteger y = 1;
            BigInteger stage = 2;
            BigInteger iteration = 0;


            while (BigInteger.GreatestCommonDivisor(BigInteger.Abs(x - y), number) == 1)
            {
                if (iteration == stage )
                {
                    y = x;
                    stage *= 2;
                }
                x = NextX(x, number);
                ++iteration;
            }
            return (BigInteger.GreatestCommonDivisor(BigInteger.Abs(x - y), number), iteration);
        }


        /*
         * This function should give first X for 
         * Rho algorithm
         */
        private BigInteger GetFirstX(BigInteger number)
        {
            if (number < 2)
                throw new Exception("GetFirstX number should be more than 2");
            int numberLength = number.ToByteArray().Length;
            
            Random random = new Random();
            int randomNumberLength = random.Next(0, numberLength - 1);

            if (randomNumberLength == 0)
                return 2;
            
            RNGCryptoServiceProvider bytesRandomizer = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[randomNumberLength];
            bytesRandomizer.GetBytes(bytes);
            
            BigInteger result = new BigInteger(bytes);
            if (result >= number)
                throw new Exception("Randomed x >= number!");
            return result;
        }
    }
}
