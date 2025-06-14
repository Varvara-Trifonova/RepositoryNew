using DishLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDish
{
    public class Menu : IEnumerable<Dish>
    {
        public DateTime Date { get; }
        private List<Dish> dishes;

        public int Count => dishes.Count;

        public Menu(DateTime date, IEnumerable<Dish> dishCollection)
        {
            Date = date;
            dishes = new List<Dish>();

            foreach (var dish in dishCollection)
            {
                if (!dishes.Any(d => d.Equals(dish)))
                {
                    dishes.Add(dish);
                }
            }

            dishes.Sort();
        }

        public IEnumerator<Dish> GetEnumerator() => dishes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
