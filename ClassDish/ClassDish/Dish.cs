using DishLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDish
{
    public class Dish
    {
        public readonly string Name;          
        public CuisineType Cuisine { get; }   
        public string Description { get; set; } 
        public decimal Price { get; set; }    
        public bool IsAvailable { get; set; } 
        public int CookingTime { get; set; }  

        public Dish(string name, CuisineType cuisine, string description,
                   decimal price, bool isAvailable, int cookingTime)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название блюда не может быть пустым");

            if (cookingTime <= 0)
                throw new ArgumentException("Время приготовления должно быть положительным числом");

            Name = name;
            Cuisine = cuisine;
            Description = description;
            Price = price;
            IsAvailable = isAvailable;
            CookingTime = cookingTime;
        }

        public virtual string[] GetInfo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var info = new string[3];
            info[0] = $"Блюдо: {Name}";

            string cuisine;
            switch (Cuisine)
            {
                case CuisineType.Russian: cuisine = "русская"; break;
                case CuisineType.Caucasian: cuisine = "кавказская"; break;
                case CuisineType.Italian: cuisine = "итальянская"; break;
                case CuisineType.French: cuisine = "французская"; break;
                case CuisineType.CentralAsian: cuisine = "среднеазиатская"; break;
                case CuisineType.Eastern: cuisine = "восточная"; break;
                default: cuisine = "неизвестная"; break;
            }

            info[1] = $"Тип кухни: {cuisine}. Цена: {Price} руб. Время приготовления: {CookingTime} мин.";
            info[2] = $"Описание: {Description}. Наличие: {(IsAvailable ? "есть в наличии" : "нет в наличии")}";

            return info;
        }
    }
}
