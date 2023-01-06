using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedIceCream class.
    /// </summary>
    public class FriedIceCreamUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the FriedIceCream class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla, "Fried Vanilla Ice Cream")]
        [InlineData(IceCreamFlavor.Chocolate, "Fried Chocolate Ice Cream")]
        [InlineData(IceCreamFlavor.Strawberry, "Fried Strawberry Ice Cream")]
        public void NameShouldBeCorrectly(IceCreamFlavor flav, string name)
        {
            var ice = new FriedIceCream();
            ice.Flavor = flav;
            Assert.Equal(name, ice.Name);
        }

        /// <summary>
        /// This is a test method to check whether the FriedIceCream class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var ice = new FriedIceCream();
            Assert.IsAssignableFrom<IMenuItem>(ice);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void ShouldBeAbleToSetIceCreamFlavor(IceCreamFlavor flav)
        {
            var ice = new FriedIceCream();
            ice.Flavor = flav;
            Assert.Equal(flav, ice.Flavor);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedIceCream class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla, 355)]
        [InlineData(IceCreamFlavor.Chocolate, 353)]
        [InlineData(IceCreamFlavor.Strawberry, 321)]
        public void CaloriesShouldBeCorrect(IceCreamFlavor flav, uint calories)
        {
            var ice = new FriedIceCream();
            ice.Flavor = flav;
            Assert.Equal(calories, ice.Calories);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedIceCream class.
        /// </summary>
        [Fact]
        public void PriceShouldBeCorrect()
        {
            var ice = new FriedIceCream();
            decimal price = 3.50m;
            Assert.Equal(price, ice.Price);
        }

        /// <summary>
        /// This checks the PropertyChanged property.
        /// </summary>
        /// <param name="flavor">This is the flavor of the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void ChangingFlavorShouldNotifyOfChange(IceCreamFlavor flavor)
        {
            var ice = new FriedIceCream();
            Assert.PropertyChanged(ice, "Flavor", () => {
                ice.Flavor = flavor;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var ice = new FriedIceCream();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(ice);
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void ToStringCheck(IceCreamFlavor flavor)
        {
            var ice = new FriedIceCream();
            ice.Flavor = flavor;
            Assert.Equal(ice.Name, ice.ToString());
        }

        /// <summary>
        /// tests the name property.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void PropertyChangedShouldBeInvokedOnName(IceCreamFlavor flavor)
        {
            var item = new FriedIceCream();
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Flavor = flavor;
            });
        }

        /// <summary>
        /// tests the calories property.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void PropertyChangedShouldBeInvokedOnCalories(IceCreamFlavor flavor)
        {
            var item = new FriedIceCream();
            Assert.PropertyChanged(item, "Calories", () =>
            {
                item.Flavor = flavor;
            });
        }
    }
}

