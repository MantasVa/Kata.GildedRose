using Kata.GildedRose.Infrastructure.Enums;

namespace Kata.GildedRose.Infrastructure.Updater
{
    public class RareItem : ItemWrapper
    {
        public RareItem(string name, int sellIn, int quality) :
              base(name, sellIn, quality, ItemType.Rare)
        {
        }

        protected override bool IsQualityValid() => (Item.Quality > 0 && Item.Quality < Constants.MaxQuality) ? true : false;

        public override void Update()
        {
            base.Item.SellIn--;
            if (IsQualityValid())
            {
                base.Item.Quality++;
            }
        }
    }
}
