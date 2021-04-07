using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerAndFastPower
{
    /*
     * Provide base api to all primary testers
     */
    interface IPrimaryTester
    {
        bool TestPrime(BigInteger number);
    }
}
