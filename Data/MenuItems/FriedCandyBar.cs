using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the fried candy bar menu item.
    /// </summary>
    public class FriedCandyBar : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name
        {
            get
            {
                switch (Flavor)
                {
                    case CandyBar.ButterFingers:
                        return "Fried Butter Fingers";
                    case CandyBar.MilkyWay:
                        return "Fried Milky Way";
                    case CandyBar.ThreeMusketeers:
                        return "Fried Three Musketeers";
                    default:
                        return $"Fried {Flavor}";
                }
            }
        }

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This is the private backing property for the Flavor property.
        /// </summary>
        private CandyBar _flavor;

        /// <summary>
        /// This indicates the type of candy bar.
        /// </summary>
        public CandyBar Flavor
        {
            get => _flavor;
            set
            {
                this._flavor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flavor)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            }
        }

        /// <summary>
        /// This gets the price of a fried candy bar.
        /// </summary>
        public decimal Price => 2.50m;

        /// <summary>
        /// This gets the calories for the candy bar types.
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Flavor)
                {
                    case CandyBar.Snickers:
                        return 325;
                    case CandyBar.MilkyWay:
                        return 213;
                    case CandyBar.Twix:
                        return 396;
                    case CandyBar.ThreeMusketeers:
                        return 350;
                    case CandyBar.ButterFingers:
                        return 385;
                    default:
                        return 0;
                }
            }
        }
    }
}
