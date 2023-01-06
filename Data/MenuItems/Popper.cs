using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data
{
    /// <summary>
    /// This is a base class for Poppers.
    /// </summary>
    public abstract class Popper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This is the private backing variable for the Size property.
        /// </summary>
        public ServingSize _size;

        /// <summary>
        /// This is the private backing variable for the Glazed property.
        /// </summary>
        public bool _glazed = true;

        /// <summary>
        /// The base method for getting the name of the menu item.
        /// </summary>
        /// <returns>Returns the name of the menu item.</returns>
        public abstract string Name { get; }

        /// <summary>
        /// The base method for getting and setting the serving size of the item.
        /// </summary>
        /// <returns>Returns the serving size of the item.</returns>
        public virtual ServingSize Size
        {
            get => _size;
            set
            {
                _size = value;
            }
        }

        /// <summary>
        /// The base method for getting and setting whether the item is glazed or not.
        /// </summary>
        /// <returns>Returns whether the item is glazed or not.</returns>
        public virtual bool Glazed
        {
            get => _glazed;
            set
            {
                _glazed = value;
            }
        }

        /// <summary>
        /// The base method for getting the price of the menu item.
        /// </summary>
        /// <returns>Returns the price of the menu item.</returns>
        public abstract decimal Price { get; }

        /// <summary>
        /// The base method for getting the calorie count for the menu item.
        /// </summary>
        /// <returns>Returns the calorie count for the menu item.</returns>
        public abstract uint Calories { get; }

        /// <summary>
        /// This helps with the propertychanged stuff.
        /// </summary>
        /// <param name="name">This is the property name.</param>
        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
