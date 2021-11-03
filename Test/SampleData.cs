using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;


namespace Test
{
    public class SampleData
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Shops.Any())
            {
                Shop prostore = new Shop { Name = "Prostore", Address = "Malinovka 22", Work = "24h" };
                Shop cent = new Shop { Name = "Копеечка", Address = "Malinovka 10", Work = "9:00 - 22:00" };
                Shop hyper = new Shop { Name = "Гипермаркет", Address = "Nemiga 10", Work = "8:00 - 24:00" };
                context.Shops.AddRange(prostore, cent, hyper);
                Product apple = new Product { Name = "Яблоко", Description = "Зеленое яблоко из Грузии", shop = prostore };
                Product beer = new Product { Name = "Пиво", Description = "Алкогольный напиток 6.5%", shop = prostore };
                Product notebook = new Product { Name = "Тетрадь", Description = "Тетрадь в клетку 48 листов", shop = cent};
                Product headphones = new Product { Name = "Наушники", Description = "Беспроводные наушники Xiaomi", shop = hyper };
                context.Products.AddRange(apple, beer, notebook, headphones);
                context.SaveChanges();
            }
        }
    }
}
