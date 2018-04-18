namespace ExampleLib
{
    public class SpoiledCat : Cat
    {
        public override string Feed(Food food)
        {
            if (food == Food.HumanFood)               
                throw new System.ArgumentException();
            else if (food == Food.DryCatFood)
                return "KHII";
            else return "Meow";
        }
    }
}
