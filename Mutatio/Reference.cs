using System;
using System.Diagnostics.CodeAnalysis;

namespace Guardian.Mutatio
{
    public class Reference<T> : IAccessor<T>
    {
        private RefStack<T>[] _stack;
        private bool _mutable;

        public Reference(bool mutable = true, int initialSize = 1) : this(mutable, new RefStack<T>[initialSize])
        {
        }

        public Reference(bool mutable = true, params RefStack<T>[] stack)
        {
            _stack = stack;
            _mutable = mutable;
        }

        public int Size => _stack.Length;

        [MaybeNull]
        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        bool IMutableState.Mutable
        {
            get => _mutable;
            set => _mutable = value;
        }

        public T Get()
        {
            return Get(0);
        }

        public T Get(int index)
        {
            return Stack(index).Get();
        }

        public bool Set(T value, bool expandIfAbsent = false)
        {
            return Set(0, value, expandIfAbsent);
        }

        public bool Set(int index, T value, bool expandIfAbsent = false)
        {
            return Stack(index, expandIfAbsent).Set(value);
        }

        protected RefStack<T> Stack(int index, bool expandIfAbsent = false)
        {
            if (!expandIfAbsent && index >= _stack.Length)
                throw new IndexOutOfRangeException($"Index out of Range: {index}; Maximum: {_stack.Length}");
            else if (expandIfAbsent)
            {
                var swap = new RefStack<T>[index + 1];
                Array.Copy(_stack, swap, _stack.Length);
                _stack = swap;
            }
            return _stack[index];
        }
    }

    public class RefStack<T> : IAccessor<T>
    {
        public static readonly RefStack<object> Dummy = new RefStack<object>();
        public Func<T>? Getter;
        public Func<T, bool>? Setter;
        [MaybeNull]
        private T _value;
        private bool _mutable;

        public RefStack(bool mutable = true) : this(default(T)!, mutable)
        {
        }

        public RefStack([MaybeNull] T initialValue, bool mutable = true)
        {
            _value = initialValue;
            _mutable = mutable;
        }

        public T Get()
        {
            lock (this)
                return (Getter ?? (_Get))();
        }
        
        private T _Get()
        {
            return _value;
        }

        public bool Set(T value, bool expandIfAbsent = false)
        {
            lock (this)
                return (Setter ?? (_Set))(value);
        }

        private bool _Set(T value)
        {
            _value = value;
            return true;
        }

        bool IMutableState.Mutable
        {
            get => _mutable;
            set => _mutable = value;
        }
    }
}
