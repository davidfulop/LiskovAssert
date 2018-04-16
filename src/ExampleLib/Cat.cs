using System;

namespace ExampleLib
{
    //A regular house cat
    public class Cat
    {
        public virtual string Feed(Food food)
        {
            return null;
        }
    }
    
    public enum Food { HumanFood, DryCatFood, CannedCatFood }
}
