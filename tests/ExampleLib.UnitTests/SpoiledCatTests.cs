using NUnit.Framework;

namespace ExampleLib.UnitTests
{
    public class SpoiledCatTests
    {
        const string MEOW = "Meow";
        const string HISS = "KHII";

        SpoiledCat cat;

        [SetUp]
        public void SetUp()
        {
            cat = new SpoiledCat();
        }

        [Test]
        public void She_throws_ArgumentException_when_supplied_with_HumanFood()
        {
            Food food = Food.HumanFood;
            
            Assert.Throws(typeof(System.ArgumentException), () => cat.Feed(food));
        }
        
        [Test]
        public void She_returns_Hiss_when_supplied_with_DryCatFood()
        {
            Food food = Food.DryCatFood;
            
            string result = cat.Feed(food);

            Assert.That(result == HISS);
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
