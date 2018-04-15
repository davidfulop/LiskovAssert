using NUnit.Framework;
using System;
using LiskovAssertions;

namespace LiskovAssertions.UnitTests
{
    class A { }
    class A1 : A { }
    class A2 : A { }

    public class LiskovAssertTests
    {
        Type[] _ADerived = new Type[] { typeof(A1), typeof(A2) };
        
        [Test]
        public void GetAllSubclassesOf_Gets_All_Subclasses_from_same_assembly()
        {
            LiskovAssert subject = new LiskovAssert();
            var types = subject.GetAllSubclassesOf<A>();
            CollectionAssert.AreEquivalent(_ADerived, types);
        }
    }
}
