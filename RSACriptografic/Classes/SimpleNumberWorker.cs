using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACriptografic.Classes
{
    class SimpleNumberWorker
    {
        public static bool IsPrime(uint num)
        {
            if (num == 1) return false;
            if ((num % 2 == 0) && (num > 2)) return true;

            int divsCount = 1;

            for (int i = 1; i <= num/2; i++)
            {
                if (num % i == 0) divsCount++;
            }

            return divsCount == 2 ? true : false;
        }

        public static bool IsMutuallyPrimary(uint firstNum, uint secondNum)
        {
            uint n = firstNum < secondNum ? firstNum : secondNum;

            for (int i = 2; i < n; i++)
            {
                if ((firstNum % i == 0) && (secondNum % i == 0)) return false;
            }

            return true;
        }
    }
}
