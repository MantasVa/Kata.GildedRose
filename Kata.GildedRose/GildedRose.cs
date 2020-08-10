using Kata.GildedRose.Infrastructure.Updater;
using Kata.GildedRose.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kata.GildedRose
{
    public class GildedRose
    {
        private IList<ItemWrapper> _items;
        public GildedRose(IList<ItemWrapper> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            _items.ToList().ForEach(x => x.Update());
        }
    }
}
