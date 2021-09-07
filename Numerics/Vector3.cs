using System;
using System.Runtime.CompilerServices;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class Vector3<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        public const int IndexX = 0;
        public const int IndexY = 1;
        public const int IndexZ = 2;

        public RefStack<TNum> StackX => Stack(IndexX);
        public RefStack<TNum> StackY => Stack(IndexY);
        public RefStack<TNum> StackZ => Stack(IndexZ);

        public TNum X
        {
            get => StackX.Get();
            set => StackX.Set(value);
        }

        public TNum Y
        {
            get => StackY.Get();
            set => StackY.Set(value);
        }

        public TNum Z
        {
            get => StackZ.Get();
            set => StackZ.Set(value);
        }

        public Vector3(TNum x, TNum y, TNum z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
