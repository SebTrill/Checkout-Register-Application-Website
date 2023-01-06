using System;
using System.ComponentModel;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// A class representing the AppleFritters menu item at FriedPiper
    /// </summary>
    public class AppleFritters : Popper, IMenuItem
    {
        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public override string Name => $"{Size} Apple Fritters";

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
        /// This gets the price of the different sizes of the Apple Fritters.
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small:
                        return 3.00m;
                    case ServingSize.Medium:
                        return 4.00m;
                    case ServingSize.Large:
                        return 5.00m;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// This gets the calories for the different serving sizes of Apple Fritters.
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case ServingSize.Small:
                        if (Glazed) return 240 + 130;
                        else return 240;
                    case ServingSize.Medium:
                        if (Glazed) return 360 + 130;
                        else return 360;
                    case ServingSize.Large:
                        if (Glazed) return 480 + 130;
                        else return 480;
                    default:
                        return 0;
                }
            }
        }
    }
}
