using System;

namespace Guardian.Mutatio
{
    public class Reference<T> : IAccessor<T>
    {
        public RefStack<T>[] Stack => _stack;
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
            return Stack[index].Get();
        }

        public bool Set(T value)
        {
            return Set(0, value);
        }

        public bool Set(int index, T value)
        {
            return Stack[index].Set(value);
        }
    }

    public class RefStack<T> : IAccessor<T>
    {
        public static readonly RefStack<object> Dummy = new RefStack<object>();
        public Func<T>? Getter;
        public Func<T, bool>? Setter;
        private T _value;
        private bool _mutable;

        public RefStack() : this(default(T)!)
        {
        }

        public RefStack(T initialValue, bool mutable = true)
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

        public bool Set(T value)
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
