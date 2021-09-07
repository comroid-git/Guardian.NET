using System;

namespace Guardian.Mutatio.Numerics
{
    public static class Extensions
    {
        public static TNum Apply<TNum>(this ArithmeticOperator op, TNum left, TNum right) where TNum : unmanaged
        {
            if (typeof(TNum) == typeof(byte))
                return (TNum) (object) op.Apply((byte) (object) left, (byte) (object) right);
            if (typeof(TNum) == typeof(sbyte))
                return (TNum) (object) op.Apply((sbyte) (object) left, (sbyte) (object) right);
            if (typeof(TNum) == typeof(ushort))
                return (TNum) (object) op.Apply((ushort) (object) left, (ushort) (object) right);
            if (typeof(TNum) == typeof(short))
                return (TNum) (object) op.Apply((short) (object) left, (short) (object) right);
            if (typeof(TNum) == typeof(uint))
                return (TNum) (object) op.Apply((uint) (object) left, (uint) (object) right);
            if (typeof(TNum) == typeof(int))
                return (TNum) (object) op.Apply((int) (object) left, (int) (object) right);
            if (typeof(TNum) == typeof(ulong))
                return (TNum) (object) op.Apply((ulong) (object) left, (ulong) (object) right);
            if (typeof(TNum) == typeof(long))
                return (TNum) (object) op.Apply((long) (object) left, (long) (object) right);
            if (typeof(TNum) == typeof(float))
                return (TNum) (object) op.Apply((float) (object) left, (float) (object) right);
            if (typeof(TNum) == typeof(double))
                return (TNum) (object) op.Apply((double) (object) left, (double) (object) right);
            return (TNum) (object) 0;
        }

        public static byte Apply(this ArithmeticOperator op, byte left, byte right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => (byte) (left + right),
                ArithmeticOperator.Subtraction => (byte) (left - right),
                ArithmeticOperator.Multiplication => (byte) (left * right),
                ArithmeticOperator.Division => (byte) (left / right),
                ArithmeticOperator.Negation => (byte) -left,
                ArithmeticOperator.SquareRoot => (byte) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static sbyte Apply(this ArithmeticOperator op, sbyte left, sbyte right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => (sbyte) (left + right),
                ArithmeticOperator.Subtraction => (sbyte) (left - right),
                ArithmeticOperator.Multiplication => (sbyte) (left * right),
                ArithmeticOperator.Division => (sbyte) (left / right),
                ArithmeticOperator.Negation => (sbyte) -left,
                ArithmeticOperator.SquareRoot => (sbyte) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static short Apply(this ArithmeticOperator op, short left, short right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => (short) (left + right),
                ArithmeticOperator.Subtraction => (short) (left - right),
                ArithmeticOperator.Multiplication => (short) (left * right),
                ArithmeticOperator.Division => (short) (left / right),
                ArithmeticOperator.Negation => (short) -left,
                ArithmeticOperator.SquareRoot => (short) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static ushort Apply(this ArithmeticOperator op, ushort left, ushort right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => (ushort) (left + right),
                ArithmeticOperator.Subtraction => (ushort) (left - right),
                ArithmeticOperator.Multiplication => (ushort) (left * right),
                ArithmeticOperator.Division => (ushort) (left / right),
                ArithmeticOperator.Negation => (ushort) -left,
                ArithmeticOperator.SquareRoot => (ushort) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static int Apply(this ArithmeticOperator op, int left, int right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => -left,
                ArithmeticOperator.SquareRoot => (int) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static uint Apply(this ArithmeticOperator op, uint left, uint right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => (uint) -left,
                ArithmeticOperator.SquareRoot => (uint) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static long Apply(this ArithmeticOperator op, long left, long right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => -left,
                ArithmeticOperator.SquareRoot => (long) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static ulong Apply(this ArithmeticOperator op, ulong left, ulong right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => throw new NotSupportedException("Cannot negate type ulong"),
                ArithmeticOperator.SquareRoot => (ulong) Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static float Apply(this ArithmeticOperator op, float left, float right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => -left,
                ArithmeticOperator.SquareRoot => MathF.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }

        public static double Apply(this ArithmeticOperator op, double left, double right)
        {
            return op switch
            {
                ArithmeticOperator.Addition => left + right,
                ArithmeticOperator.Subtraction => left - right,
                ArithmeticOperator.Multiplication => left * right,
                ArithmeticOperator.Division => left / right,
                ArithmeticOperator.Negation => -left,
                ArithmeticOperator.SquareRoot => Math.Sqrt(left),
                _ => throw new ArgumentException(nameof(op))
            };
        }
    }

    public enum ArithmeticOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,

        Negation,
        SquareRoot
    }
}