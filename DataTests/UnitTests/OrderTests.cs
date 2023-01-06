using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FriedPiper.DataTests.UnitTests
{
    /// <summary>
    /// This is the test class for the Order class.
    /// </summary>
    public class OrderTests
    {
        /// <summary>
        /// This checks if the item is added to the order.
        /// </summary>
        [Fact]
        void AddItemTest()
        {
            var order = new Order();
            order.Add(new AppleFritters());
            Assert.Single(order);
        }

        /// <summary>
        /// This checks if the item is removed from the order.
        /// </summary>
        [Fact]
        void RemoveItemTest()
        {
            var order = new Order();
            var item = new AppleFritters();
            var item2 = new AppleFritters();
            order.Add(item);
            order.Add(item2);
            order.Remove(item);
            Assert.Single(order);
        }

        /// <summary>
        /// This checks if the order implements INotifyCollectionChanged.
        /// </summary>
        [Fact]
        void ImplementsCollectionChanged()
        {
            var order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// This checks if the order implements INotifyPropertyChanged.
        /// </summary>
        [Fact]
        void ImplementsPropertyChanged()
        {
            var order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /*
        /// <summary>
        /// This checks for the PropertyChanged when adding.
        /// </summary>
        [Fact]
        void AddingPropertyChanged()
        {
            var order = new Order();

            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Add(new FriedTwinkie());
            });
            Assert.PropertyChanged(order, "Total", () => {
                order.Add(new FriedTwinkie());
            });
            Assert.PropertyChanged(order, "Tax", () => {
                order.Add(new FriedTwinkie());
            });
            Assert.PropertyChanged(order, "Calories", () => {
                order.Add(new FriedTwinkie());
            });
        }

        /// <summary>
        /// This checks for the PropertyChanged when adding.
        /// </summary>
        [Fact]
        void RemovingPropertyChanged()
        {
            var order = new Order();
            var item = new AppleFritters();
            var item2 = new AppleFritters();
            var item3 = new AppleFritters();
            var item4 = new AppleFritters();

            order.Add(item);
            order.Add(item2);
            order.Add(item3);
            order.Add(item4);

            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Remove(item);
            });
            Assert.PropertyChanged(order, "Total", () => {
                order.Remove(item2);
            });
            Assert.PropertyChanged(order, "Tax", () => {
                order.Remove(item3);
            });
            Assert.PropertyChanged(order, "Calories", () => {
                order.Remove(item4);
            });
        }
        */
    }
}
