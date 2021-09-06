using System;

namespace Guardian.Mutatio
{
    public interface IReference<T> : IAccessor<T> {}

    public class Reference<T> : IReference<T>
    {
    }
}
