using System;
using System.Runtime.CompilerServices;
using Guardian.Mutatio;

namespace Guardian.Numerics
{
    public class Vector<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        #region X Y Z Accessors
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
        #endregion

        protected Vector(int n) : base(n)
        {
        }

        public Vector(NTuple<TNum> tuple) : base((tuple as IAccessor<TNum>).Mutable, tuple.Stack()) {}
    }

    #region Vector2 Types
    public class Vector2<TNum> : Vector<TNum> where TNum : unmanaged
    {
        public Vector2(TNum x, TNum y) : base(2)
        {
            X = x;
            Y = y;
        }

        public Vector2(NTuple<TNum> tuple) : base(tuple)
        {
        }
    }

    public class Vector2i : Vector2<int>
    {
        public Vector2i(int x, int y) : base(x, y)
        {
        }

        public Vector2i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector2f : Vector2<float>
    {
        public Vector2f(float x, float y) : base(x, y)
        {
        }

        public Vector2f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector2d : Vector2<double>
    {
        public Vector2d(double x, double y) : base(x, y)
        {
        }

        public Vector2d(NTuple<double> tuple) : base(tuple)
        {
        }
    }
    #endregion

    #region Vector3 Types
    public class Vector3<TNum> : Vector<TNum> where TNum : unmanaged
    {
        public Vector3(TNum x, TNum y, TNum z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(NTuple<TNum> tuple) : base(tuple)
        {
        }
    }

    public class Vector3i : Vector3<int>
    {
        public Vector3i(int x, int y, int z) : base(x, y, z)
        {
        }

        public Vector3i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector3f : Vector3<float>
    {
        public Vector3f(float x, float y, float z) : base(x, y, z)
        {
        }

        public Vector3f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector3d : Vector3<double>
    {
        public Vector3d(double x, double y, double z) : base(x, y, z)
        {
        }

        public Vector3d(NTuple<double> tuple) : base(tuple)
        {
        }
    }
    #endregion

    #region Vector4 Types
    public class Vector4<TNum> : Vector<TNum> where TNum : unmanaged
    {
        public const int IndexW = 3;

        public RefStack<TNum> StackW => Stack(IndexW);

        public TNum W
        {
            get => StackW.Get();
            set => StackW.Set(value);
        }

        public Vector4(TNum w, TNum x, TNum y, TNum z) : base(4)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public Vector4(NTuple<TNum> tuple) : base(tuple)
        {
        }
    }

    public class Vector4i : Vector4<int>
    {
        public Vector4i(int w, int x, int y, int z) : base(w, x, y, z)
        {
        }

        public Vector4i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector4f : Vector4<float>
    {
        public Vector4f(float w, float x, float y, float z) : base(w, x, y, z)
        {
        }

        public Vector4f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector4d : Vector4<double>
    {
        public Vector4d(double w, double x, double y, double z) : base(w, x, y, z)
        {
        }

        public Vector4d(NTuple<double> tuple) : base(tuple)
        {
        }
    }
    #endregion
}
