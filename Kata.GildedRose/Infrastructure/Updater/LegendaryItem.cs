using Kata.GildedRose.Infrastructure.Enums;

namespace Kata.GildedRose.Infrastructure.Updater
{
    public class LegendaryItem : ItemWrapper
    {
        public LegendaryItem(string name) :
                base(name, 0, 80, ItemType.Legendary)
        {
        }

        public override void Update()
        {

        }
    }
}
