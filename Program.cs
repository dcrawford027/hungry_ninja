using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            Ninja ninja1 = new Ninja();

            ninja1.Eat(buffet.Serve());
            ninja1.Eat(buffet.Serve());
            ninja1.Eat(buffet.Serve());
            ninja1.Eat(buffet.Serve());
        }
    }

    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicey;
        public bool IsSweet;
        // add a constructor that takes in all four parameters

        public Food(string name, int cal, bool isSpicey, bool isSweet)
        {
            Name = name;
            Calories = cal;
            IsSpicey = isSpicey;
            IsSweet = isSweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;

        // constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Hamburger", 1000, false, false),
                new Food("Curry", 600, true, false),
                new Food("Cheesecake", 1800, false, true),
                new Food("Pasta", 560, false, false),
                new Food("Steak", 780, false, false),
                new Food("Chicken", 500, false, false),
                new Food("Salmon", 420, true, false),
                new Food("Ice Cream", 1050, false, true),
                new Food("French Fries", 810, false, false),
                new Food("Broccoli", 360, false, false),
            };
        }

        public Food Serve()
        {
            int randomIndex = new Random().Next(0, Menu.Count);
            return Menu[randomIndex];
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool IsFull 
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    return true;
                }
                return false;
            }
        }

        // build out the Eat Method
        public void Eat(Food item)
        {
            if (!IsFull) 
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine($"Ate {item.Name}. Gained {item.Calories} calories.");
            } 
            else
            {
                Console.WriteLine("You are full and cannot eat any more."); 
            }
        }
    }
}
