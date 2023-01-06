using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the Fried Pie menu item.
    /// </summary>
    public class FriedPie : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name => $"Fried {Flavor} Pie";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This is the private backing property for the Flavor property.
        /// </summary>
        private PieFilling _flavor;

        /// <summary>
        /// This indicates what type of filling is in the pie.
        /// </summary>
        public PieFilling Flavor
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
        /// This gets the price of a fried pie.
        /// </summary>
        public decimal Price => 3.50m;

        /// <summary>
        /// This gets the calories for the pie filling types.
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Flavor)
                {
                    case PieFilling.Cherry:
                        return 287;
                    case PieFilling.Peach:
                        return 304;
                    case PieFilling.Apricot:
                        return 314;
                    case PieFilling.Pineapple:
                        return 302;
                    case PieFilling.Blueberry:
                        return 314;
                    case PieFilling.Apple:
                        return 289;
                    case PieFilling.Pecan:
                        return 314;
                    default:
                        return 0;
                }
            }
        }
    }
}
