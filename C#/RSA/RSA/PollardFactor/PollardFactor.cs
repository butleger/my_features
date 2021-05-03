using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA.PollardFactor
{
    class PollardFactor
    {
        delegate BigInteger Polynom(BigInteger x, BigInteger number);

        Polynom defaultPolynom = (x, number) => { return (BigInteger.Pow(x, 2) - 1) % number; };

        /*
         * If you want to add new polynom
         * for algo you can put it here
         */
        Polynom[] polynoms = new Polynom[]
        {
            (x, number) => { return (BigInteger.Pow(x, 2) + 1) % number; }, // Pow used for optimisation
            (x, number) => { return (BigInteger.Pow(x, 2) - 1) % number; }  // here too
        };


        public PollardFactor()
        { }

        
        /*
         * This method should calculate time
         * for all posible optimization and return results 
         * of iterations and first divider
         */ 
        public (BigInteger, BigInteger) GetOneDivider(BigInteger number, Logger timeLog)
        {
            Task[] tasks;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var (iterations, divider) = NoOptimization(number);
            timer.Stop();
            string timeReport = GetReport(
                timer.Elapsed,
                number,
                divider,
                iterations
            );
            timeLog.Log($"None optimiztion:\n {timeReport}");

            timer = new Stopwatch();
            timer.Start();
            (iterations, divider, tasks) = CutOptimization(number);
            timer.Stop();
            
            timeReport = GetReport(
                timer.Elapsed,
                number,
                divider,
                iterations
            );
            timeLog.Log($"Cut optimiztion:\n {timeReport}");
            Task.WaitAll(tasks);

            timer = new Stopwatch();
            timer.Start();
            (iterations, divider, tasks) = PolynomOptimization(number);
            timer.Stop();
            timeReport = GetReport(
                timer.Elapsed,
                number,
                divider,
                iterations
            );
            timeLog.Log($"Polynomical optimiztion:\n {timeReport}");
            Task.WaitAll(tasks);
            return (iterations, divider);
        }


        /*
         * Incapsulate preparation of report 
         */
        private string GetReport(TimeSpan calcTime, BigInteger number, BigInteger divider, BigInteger iterations)
        {
            string factorReport = "";

            factorReport = $"Time : \n";
            factorReport += $"   {calcTime.Minutes} min \n";
            factorReport += $"   {calcTime.Seconds} sec \n";
            factorReport += $"   {calcTime.Milliseconds} ms \n";
            factorReport += $"Iterations : {iterations} \n";
            factorReport += $"Factors : {number} = {divider} * {number / divider} \n";

            return factorReport;
        }


        /*
         * No optimization at all, need just for comparison between
         * other optimizations
         */
        private (BigInteger, BigInteger) NoOptimization(BigInteger number)
        {
            return GetOneDivider(number, defaultPolynom, GetFirstX(number));
        }


        /*
         * This method call rho algo with 
         * different polynoms in different
         * tasks, tasks returned to destruct 
         * another tasks in caller-method
         */
        private (BigInteger,BigInteger, Task[]) PolynomOptimization(BigInteger number)
        {
            int amountOfPolynoms = polynoms.Length;
            Task<(BigInteger, BigInteger)>[] tasks = new Task<(BigInteger, BigInteger)>[amountOfPolynoms];
            
            for (int i = 0; i < amountOfPolynoms; ++i)
            {
                BigInteger firstX = GetFirstX(number);
                int j = i; // need to properly closure function
                tasks[i] = new Task<(BigInteger, BigInteger)>(() => { 
                    return GetOneDivider( number, polynoms[j], firstX ); 
                });
            }

            foreach (var task in tasks)
                task.Start();

            int taskIndex = Task.WaitAny(tasks);
            var (iter, div) = tasks[taskIndex].Result;
            return (iter, div, tasks);
        }


        /*
         * Divide all possible numbers (1 - (number - 1)) into parts 
         * and put first x for rho algo in theese parts, and call 
         * rho algo with different one polynom and 
         */
        private (BigInteger, BigInteger, Task[]) CutOptimization(BigInteger number)
        {
            int amountOfParts = 4;
            BigInteger partSize = number / amountOfParts;
            Task<(BigInteger, BigInteger)>[] partedTasks = new Task<(BigInteger, BigInteger)>[amountOfParts];
            BigInteger[] firstExes = new BigInteger[amountOfParts];
            
            for (int i = 0; i < firstExes.Length; ++i)
            {
                firstExes[i] = GetFirstX(partSize * i, partSize * (i + 1)); // generate number between parts
            }

            for (int i = 0; i < partedTasks.Length; ++i)
            {
                int j = i; // for good lambda binding
                partedTasks[i] = new Task<(BigInteger, BigInteger)>(() =>
                {
                    return GetOneDivider(number, defaultPolynom, firstExes[j]);
                });
                partedTasks[i].Start();
            }

            int taskIndex = Task.WaitAny(partedTasks);
            var (iter, div) = partedTasks[taskIndex].Result;
            return (iter, div, partedTasks);
        }


        /*
         * Find only one divider of number and amount of iterations,
         * this is main rho-pollard algo in this class
         */
        private (BigInteger, BigInteger) GetOneDivider(BigInteger number, Polynom NextX, BigInteger firstX)
        {
            if (number < 2 || NextX == null)
                throw new Exception("GetOneDivider number < 2 or passed Polynom equal to null");
            BigInteger x = firstX;
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
        private BigInteger GetFirstX(BigInteger max)
        {
            if (max < 2)
                throw new Exception("GetFirstX number should be more than 2");
            int numberLength = max.ToByteArray().Length;
            
            Random random = new Random();
            int randomNumberLength = random.Next(0, numberLength - 1);

            if (randomNumberLength == 0)
                return 2;
            
            RNGCryptoServiceProvider bytesRandomizer = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[randomNumberLength];
            bytesRandomizer.GetBytes(bytes);
            
            BigInteger result = new BigInteger(bytes);
            if (result >= max)
                throw new Exception("Randomed x >= number!");
            return result;
        }


        private BigInteger GetFirstX(BigInteger min, BigInteger max)
        {
            BigInteger salt = GetFirstX(max - min);
            return min + salt;
        }
    }
}
