using Kata.GildedRose.Infrastructure.Enums;
using Kata.GildedRose.Infrastructure.Updater;
using System;

namespace Kata.GildedRose.Infrastructure.Factory
{
    public static class ItemFactory
    {
        public static ItemWrapper CreateItem(string itemName, int sellin, int quality, ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Conjured:
                    return new ConjuredItem(itemName, sellin, quality);
                case ItemType.Normal:
                    return new NormalItem(itemName, sellin, quality);
                case ItemType.Rare:
                    return new RareItem(itemName, sellin, quality);
                case ItemType.Epic:
                    return new EpicItem(itemName, sellin, quality);
                case ItemType.Legendary:
                    return new LegendaryItem(itemName);
            }
            throw new ArgumentException();
        }
    }
}