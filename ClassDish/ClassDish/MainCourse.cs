using DishLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDish
{
    public enum MainIngredientType { Meat, Fish, Vegetarian } 

    public class MainCourse : Dish
    {
        public MainIngredientType MainIngredient { get; set; } 
        public string SideDish { get; set; } 

        public MainCourse(string name, CuisineType cuisine, string description,
                         decimal price, bool isAvailable, int cookingTime,
                         MainIngredientType mainIngredient, string sideDish)
            : base(name, cuisine, description, price, isAvailable, cookingTime)
        {
            MainIngredient = mainIngredient;
            SideDish = sideDish;
        }

        public override string[] GetInfo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 2];

            baseInfo.CopyTo(info, 0);

            string ingredient;
            switch (MainIngredient)
            {
                case MainIngredientType.Meat: ingredient = "мясо"; break;
                case MainIngredientType.Fish: ingredient = "рыба"; break;
                case MainIngredientType.Vegetarian: ingredient = "вегетарианское"; break;
                default: ingredient = "неизвестный"; break;
            }

            info[baseInfo.Length] = $"Основной продукт: {ingredient}";
            info[baseInfo.Length + 1] = $"Гарнир: {SideDish}";

            return info;
        }
    }
}
