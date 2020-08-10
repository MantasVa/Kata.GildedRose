using Kata.GildedRose.Infrastructure.Enums;
using Kata.GildedRose.Models;

namespace Kata.GildedRose.Infrastructure.Interfaces
{
    public interface IItemWrapper
    {
        Item Item { get; }
        ItemType ItemType { get; set; }

        void Update();
    }
}