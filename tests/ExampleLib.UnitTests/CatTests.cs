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

        [Test]
        public void She_returns_Hiss_when_supplied_with_HumanFood()
        {
            Food food = Food.HumanFood;
            
            string result = cat.Feed(food);

            Assert.That(result == HISS);
        }
        
        [Test]
        public void She_returns_Meow_when_supplied_with_DryCatFood()
        {
            Food food = Food.DryCatFood;
            
            string result = cat.Feed(food);

            Assert.That(result == MEOW);
        }
        
        [Test]
        public void She_returns_Meow_when_supplied_with_CannedCatFood()
        {
            Food food = Food.CannedCatFood;
            
            string result = cat.Feed(food);

            Assert.That(result == MEOW);
        }
    }
}
