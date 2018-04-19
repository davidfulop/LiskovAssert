using NUnit.Framework;
using LiskovAssertions;
using ExampleLib;

namespace ExampleLib.UnitTests
{
    public class CatTests
    {
        const string MEOW = "Meow";
        const string HISS = "KHII";

        Cat cat;

        [SetUp]
        public void SetUp()
        {
            cat = new Cat();
        }

        [TestCase(Food.HumanFood, HISS)]
        [TestCase(Food.DryCatFood, MEOW)]
        [TestCase(Food.CannedCatFood, MEOW)]
        public void It_returns_valid_response_for_foods(Food food, string reply)
        {            
            string result = cat.Feed(food);

            Assert.That(result == reply);
        }

        // Liskov assertion for the behaviour of the Feed method
        [TestCase(Food.HumanFood)]
        [TestCase(Food.DryCatFood)]
        [TestCase(Food.CannedCatFood)]
        public void All_derived_return_string_for_valid_input(Food food)
        {
            Liskov.AssertNoDerivedClassThrows<Cat>(cat => cat.Feed(food), "Argh!");
        }
    }
}
