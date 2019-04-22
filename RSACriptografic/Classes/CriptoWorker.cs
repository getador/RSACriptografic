using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSACriptografic.Classes
{
    class CriptoWorker
    {
        uint p;
        uint q;
        uint n;
        uint m;
        uint d;
        double e;
        public CriptoWorker()
        {

        }
        public uint P { get => p; set => p = value; }
        public uint Q { get => q; set => q = value; }
        public uint N { get => n; set => n = value; }
        public uint M { get => m; set => m = value; }
        public uint D { get => d; set => d = value; }
        public double E { get => e; set => e = value; }
    }
}
