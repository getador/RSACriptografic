using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACriptografic.Classes
{
    class CriptoWorker
    {
        Random random;
        uint p;
        uint q;
        uint n;
        uint m;
        uint d;
        double e;

        public CriptoWorker(int maxValue)
        {
            if (maxValue<2)
            {
                maxValue = 3;
            }
            p = 0;
            q = 0;
            while (p==0)
            {
                p = (uint)random.Next(2,maxValue);
            }
            while (q==0)
            {
                q = (uint)random.Next(2, maxValue);
            }
            n = p * q;
            m = (p - 1) * (q - 1);
            d = 0;
            e = FindEelement();
        }

        public uint FindEelement()
        {
            uint element = 0;
            for (int i = 0; i < m; i++)
            {
                if ((e*d)%m==1)
                {
                    element = (uint)i;
                    break;
                }
            }
            return element;
        }

        public uint P { get => p; set => p = value; }
        public uint Q { get => q; set => q = value; }
        public uint M { get => m; set => m = value; }
        public uint D { get => d; set => d = value; }
        public double E { get => e; set => e = value; }
        public uint N { get => n; set => n = value; }
    }
}
