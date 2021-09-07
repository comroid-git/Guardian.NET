using System;
using System.Collections.Generic;

namespace Guardian.Mutatio.Numerics
{
    public class Vector<TNum> : NTuple<TNum> where TNum : unmanaged
    {
        protected Vector(int n) : base(n)
        {
        }

        public Vector(NTuple<TNum> tuple) : base((tuple as IAccessor<TNum>).Mutable, tuple.Stack())
        {
        }

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

        #region Advanced Arithmetic Operations

        public TNum Magnitude()
        {
            var squares = new List<TNum>();
            for (var i = 0; i < Size; i++)
            {
                var v = Get(i);
                squares.Add(ArithmeticOperator.Multiplication.Apply(v, v));
            }

            var sqsum = squares[0];
            for (var i = 1; i < Size; i++)
                sqsum = ArithmeticOperator.Addition.Apply(sqsum, squares[i]);
            return ArithmeticOperator.SquareRoot.Apply(sqsum, sqsum);
        }

        public Vector<TNum> Normalize()
        {
            return (this / Magnitude()).Vector();
        }

        #endregion
    }

    #region Vector2 Types

    public class Vector2<TNum> : Vector<TNum> where TNum : unmanaged
    {
        public Vector2(TNum x, TNum y) : base(2)
        {
            if (Size != 2)
                throw new ArgumentException("Illegal Vector2 Size: " + Size);
            X = x;
            Y = y;
        }

        public Vector2(NTuple<TNum> tuple) : base(tuple)
        {
        }
    }

    public class Vector2i : Vector2<int>
    {
        public static readonly Vector2i Zero = new Vector2i(0, 0);
        public static readonly Vector2i One = new Vector2i(1, 1);
        public static readonly Vector2i Up = new Vector2i(0, 1);
        public static readonly Vector2i Right = new Vector2i(1, 0);

        public Vector2i(int x, int y) : base(x, y)
        {
        }

        public Vector2i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector2f : Vector2<float>
    {
        public static readonly Vector2f Zero = new Vector2f(0, 0);
        public static readonly Vector2f One = new Vector2f(1, 1);
        public static readonly Vector2f Up = new Vector2f(0, 1);
        public static readonly Vector2f Right = new Vector2f(1, 0);

        public Vector2f(float x, float y) : base(x, y)
        {
        }

        public Vector2f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector2d : Vector2<double>
    {
        public static readonly Vector2d Zero = new Vector2d(0, 0);
        public static readonly Vector2d One = new Vector2d(1, 1);
        public static readonly Vector2d Up = new Vector2d(0, 1);
        public static readonly Vector2d Right = new Vector2d(1, 0);

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
            if (Size != 3)
                throw new ArgumentException("Illegal Vector3 Size: " + Size);
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
        public static readonly Vector3i Zero = new Vector3i(0, 0, 0);
        public static readonly Vector3i One = new Vector3i(1, 1, 1);
        public static readonly Vector3i Up = new Vector3i(0, 1, 0);
        public static readonly Vector3i Right = new Vector3i(1, 0, 0);
        public static readonly Vector3i Forward = new Vector3i(0, 0, 1);

        public Vector3i(int x, int y, int z) : base(x, y, z)
        {
        }

        public Vector3i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector3f : Vector3<float>
    {
        public static readonly Vector3f Zero = new Vector3f(0, 0, 0);
        public static readonly Vector3f One = new Vector3f(1, 1, 1);
        public static readonly Vector3f Up = new Vector3f(0, 1, 0);
        public static readonly Vector3f Right = new Vector3f(1, 0, 0);
        public static readonly Vector3f Forward = new Vector3f(0, 0, 1);

        public Vector3f(float x, float y, float z) : base(x, y, z)
        {
        }

        public Vector3f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector3d : Vector3<double>
    {
        public static readonly Vector3d Zero = new Vector3d(0, 0, 0);
        public static readonly Vector3d One = new Vector3d(1, 1, 1);
        public static readonly Vector3d Up = new Vector3d(0, 1, 0);
        public static readonly Vector3d Right = new Vector3d(1, 0, 0);
        public static readonly Vector3d Forward = new Vector3d(0, 0, 1);

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

        public Vector4(TNum w, TNum x, TNum y, TNum z) : base(4)
        {
            if (Size != 4)
                throw new ArgumentException("Illegal Vector4 Size: " + Size);
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public Vector4(NTuple<TNum> tuple) : base(tuple)
        {
        }

        public RefStack<TNum> StackW => Stack(IndexW);

        public TNum W
        {
            get => StackW.Get();
            set => StackW.Set(value);
        }
    }

    public class Vector4i : Vector4<int>
    {
        public static readonly Vector4i Zero = new Vector4i(0, 0, 0, 0);
        public static readonly Vector4i One = new Vector4i(1, 1, 1, 1);
        public static readonly Vector4i Up = new Vector4i(0, 0, 1, 0);
        public static readonly Vector4i Right = new Vector4i(0, 1, 0, 0);
        public static readonly Vector4i Forward = new Vector4i(0, 0, 0, 1);
        public static readonly Vector4i Next = new Vector4i(1, 0, 0, 0);

        public Vector4i(int w, int x, int y, int z) : base(w, x, y, z)
        {
        }

        public Vector4i(NTuple<int> tuple) : base(tuple)
        {
        }
    }

    public class Vector4f : Vector4<float>
    {
        public static readonly Vector4f Zero = new Vector4f(0, 0, 0, 0);
        public static readonly Vector4f One = new Vector4f(1, 1, 1, 1);
        public static readonly Vector4f Up = new Vector4f(0, 0, 1, 0);
        public static readonly Vector4f Right = new Vector4f(0, 1, 0, 0);
        public static readonly Vector4f Forward = new Vector4f(0, 0, 0, 1);
        public static readonly Vector4f Next = new Vector4f(1, 0, 0, 0);

        public Vector4f(float w, float x, float y, float z) : base(w, x, y, z)
        {
        }

        public Vector4f(NTuple<float> tuple) : base(tuple)
        {
        }
    }

    public class Vector4d : Vector4<double>
    {
        public static readonly Vector4d Zero = new Vector4d(0, 0, 0, 0);
        public static readonly Vector4d One = new Vector4d(1, 1, 1, 1);
        public static readonly Vector4d Up = new Vector4d(0, 0, 1, 0);
        public static readonly Vector4d Right = new Vector4d(0, 1, 0, 0);
        public static readonly Vector4d Forward = new Vector4d(0, 0, 0, 1);
        public static readonly Vector4d Next = new Vector4d(1, 0, 0, 0);

        public Vector4d(double w, double x, double y, double z) : base(w, x, y, z)
        {
        }

        public Vector4d(NTuple<double> tuple) : base(tuple)
        {
        }
    }

    #endregion
}