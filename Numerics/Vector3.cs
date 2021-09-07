using System.Runtime.CompilerServices;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class Vector3<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        public const int IndexX = 0;
        public const int IndexY = 1;
        public const int IndexZ = 2;

        public TNum X
        {
            get => Get(IndexX);
            set => Set(IndexX, value);
        }

        public TNum Y
        {
            get => Get(IndexY);
            set => Set(IndexY, value);
        }

        public TNum Z
        {
            get => Get(IndexZ);
            set => Set(IndexZ, value);
        }

        public Vector3(TNum x, TNum y, TNum z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
