using Kata.GildedRose.Infrastructure.Enums;
using Kata.GildedRose.Infrastructure.Interfaces;
using Kata.GildedRose.Models;

namespace Kata.GildedRose.Infrastructure.Updater
{

    public abstract class ItemWrapper : IItemWrapper
    {
        public ItemWrapper(string name, int sellIn, int quality, ItemType itemType)
        {
            Item = new Item()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
            ItemType = itemType;
        }

        public Item Item { get; }
        public ItemType ItemType { get; set; }

        protected virtual bool IsQualityValid() => (Item.Quality > 0 && Item.Quality <= Constants.MaxQuality) ? true : false;

        protected bool IsSellinExpired() => Item.SellIn < 0 ? true : false;

        public abstract void Update();
    }
}
