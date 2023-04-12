using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace BuyPizza.Models.dbContext
{
    public class pizzaInitializer : DropCreateDatabaseIfModelChanges<pizzaContext>
    {
        protected override void Seed(pizzaContext context)
        {
            var items = new List<Item>
            {
                new Item{Name="Pizza Cake", Description="Pizza Cake", Image="PizzaCake.jpg", Rate=99, CreatedDate=DateTime.UtcNow},
                new Item{Name="St. Louis-Style Pizza", Description="St. Louis-Style Pizza", Rate=199, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pizza ortolana", Description="Pizza ortolana", Image="Pizzaortolana.jpg", Rate=299, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pizza alla pala", Description="Pizza alla pala", Image="Pizzaallapala.jpg", Rate=149, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pizza pesto Genovese", Description="Pizza pesto Genovese", Image="PizzapestoGenovese.jpg", Rate=249, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pizza rustica", Description="Pizza rustica", Image="Pizzarustica.jpg", Rate=349, CreatedDate=DateTime.UtcNow},
                new Item{Name="Fugazzeta", Description="Fugazzeta", Image="Fugazzeta.jpg", Rate=399, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pizza e fichi", Description="Pizza e fichi", Image="Pizzaefichi.jpg", Rate=449, CreatedDate=DateTime.UtcNow},
                new Item{Name="Apizza", Description="Apizza", Image="Apizza.jpg", Rate=229, CreatedDate=DateTime.UtcNow},
                new Item{Name="Pugliese Pizza", Description="Pugliese Pizza", Image="PugliesePizza.jpg", Rate=279, CreatedDate=DateTime.UtcNow},
                new Item{Name="Tomato Pie", Description="Tomato Pie", Image="TomatoPie.jpg", Rate=489, CreatedDate=DateTime.UtcNow}
            }; items.ForEach(i => context.Items.Add(i)); context.SaveChanges();

            var toppings = new List<Topping>
            {
                new Topping{Name="Roasted Tomatoes", Image="RoastedTomatoes.jpg", Rate=49, CreatedDate=DateTime.UtcNow},
                new Topping{Name="Roasted Red Peppers", Image="RoastedRedPeppers.jpg", Rate=39, CreatedDate=DateTime.UtcNow},
                new Topping{Name="Roasted Artichokes", Image="RoastedArtichokes.jpg", Rate=59, CreatedDate=DateTime.UtcNow},
                new Topping{Name="Roasted Butternut Squash", Image="RoastedButternutSquash.jpg", Rate=89, CreatedDate=DateTime.UtcNow},
                new Topping{Name="Roasted Broccoli", Image="RoastedBroccoli.jpg", Rate=49, CreatedDate=DateTime.UtcNow},
                new Topping{Name="Roasted Fennel", Image="RoastedFennel.jpg", Rate=89, CreatedDate=DateTime.UtcNow},
            }; toppings.ForEach(t => context.Toppings.Add(t)); context.SaveChanges();

            var itemToppings = new List<ItemTopping>
            {
                new ItemTopping{ItemID=1, ToppingID=1, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=1, ToppingID=3, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=2, ToppingID=5, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=2, ToppingID=2, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=3, ToppingID=4, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=3, ToppingID=6, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=4, ToppingID=1, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=4, ToppingID=3, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=5, ToppingID=5, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=5, ToppingID=2, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=6, ToppingID=4, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=6, ToppingID=6, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=7, ToppingID=1, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=7, ToppingID=3, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=7, ToppingID=5, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=8, ToppingID=2, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=8, ToppingID=4, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=9, ToppingID=6, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=9, ToppingID=1, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=9, ToppingID=3, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=10, ToppingID=5, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=10, ToppingID=2, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=11, ToppingID=4, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=11, ToppingID=6, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=11, ToppingID=1, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=11, ToppingID=3, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=8, ToppingID=5, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=9, ToppingID=2, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=8, ToppingID=4, CreatedDate=DateTime.UtcNow},
                new ItemTopping{ItemID=7, ToppingID=6, CreatedDate=DateTime.UtcNow}
            }; itemToppings.ForEach(i => context.ItemToppings.Add(i)); context.SaveChanges();
        }
    }
}
