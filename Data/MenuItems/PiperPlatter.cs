using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data.MenuItems
{
    /// <summary>
    /// This represents a platter for a combo of menu items (2 Pies + 2 Ice Creams).
    /// </summary>
    public class PiperPlatter : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This contains the name of the menu item.
        /// </summary>
        public string Name => "Piper Platter";

        /// <summary>
        /// This prints out the name property.
        /// </summary>
        /// <returns>returns the name property.</returns>
        public override string ToString() { return Name; }

        /// <summary>
        /// This represents the first pie item.
        /// </summary>
        public FriedPie LeftPie { get; } = new FriedPie();

        /// <summary>
        /// This represents the second pie item.
        /// </summary>
        public FriedPie RightPie { get; } = new FriedPie();

        /// <summary>
        /// This represents the first ice cream item.
        /// </summary>
        public FriedIceCream LeftIceCream { get; } = new FriedIceCream();

        /// <summary>
        /// This represents the second ice cream item.
        /// </summary>
        public FriedIceCream RightIceCream { get; } = new FriedIceCream();

        /// <summary>
        /// This gets the calorie count of the different sizes of the platter.
        /// </summary>
        public uint Calories => LeftPie.Calories + RightPie.Calories + LeftIceCream.Calories + RightIceCream.Calories;

        /// <summary>
        /// This is an event listener for when the calorie value changes.
        /// </summary>
        /// <param name="sender">This is the sender.</param>
        /// <param name="e">This is the argument.</param>
        void CaloriesChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Calories))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            }
        }

        /// <summary>
        /// This gets the price of the platter.
        /// </summary>
        public decimal Price => 12.00m;

        public PiperPlatter()
        {
            LeftPie.PropertyChanged += CaloriesChanged;
            RightPie.PropertyChanged += CaloriesChanged;
            LeftIceCream.PropertyChanged += CaloriesChanged;
            RightIceCream.PropertyChanged += CaloriesChanged;
        }
    }
}
