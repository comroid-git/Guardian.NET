using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Guardian.Mutatio;
using Microsoft.VisualBasic.CompilerServices;

namespace Guardian.Numerics
{
    public abstract class NTuple<TNum> : Reference<TNum> where TNum : unmanaged
    {
        public NTuple(int n) : base(true, n)
        {
        }
    }
}
