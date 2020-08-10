using Kata.GildedRose.Infrastructure.Enums;

namespace Kata.GildedRose.Infrastructure.Updater
{
    public class ConjuredItem : ItemWrapper
    {
        public ConjuredItem(string name, int sellIn, int quality) :
                base(name, sellIn, quality, ItemType.Conjured)
        {
        }
        public override void Update()
        {
            base.Item.SellIn--;
            if (base.IsQualityValid())
            {
                base.Item.Quality -= 2;
                if (base.IsSellinExpired())
                {
                    base.Item.Quality -= 2;
                }
            }
        }
    }
}
