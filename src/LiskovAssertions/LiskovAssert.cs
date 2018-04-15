using System;
using System.Linq;
using System.Reflection;

namespace LiskovAssertions
{
    public class LiskovAssert
    {
        public Type[] GetAllSubclassesOf<T>() where T : class
        {
            var asm = Assembly.GetAssembly(typeof(T));
            return asm.GetTypes().Where(t => t.IsSubclassOf(typeof(T))).ToArray();
        }
        
        public T[] InstantiateAll<T>(Type[] types)
        {
            return types.Select(t => Activator.CreateInstance(t)).Cast<T>().ToArray();
        }
    }
}
