﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Guardian.Mutatio;
using Microsoft.VisualBasic.CompilerServices;
using static Guardian.ArithmeticOperator;

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

        public override string ToString()
        {
            string nums = "";
            for (int i = 0; i < Size; i++) 
                nums += Get(i) + ((Size > i + 1) ? "," : "");
            return $"{GetType().Name}<{nums}>";
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

        #region Basic Arithmetic Operators
        public static NTuple<TNum> operator +(NTuple<TNum> left, NTuple<TNum> right)
        {
            return new ArithmeticOutputTuple<TNum>(Addition, left, right);
        }

        public static NTuple<TNum> operator -(NTuple<TNum> left, NTuple<TNum> right)
        {
            return new ArithmeticOutputTuple<TNum>(Subtraction, left, right);
        }

        public static NTuple<TNum> operator *(NTuple<TNum> left, NTuple<TNum> right)
        {
            return new ArithmeticOutputTuple<TNum>(Multiplication, left, right);
        }

        public static NTuple<TNum> operator /(NTuple<TNum> left, NTuple<TNum> right)
        {
            return new ArithmeticOutputTuple<TNum>(Division, left, right);
        }

        public static NTuple<TNum> operator -(NTuple<TNum> tuple)
        {
            return new ArithmeticOutputTuple<TNum>(Negation, tuple, tuple);
        }

        public static implicit operator TNum[](NTuple<TNum> tuple)
        {
            var arr = new TNum[tuple.Size];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = tuple[i];
            return arr;
        }
        #endregion

        #region Advanced Arithmetic Operations
        public TNum Magnitude() { }
        public NTuple<TNum> Normalize() { }
        #endregion

        #region Conversion Methods
        public Vector<TNum> Vector() => this is Vector<TNum> ? (Vector<TNum>) this : new Vector<TNum>(this);
        public Vector2<TNum> Vector2() => this is Vector2<TNum> ? (Vector2<TNum>)this : new Vector2<TNum>(this);
        public Vector3<TNum> Vector3() => this is Vector3<TNum> ? (Vector3<TNum>)this : new Vector3<TNum>(this);
        public Vector4<TNum> Vector4() => this is Vector4<TNum> ? (Vector4<TNum>)this : new Vector4<TNum>(this);
        public Quaternion<TNum> Quaternion() => this is Quaternion<TNum> ? (Quaternion<TNum>)this : new Quaternion<TNum>(this);
        #endregion

        #region Arithmetic Helper Class
        private class ArithmeticOutputTuple<TOut> : NTuple<TOut> where TOut : unmanaged
        {
            protected internal ArithmeticOutputTuple(ArithmeticOperator op, NTuple<TOut> left, NTuple<TOut> right) : base(false, CreateStacks(op, left, right))
            {
            }

            private static RefStack<TOut>[] CreateStacks(ArithmeticOperator op, NTuple<TOut> left, NTuple<TOut> right)
            {
                var size = left.Size;
                /*
                if (size != right.Size)
                    throw new ArgumentException("NTuple cannot compute with different sizes!");
                */
                var stacks = new List<RefStack<TOut>>();
                for (int i = 0; i < size; i++)
                {
                    var leftStack = left.Stack(i);
                    var rightStack = right.Stack(i);
                    stacks.Add(new RefStack<TOut>(false) { Getter = () => op.Apply(leftStack.Get(), rightStack.Get())});
                }
                return stacks.ToArray();
            }
        }
        #endregion
    }
}
