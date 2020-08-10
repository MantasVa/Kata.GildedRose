using Kata.GildedRose.Infrastructure.Enums;

namespace Kata.GildedRose.Infrastructure.Updater
{
    public class EpicItem : ItemWrapper
    {
        public EpicItem(string name, int sellIn, int quality) :
          base(name, sellIn, quality, ItemType.Rare)
        {
        }

        protected override bool IsQualityValid() => (Item.Quality > 0 && Item.Quality < Constants.MaxQuality) ? true : false;

        public override void Update()
        {
            base.Item.SellIn--;
            if (IsQualityValid())
            {
                if (base.Item.SellIn > 10)
                    base.Item.Quality++;
                else if (5 < base.Item.SellIn && base.Item.SellIn <= 10)
                    base.Item.Quality += 2;
                else if (0 < base.Item.SellIn && base.Item.SellIn <= 5)
                    base.Item.Quality += 3;
                else if (base.Item.SellIn == 0)
                    base.Item.Quality = 0;
            }
        }
    }
}
