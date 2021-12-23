using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Guardian.Mutatio
{
    public class ReferenceStore : ConcurrentDictionary<string, IReference>
    {
    }
}