using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This is a class for the fried cheesecake menu item.
    /// </summary>
    public class FriedCheesecake : Popper, IMenuItem
    {
        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public override string Name => $"{Size} Fried Cheesecake";

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
        /// This gets the price of the different sizes of the fried cheesecake.
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
        /// This gets the calories for the different serving sizes of fried cheesecake.
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small:
                        if (Glazed) return 310 + 130;
                        else return 310; 
                    case ServingSize.Medium:
                        if (Glazed) return 425 + 130; 
                        else return 425; 
                    case ServingSize.Large:
                        if (Glazed) return 620 + 130; 
                        else return 620; 
                    default:
                        return 0;
                }
            }
        }
    }
}
