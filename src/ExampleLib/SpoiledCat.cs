namespace ExampleLib
{
    public class SpoiledCat : Cat
    {
        public override string Feed(Food food)
        {
            if (food == Food.HumanFood)
                // With the next line active the class doesn't adhere to the LSP (see how the Cat class works) 
                throw new System.ArgumentException();
                // With the next line active the class adheres to the LSP (see how the Cat class works)
                // return "KHII";
            else if (food == Food.DryCatFood)
                return "KHII";
            else return "Meow";
        }
    }
}
