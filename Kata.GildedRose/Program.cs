using Kata.GildedRose.Infrastructure.Enums;
using Kata.GildedRose.Infrastructure.Factory;
using Kata.GildedRose.Infrastructure.Updater;
using Kata.GildedRose.Models;
using System;
using System.Collections.Generic;

namespace Kata.GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<ItemWrapper> Items = new List<ItemWrapper>{
                        ItemFactory.CreateItem("+5 Dexterity Vest",10,20, ItemType.Normal),
                        ItemFactory.CreateItem("Aged Brie",2,0, ItemType.Rare),
                        ItemFactory.CreateItem("Elixir of the Mongoose",5,7, ItemType.Normal),
                        ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros",0,80, ItemType.Legendary),
                        ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros",-1,80, ItemType.Legendary),
                        ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert",15,20, ItemType.Epic),
                        ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert",10,49, ItemType.Epic),
                        ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert",5,49, ItemType.Epic),
                        ItemFactory.CreateItem("Conjured Mana Cake",3,6, ItemType.Conjured)
                    };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Item.Name + ", " + Items[j].Item.SellIn + ", " + Items[j].Item.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
