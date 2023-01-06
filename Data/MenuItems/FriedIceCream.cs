using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the Fired Ice Cream menu item.
    /// </summary>
    public class FriedIceCream : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name => $"Fried {Flavor} Ice Cream";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This is the private backing property for the Flavor property.
        /// </summary>
        private IceCreamFlavor _flavor;

        /// <summary>
        /// This indicates the type of ice cream.
        /// </summary>
        public IceCreamFlavor Flavor
        {
            get => _flavor;
            set
            {
                _flavor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flavor"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// This gets the price of a fried ice cream.
        /// </summary>
        public decimal Price => 3.50m;

        /// <summary>
        /// This gets the calories for the ice cream types.
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Flavor)
                {
                    case IceCreamFlavor.Vanilla:
                        return 355;
                    case IceCreamFlavor.Chocolate:
                        return 353;
                    case IceCreamFlavor.Strawberry:
                        return 321;
                    default:
                        return 0;
                }
            }
        }
    }
}
