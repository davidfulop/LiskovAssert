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
        LiskovAssert subject;

        [SetUp]
        public void SetUp()
        {
            subject = new LiskovAssert();
        }

        [Test]
        public void GetAllSubclassesOf_Gets_All_Subclasses_from_same_assembly()
        {
            var types = subject.GetAllSubclassesOf<A>();
            CollectionAssert.AreEquivalent(_ADerived, types);
        }

        [Test]
        public void InstantiateAll_returns_one_instance_for_each_type_supplied()
        {
            var result = subject.InstantiateAll<A>(_ADerived);
            Assert.IsInstanceOf(_ADerived[0], result[0]);
            Assert.IsInstanceOf(_ADerived[1], result[1]);
        }

        [Test]
        public void AssertNoDerivedClassThrows_does_not_throw_for_empty_action()
        {
            Action<A> action = a => {};
            Assert.DoesNotThrow(() => subject.AssertNoDerivedClassThrows(action, string.Empty));
        }
    }
}
