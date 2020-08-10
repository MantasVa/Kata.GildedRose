using Kata.GildedRose.Infrastructure.Enums;
using Kata.GildedRose.Infrastructure.Factory;
using Kata.GildedRose.Infrastructure.Updater;
using Kata.GildedRose.Models;
using System.Collections.Generic;
using Xunit;

namespace Kata.GildedRose.Tests
{
    public class ItemsWrapperTests
    {
        [Fact]
        public void Update_Item_QualityAndSellInChanges()
        {
            List<ItemWrapper> expectedItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", 4, 48, ItemType.Conjured),
                ItemFactory.CreateItem("Apple", 9, 21, ItemType.Normal),

                ItemFactory.CreateItem("Weed", 14, 15, ItemType.Rare),

                ItemFactory.CreateItem("Wire", 19, 50, ItemType.Epic),
                ItemFactory.CreateItem("Seed", 9, 27, ItemType.Epic),
                ItemFactory.CreateItem("Ticket", 4, 28, ItemType.Epic),
                ItemFactory.CreateItem("Ticket2", 0, 0, ItemType.Epic),

                ItemFactory.CreateItem("Sulfuras", 0, 80, ItemType.Legendary),
            };
            List<ItemWrapper> actualItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", 5, 50, ItemType.Conjured),
                ItemFactory.CreateItem("Apple", 10, 22, ItemType.Normal),

                ItemFactory.CreateItem("Weed", 15, 14, ItemType.Rare),

                ItemFactory.CreateItem("Wire", 20, 50, ItemType.Epic),
                ItemFactory.CreateItem("Seed", 10, 25, ItemType.Epic),
                ItemFactory.CreateItem("Ticket", 5, 25, ItemType.Epic),
                ItemFactory.CreateItem("Ticket2", 1, 10, ItemType.Epic),

                ItemFactory.CreateItem("Sulfuras", 0, 80, ItemType.Legendary),
            };

            actualItems.ForEach(x => x.Update());

            for (int i = 0; i < actualItems.Count; i++)
            {
                Assert.Equal(expectedItems[i].Item.Quality, actualItems[i].Item.Quality);
                Assert.Equal(expectedItems[i].Item.SellIn, actualItems[i].Item.SellIn);
            }
        }

        [Fact]
        public void Update_NormalItemWithSellinExpired_DecreasesSellInAndQualityTwice()
        {

            List<ItemWrapper> expectedItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", -1, 48, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Sword", -3, 21, ItemType.Normal),
                ItemFactory.CreateItem("Iron chest", -2, 12, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Legs", -5, 23, ItemType.Normal),
            };
            List<ItemWrapper> actualItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", 0, 50, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Sword", -2, 23, ItemType.Normal),
                ItemFactory.CreateItem("Iron chest", -1, 14, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Legs", -4, 25, ItemType.Normal),
            };

            actualItems.ForEach(x => x.Update());

            for (int i = 0; i < actualItems.Count; i++)
            {
                Assert.Equal(expectedItems[i].Item.Quality, actualItems[i].Item.Quality);
                Assert.Equal(expectedItems[i].Item.SellIn, actualItems[i].Item.SellIn);
            }
        }

        [Fact]
        public void Update_ItemQualityIsZero_QualityCannotBeLessThanZero()
        {

            List<ItemWrapper> expectedItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", -1, 0, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Sword", -3, 0, ItemType.Conjured),
                ItemFactory.CreateItem("Iron chest", -2, 0, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Legs", -5, 0, ItemType.Normal),
            };
            List<ItemWrapper> actualItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", 0, 0, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Sword", -2, 0, ItemType.Conjured),
                ItemFactory.CreateItem("Iron chest", -1, 0, ItemType.Normal),
                ItemFactory.CreateItem("Bronze Legs", -4, 0, ItemType.Normal),
            };

            actualItems.ForEach(x => x.Update());

            for (int i = 0; i < actualItems.Count; i++)
            {
                Assert.Equal(expectedItems[i].Item.Quality, actualItems[i].Item.Quality);
                Assert.Equal(expectedItems[i].Item.SellIn, actualItems[i].Item.SellIn);
            }
        }


        [Fact]
        public void Update_RareItemQualityIsFifty_QualityCannotBeMoreThanFifty()
        {

            List<ItemWrapper> expectedItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", -1, 50, ItemType.Rare),
                ItemFactory.CreateItem("Bronze Sword", -3, 50, ItemType.Rare),
            };
            List<ItemWrapper> actualItems = new List<ItemWrapper>()
            {
                ItemFactory.CreateItem("Bread", 0, 50, ItemType.Rare),
                ItemFactory.CreateItem("Bronze Sword", -2, 50, ItemType.Rare),
            };

            actualItems.ForEach(x => x.Update());

            for (int i = 0; i < actualItems.Count; i++)
            {
                Assert.Equal(expectedItems[i].Item.Quality, actualItems[i].Item.Quality);
                Assert.Equal(expectedItems[i].Item.SellIn, actualItems[i].Item.SellIn);
            }
        }
    }
}
