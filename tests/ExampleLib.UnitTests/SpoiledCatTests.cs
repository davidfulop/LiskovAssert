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

        // Note that this test assumes behaviour that violates the LSP in this case
        [Test]
        public void It_throws_ArgumentException_when_supplied_with_HumanFood()
        {
            Food food = Food.HumanFood;
            
            Assert.Throws(typeof(System.ArgumentException), () => cat.Feed(food));
        }
        
        [TestCase(Food.DryCatFood, HISS)]
        [TestCase(Food.CannedCatFood, MEOW)]
        public void It_returns_valid_response_for_foods(Food food, string reply)
        {            
            string result = cat.Feed(food);

            Assert.That(result == reply);
        }
    }
}
