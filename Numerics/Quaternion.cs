using System;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class Quaternion<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        public Quaternion(TNum x, TNum y, TNum z, TNum w) : base(4)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion(NTuple<TNum> tuple) : base((tuple as IAccessor<TNum>).Mutable, tuple.Stack())
        {
            if (Size != 4)
                throw new ArgumentException("Illegal Quaternion Size: " + Size);
        }

        #region X Y Z W Accessors

        public const int IndexX = 0;
        public const int IndexY = 1;
        public const int IndexZ = 2;
        public const int IndexW = 3;

        public RefStack<TNum> StackX => Stack(IndexX);
        public RefStack<TNum> StackY => Stack(IndexY);
        public RefStack<TNum> StackZ => Stack(IndexZ);
        public RefStack<TNum> StackW => Stack(IndexW);

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

        public TNum W
        {
            get => StackW.Get();
            set => StackW.Set(value);
        }

        #endregion

        #region Advanced Arithmetic Accessors

        /*
        public Vector3 Forward() => new Vector3(
            2 * (this.X * this.Z + this.W * this.Y),
            2 * (this.Y * this.Z - this.W * this.X),
            1 - 2 * (this.X * this.X + this.Y * this.Y)
        );

        public Vector3 Up() => new Vector3(
            2 * (this.X * this.Y - this.W * this.Z),
            1 - 2 * (this.X * this.X + this.Z * this.Z),
            2 * (this.Y * this.Z + this.W * this.X)
        );

        public Vector3 Left() => new Vector3(
            1 - 2 * (this.Y * this.Y + this.Z * this.Z),
            2 * (this.X * this.Y + this.W * this.Z),
            2 * (this.X * this.Z - this.W * this.Y)
        );
        */

        #endregion
    }

    #region Subtypes

    public class QuaternionF : Quaternion<float>
    {
        public QuaternionF(float x, float y, float z, float w) : base(x, y, z, w)
        {
        }
    }

    public class QuaternionD : Quaternion<double>
    {
        public QuaternionD(double x, double y, double z, double w) : base(x, y, z, w)
        {
        }
    }

    #endregion
}