using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the fried twinkie menu item.
    /// </summary>
    public class FriedTwinkie : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name => "Fried Twinkie";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This gets the price of a fried twinkie.
        /// </summary>
        public decimal Price => 2.25m;

        /// <summary>
        /// This gets the calories for the twinkie.
        /// </summary>
        public uint Calories => 420;
    }
}
