using System;
using System.Collections.Generic;
using System.Text;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class NTuple<TNum> : Reference<TNum> where TNum : unmanaged
    {
        public NTuple(int n) : base(true, n)
        {
        }
    }
}
