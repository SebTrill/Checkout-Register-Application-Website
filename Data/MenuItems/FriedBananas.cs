using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the fried bananas menu item.
    /// </summary>
    public class FriedBananas : Popper, IMenuItem
    {
        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public override string Name => $"{Size} Fried Bananas";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This is the glazed property.
        /// </summary>
        public override bool Glazed
        {
            get => _glazed;
            set
            {
                _glazed = value;
                OnPropertyChanged(nameof(this.Glazed));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// This is the size property.
        /// </summary>
        public override ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(this.Size));
                OnPropertyChanged(nameof(this.Price));
                OnPropertyChanged(nameof(this.Name));
                OnPropertyChanged(nameof(this.Calories));
            }
        }

        /// <summary>
        /// This gets the price of the different sizes of the fried bananas.
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small:
                        return 3.75m;
                    case ServingSize.Medium:
                        return 4.50m;
                    case ServingSize.Large:
                        return 5.25m;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// This gets the calories for the different serving sizes of fried bananas.
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small:
                        if (Glazed) return 160 + 130; 
                        else return 160; 
                    case ServingSize.Medium:
                        if (Glazed) return 240 + 130; 
                        else return 240; 
                    case ServingSize.Large:
                        if (Glazed) return 320 + 130; 
                        else return 320; 
                    default:
                        return 0;
                }
            }
        }
    }
}
