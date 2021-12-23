using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using HarmonyLib;

namespace Guardian.Mutatio
{
    public interface IRefDescriptor
    {
    }

    public sealed class RefAttribute : Attribute, IRefDescriptor
    {
    }

    public interface IReference
    {
        int Size { get; }
        object? this[int index] { get; set; }
        object? Get(int index);
        bool Set(int index, object? value, bool expandIfAbsent = false);
    }

    public class Reference<T> : IAccessor<T>, IReference
    {
        private static readonly Harmony _harmony = new Harmony("Guardian.Mutatio.Reference");
        public static unsafe void PatchClass(object obj)
        {
            Type type = obj.GetType();
            FieldInfo refsFld = type.GetField("Refs") ?? throw new InvalidOperationException("No ReferenceStore named 'Refs' found in type " + type);
            ReferenceStore refs = (refsFld.GetValue(obj) as ReferenceStore)!;
            foreach (var prop in type.GetProperties().Where(it => it.GetCustomAttributes(false).Any(it => it is RefAttribute)))
            {
                if (!(prop.GetCustomAttributes(false).First(it => it is RefAttribute) is RefAttribute attr))
                    continue;
                
            }
        }

        [HarmonyPatch(MethodType.Getter)]
        public static object? _PatchedGet(T __instance)
        {
            Type type = __instance!.GetType();
            FieldInfo refsFld = type.GetField("Refs") ?? throw new InvalidOperationException("No ReferenceStore named 'Refs' found in type " + type);
            ReferenceStore refs = (refsFld.GetValue(__instance) as ReferenceStore)!;
        }

        [HarmonyPatch(MethodType.Setter)]
        public static bool _PatchedSet(T __instance, int index, object? value, bool expandIfAbsent = false)
        {
            Type type = __instance!.GetType();
            FieldInfo refsFld = type.GetField("Refs") ?? throw new InvalidOperationException("No ReferenceStore named 'Refs' found in type " + type);
            ReferenceStore refs = (refsFld.GetValue(__instance) as ReferenceStore)!;
        }
        
        private RefStack<T>[] _stack;
        private bool _mutable;

        public Reference(bool mutable = true, int initialSize = 1) : this(mutable, new RefStack<T>[initialSize])
        {
        }

        public Reference(bool mutable = true, params RefStack<T>[] stack)
        {
            for (var i = 0; i < stack.Length; i++)
                if (stack[i] == null)
                    stack[i] = new RefStack<T>(mutable);
            _stack = stack;
            _mutable = mutable;
        }

        public int Size => _stack.Length;
        object? IReference.this[int index]
        {
            get => _stack[index].Get();
            set => _stack[index].Set((value is T ? (T)value : default) ?? throw new ArgumentException("Invalid Value; incompatible to " + typeof(T)));
        }

        object? IReference.Get(int index) => _stack[index].Get();

        public bool Set(int index, object? value, bool expandIfAbsent = false)
        {
            _stack[index].Set((value is T ? (T)value : default) ??
                              throw new ArgumentException("Invalid Value; incompatible to " + typeof(T)));
            return true;
        }

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

        public RefStack<T>[] Stack() => _stack;

        public RefStack<T> Stack(int index, bool expandIfAbsent = false)
        {
            if (!expandIfAbsent && index >= _stack.Length)
                return RefStack<T>.Empty<T>();
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
            get => _mutable && (Getter != null ? Setter != null : true);
            set => _mutable = value;
        }

        public static RefStack<T> Empty<T>()
        {
            return new RefStack<T>(false);
        }
    }
}
