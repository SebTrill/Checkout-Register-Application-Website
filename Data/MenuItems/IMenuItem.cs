using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This represents the common aspects of all menu items.
    /// </summary>
    public interface IMenuItem
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This gets the name of the menu item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// This gets the price of the menu item.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// This gets the calorie count of the menu item.
        /// </summary>
        public uint Calories { get; }
    }
}
