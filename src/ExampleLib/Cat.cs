using System;

namespace ExampleLib
{
    //A regular house cat
    public class Cat
    {
        public virtual string Feed(Food food)
        {
            if (food == Food.HumanFood)
                return "KHII";
            else return "Meow";
        }
    }
    
    public enum Food { HumanFood, DryCatFood, CannedCatFood }
}
