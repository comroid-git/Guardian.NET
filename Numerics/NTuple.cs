using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Guardian.Mutatio;
using Microsoft.VisualBasic.CompilerServices;

namespace Guardian.Numerics
{
    public class NTuple<TNum> : Reference<TNum> where TNum : unmanaged
    {
        public NTuple(int n) : base(true, n)
        {
        }

        protected NTuple(bool mutable = true, params RefStack<TNum>[] stack) : base(mutable, stack)
        {
        }

        public NTuple<TOut> CastTuple<TOut>() where TOut : unmanaged // todo: TEST!
        {
            var stacks = new List<RefStack<TOut>>();
            for (int i = 0; i < Size; i++)
            {
                var i1 = i;
                stacks.Add(new RefStack<TOut>(false) { Getter = () => (TOut)(object)this[i1] });
            }

            return new NTuple<TOut>(false, stacks.ToArray());
        }

        public static NTuple<TNum> operator +(NTuple<TNum> left, NTuple<TNum> right)
        {
            return left.Plus(right);
        }
    }
}
