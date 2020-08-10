using Kata.GildedRose.Infrastructure.Enums;

namespace Kata.GildedRose.Infrastructure.Updater
{
    public class NormalItem : ItemWrapper
    {
        public NormalItem(string name, int sellIn, int quality) :
                base(name, sellIn, quality, ItemType.Normal)
        {
        }

        public override void Update()
        {
            base.Item.SellIn--;
            if (base.IsQualityValid())
            {
                base.Item.Quality--;
                if (base.IsSellinExpired() && base.IsQualityValid())
                {
                    base.Item.Quality--;
                }
            }
        }
    }
}
