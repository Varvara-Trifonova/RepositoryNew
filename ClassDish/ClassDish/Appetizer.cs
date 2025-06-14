using DishLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDish
{
    public enum AppetizerType { Hot, Cold } 

    public class Appetizer : Dish
    {
        public AppetizerType Type { get; set; } 

        public Appetizer(string name, CuisineType cuisine, string description,
                        decimal price, bool isAvailable, int cookingTime,
                        AppetizerType type)
            : base(name, cuisine, description, price, isAvailable, cookingTime)
        {
            Type = type;
        }

        public override string[] GetInfo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            baseInfo.CopyTo(info, 0);
            info[baseInfo.Length] = $"Тип закуски: {(Type == AppetizerType.Hot ? "горячая" : "холодная")}";

            return info;
        }
    }
}
