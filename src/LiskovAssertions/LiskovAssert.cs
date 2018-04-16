using System;
using System.Collections.Generic;
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

        public void AssertNoDerivedClassThrows<T>(Action<T> action, string message) where T : class
        {
            List<Exception> exceptions = new List<Exception>();
            T[] subjects = InstantiateAll<T>(GetAllSubclassesOf<T>());
            foreach (T subject in subjects)
            {
                try
                {
                    action(subject);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);                    
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(message, exceptions);
            }
        }
    }
}
