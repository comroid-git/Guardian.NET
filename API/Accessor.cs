using System;

namespace Guardian
{
    public interface IMutableState
    {
        bool Mutable { get; protected set; }
    }

    public interface IAccessor<T> : IMutableState
    {
        public bool Empty => Get() == null;

        public T Get();

        public bool Set(T value, bool expandIfAbsent = false);
    }
}