using RestaurantLibrary;
using DishLibrary;
using NUnit.Framework;
using ClassDish;
using System;

namespace RestaurantLibrary.UnitTests
{
    [TestFixture]
    public class DishUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var dish = CreateTestDish();

            Assert.That(dish.Name, Is.EqualTo("Борщ"));
            Assert.That(dish.Cuisine, Is.EqualTo(CuisineType.Russian));
            Assert.That(dish.Description, Is.EqualTo("Традиционный русский суп со свеклой"));
            Assert.That(dish.Price, Is.EqualTo(350));
            Assert.That(dish.IsAvailable, Is.True);
            Assert.That(dish.CookingTime, Is.EqualTo(30));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Dish("", CuisineType.Russian, "Описание", 100, true, 10));
        }

        [Test]
        public void Constructor_InvalidCookingTime_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Dish("Борщ", CuisineType.Russian, "Описание", 100, true, 0));
        }


        [Test]
        public void GetInfoTest()
        {
            var dish = CreateTestDish();
            var info = dish.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Блюдо: Борщ"));
            Assert.That(info[1], Is.EqualTo("Тип кухни: русская. Цена: 350 руб. Время приготовления: 30 мин."));
            Assert.That(info[2], Is.EqualTo("Описание: Традиционный русский суп со свеклой. Наличие: есть в наличии"));
        }

        private Dish CreateTestDish()
        {
            return new Dish(
                name: "Борщ",
                cuisine: CuisineType.Russian,
                description: "Традиционный русский суп со свеклой",
                price: 350,
                isAvailable: true,
                cookingTime: 30);
        }

        [Test]
        public void Appetizer_GetInfo_ReturnsCorrectInfo()
        {
            var appetizer = new Appetizer(
                name: "Брускетта",
                cuisine: CuisineType.Italian,
                description: "Итальянская закуска с помидорами и базиликом",
                price: 250,
                isAvailable: true,
                cookingTime: 10,
                type: AppetizerType.Cold);

            var info = appetizer.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[3], Is.EqualTo("Тип закуски: холодная"));
        }

        [Test]
        public void MainCourse_GetInfo_ReturnsCorrectInfo()
        {
            var mainCourse = new MainCourse(
                name: "Стейк",
                cuisine: CuisineType.Russian,
                description: "Говяжий стейк средней прожарки",
                price: 1200,
                isAvailable: true,
                cookingTime: 25,
                mainIngredient: MainIngredientType.Meat,
                sideDish: "картофельное пюре и овощи гриль");

            var info = mainCourse.GetInfo();

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That(info[3], Is.EqualTo("Основной продукт: мясо"));
            Assert.That(info[4], Is.EqualTo("Гарнир: картофельное пюре и овощи гриль"));
        }

        [Test]
        public void PolymorphismTest()
        {
            Dish dish1 = new Appetizer("Салат", CuisineType.Russian, "Овощной", 300, true, 15, AppetizerType.Cold);
            Dish dish2 = new MainCourse("Лосось", CuisineType.French, "На гриле", 1500, true, 20, MainIngredientType.Fish, "рис");

            var info1 = dish1.GetInfo();
            var info2 = dish2.GetInfo();

            Assert.That(info1.Length, Is.EqualTo(4));
            Assert.That(info2.Length, Is.EqualTo(5));
        }
    }

    [TestFixture]
    public class MenuUnitTests
    {
        [Test]
        public void Dish_CompareTo_ReturnsCorrectOrder()
        {
            var dish1 = new Dish("Борщ", CuisineType.Russian, "Традиционный суп", 300, true, 30);
            var dish2 = new Dish("Салат", CuisineType.Russian, "Овощной", 250, true, 15);
            var dish3 = new Dish("Паста", CuisineType.Italian, "С морепродуктами", 450, true, 25);

            Assert.That(dish1.CompareTo(dish2), Is.GreaterThan(0));
            Assert.That(dish1.CompareTo(dish3), Is.LessThan(0));
            Assert.That(dish1.CompareTo(dish1), Is.EqualTo(0));
        }

        [Test]
        public void Menu_Constructor_CreatesSortedUniqueCollection()
        {
            var date = DateTime.Today;
            var dish1 = new Dish("Борщ", CuisineType.Russian, "Традиционный суп", 300, true, 30);
            var dish2 = new Dish("Салатик", CuisineType.Russian, "Овощной", 250, true, 15);
            var dish3 = new Dish("Паста", CuisineType.Italian, "С морепродуктами", 450, true, 25);
           

            var menu = new Menu(date, new List<Dish> { dish1, dish2, dish3});
         
            Assert.That(menu.Date, Is.EqualTo(date));

            var dishes = new List<Dish>(menu);
            Assert.That(dishes[0].Name, Is.EqualTo("Салатик")); 
            Assert.That(dishes[1].Name, Is.EqualTo("Борщ"));  
            Assert.That(dishes[2].Name, Is.EqualTo("Паста")); 
        }

        [Test]
        public void Menu_IEnumerable_AllowsIteration()
        {
            var date = DateTime.Today;
            var dish1 = new Dish("Борщ", CuisineType.Russian, "Традиционный суп", 300, true, 30);
            var dish2 = new Dish("Салат", CuisineType.Russian, "Овощной", 250, true, 15);

            var menu = new Menu(date, new List<Dish> { dish1, dish2 });

            int count = 0;
            foreach (var dish in menu)
            {
                count++;
                Assert.That(dish, Is.InstanceOf<Dish>());
            }

            Assert.That(count, Is.EqualTo(2));
        }
    }
}