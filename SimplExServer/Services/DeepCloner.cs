using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SimplExServer.Services
{
    static class DeepCloner
    {
        private static readonly MethodInfo CloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
        internal static T Clone<T>(T original) => (T)InternalCopy(original, new Dictionary<object, object>(new ReferenceEqualityComparer()));
        private static bool IsPrimitive(this Type type) => type == typeof(string) ? true : (type.IsValueType && type.IsPrimitive);
        private static object InternalCopy(object originalObject, IDictionary<object, object> visited)
        {
            if (originalObject == null)
                return null;
            Type reflectedType = originalObject.GetType();
            if (IsPrimitive(reflectedType))
                return originalObject;
            if (visited.ContainsKey(originalObject))
                return visited[originalObject]; 
            if (typeof(Delegate).IsAssignableFrom(reflectedType)) 
                return null;
            object clonedObject = CloneMethod.Invoke(originalObject, null);
            if (reflectedType.IsArray)
                if (IsPrimitive(reflectedType.GetElementType()) == false)
                {
                    Array clonedArray = (Array)clonedObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                }
            visited.Add(originalObject, clonedObject);
            CopyFields(originalObject, visited, clonedObject, reflectedType);
            CopyBaseTypeFields(originalObject, visited, clonedObject, reflectedType);
            return clonedObject;
        }
        private static void CopyBaseTypeFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType == null)
                return;
            CopyBaseTypeFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
            CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
        }
        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object clonedObject, Type reflectedType, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (FieldInfo fieldInfo in reflectedType.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false)
                    continue;
                if (IsPrimitive(fieldInfo.FieldType))
                    continue;
                object originalFieldValue = fieldInfo.GetValue(originalObject);
                object clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(clonedObject, clonedFieldValue);
            }
        }
        private static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0)
                return;
            ArrayWalker walker = new ArrayWalker(array);
            do action(array, walker.position);
            while (walker.Step());
        }
        private class ReferenceEqualityComparer : EqualityComparer<Object>
        {
            public override bool Equals(object x, object y) => ReferenceEquals(x, y);
            public override int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
        }
        private class ArrayWalker
        {
            public int[] position;
            private int[] maxLengths;
            public ArrayWalker(Array array)
            {
                maxLengths = new int[array.Rank];
                for (int i = 0; i < array.Rank; ++i)
                    maxLengths[i] = array.GetLength(i) - 1;
                position = new int[array.Rank];
            }
            public bool Step()
            {
                for (int i = 0; i < position.Length; ++i)
                    if (position[i] < maxLengths[i])
                    {
                        position[i]++;
                        for (int j = 0; j < i; j++)
                            position[j] = 0;
                        return true;
                    }
                return false;
            }
        }
    }
}
