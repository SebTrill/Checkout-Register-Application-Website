using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This represents a platter for a combo of menu items (Apple Fritter + Fried Oreos + Fried Cheesecake + Fried Bananas).
    /// </summary>
    public class PopperPlatter : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name => $"{Size} Popper Platter";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This is the private backing variable for the Size property.
        /// </summary>
        public ServingSize _size = ServingSize.Small;

        /// <summary>
        /// This is the private backing variable for the Glazed property.
        /// </summary>
        public bool _glazed = true;

        /// <summary>
        /// This is the glazed property.
        /// </summary>
        public bool Glazed
        {
            get => _glazed;
            set
            {
                _glazed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Glazed"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// This is the size property.
        /// </summary>
        public ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// This represents the apple fritters item.
        /// </summary>
        public AppleFritters AppleFritters = new AppleFritters();

        /// <summary>
        /// This represents the fried bananas item.
        /// </summary>
        public FriedBananas FriedBananas = new FriedBananas();

        /// <summary>
        /// This represents the fried cheesecake item.
        /// </summary>
        public FriedCheesecake FriedCheesecake = new FriedCheesecake();

        /// <summary>
        /// This represents the fried oreos item.
        /// </summary>
        public FriedOreos FriedOreos = new FriedOreos();

        /// <summary>
        /// This gets the calorie count of the different sizes of the platter.
        /// </summary>
        public uint Calories => (AppleFritters.Calories + FriedBananas.Calories + FriedCheesecake.Calories + FriedOreos.Calories);

        /// <summary>
        /// This gets the price of the platter.
        /// </summary>
        public decimal Price
        {
            get
            {
                switch (Size)
                {
                    case (ServingSize.Small):
                        return 12.00m;
                    case (ServingSize.Medium):
                        return 16.00m;
                    case (ServingSize.Large):
                        return 20.00m;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// This is a constructor for the popper platter.
        /// </summary>
        /// <param name="size">This sets all of the poppers to this serving size.</param>
        /// <param name="glazed">This sets all the poppers to this glazed property.</param>
        public PopperPlatter(ServingSize size, bool glazed)
        {
            AppleFritters.Size = size;
            FriedBananas.Size = size;
            FriedCheesecake.Size = size;
            FriedOreos.Size = size;
            AppleFritters.Glazed = glazed;
            FriedBananas.Glazed = glazed;
            FriedCheesecake.Glazed = glazed;
            FriedOreos.Glazed = glazed;
            Size = size;
            Glazed = glazed;
        }
    }
}
