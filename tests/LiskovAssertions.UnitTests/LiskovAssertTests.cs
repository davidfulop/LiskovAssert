using NUnit.Framework;
using System;
using LiskovAssertions;
using System.Collections.Generic;

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

        [Test]
        public void AssertNoDerivedClassThrows_throws_AggregateException_when_action_throws()
        {
            Action<A> action = a => throw new ApplicationException();
            Assert.Throws<AggregateException>(() => subject.AssertNoDerivedClassThrows(action, string.Empty));
        }

        [Test]
        public void AssertNoDerivedClassThrows_AggregateException_contains_all_exceptions()
        {
            Action<A> action = a => throw new ApplicationException();
            var aggrex = Assert.Throws<AggregateException>(() => subject.AssertNoDerivedClassThrows(action, string.Empty));
            Assert.AreEqual(_ADerived.Length, aggrex.InnerExceptions.Count);
        }
        
        [Test]
        public void AssertNoDerivedClassThrows_exception_contains_original_exceptions()
        {
            List<Exception> exceptions = new List<Exception>();
            Action<A> action = a => throw GetAndStoreException();
            var aggrex = Assert.Throws<AggregateException>(() => subject.AssertNoDerivedClassThrows(action, string.Empty));
            CollectionAssert.AreEquivalent(exceptions, aggrex.InnerExceptions);
            
            Exception GetAndStoreException()
            {
                Exception ex = new ApplicationException(DateTime.UtcNow.Ticks.ToString());
                exceptions.Add(ex);
                return ex;
            }
        }
        
        [Test]
        public void AssertNoDerivedClassThrows_set_exception_message_is_returned()
        {
            string message = "almabeka";
            Action<A> action = a => throw new ApplicationException();
            var aggrex = Assert.Throws<AggregateException>(() => subject.AssertNoDerivedClassThrows(action, message));
            StringAssert.StartsWith(message, aggrex.Message);

        }
    }
}
