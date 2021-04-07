using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAndFastPower
{
    /*
     * Just class that contain 3 values 
     * that should be returned form Extended GCD
     * You may delete it and use 3 features(X, Y, Nod) in ExtendedGCD
     */
    class ExtendedGCDResult
    {
        BigInteger x;
        BigInteger y;
        BigInteger nod;


        public ExtendedGCDResult(BigInteger x, BigInteger y, BigInteger nod)
        {
            this.x = x;
            this.y = y;
            this.nod = nod;
        }

        
        public BigInteger X { get { return x; } }
        public BigInteger Y { get { return y; } }
        public BigInteger Nod { get { return nod; } }

    }
}
