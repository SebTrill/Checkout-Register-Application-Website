using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedPie class.
    /// </summary>
    public class FriedPieUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the FriedPie class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(PieFilling.Cherry, "Fried Cherry Pie")]
        [InlineData(PieFilling.Apple, "Fried Apple Pie")]
        [InlineData(PieFilling.Apricot, "Fried Apricot Pie")]
        [InlineData(PieFilling.Blueberry, "Fried Blueberry Pie")]
        [InlineData(PieFilling.Peach, "Fried Peach Pie")]
        [InlineData(PieFilling.Pecan, "Fried Pecan Pie")]
        [InlineData(PieFilling.Pineapple, "Fried Pineapple Pie")]
        public void NameShouldBeCorrectly(PieFilling flav, string name)
        {
            var pie = new FriedPie();
            pie.Flavor = flav;
            Assert.Equal(name, pie.Name);
        }

        /// <summary>
        /// This is a test method to check whether the FriedPie class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var pie = new FriedPie();
            Assert.IsAssignableFrom<IMenuItem>(pie);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Pecan)]
        [InlineData(PieFilling.Pineapple)]
        public void ShouldBeAbleToSetPieFilling(PieFilling flav)
        {
            var pie = new FriedPie();
            pie.Flavor = flav;
            Assert.Equal(flav, pie.Flavor);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedPie class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(PieFilling.Cherry, 287)]
        [InlineData(PieFilling.Apple, 289)]
        [InlineData(PieFilling.Apricot, 314)]
        [InlineData(PieFilling.Blueberry, 314)]
        [InlineData(PieFilling.Peach, 304)]
        [InlineData(PieFilling.Pecan, 314)]
        [InlineData(PieFilling.Pineapple, 302)]
        public void CaloriesShouldBeCorrect(PieFilling flav, uint calories)
        {
            var pie = new FriedPie();
            pie.Flavor = flav;
            Assert.Equal(calories, pie.Calories);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedPie class.
        /// </summary>
        [Fact]
        public void PriceShouldBeCorrect()
        {
            var pie = new FriedPie();
            decimal price = 3.50m;
            Assert.Equal(price, pie.Price);
        }

        /// <summary>
        /// This checks the PropertyChanged property.
        /// </summary>
        /// <param name="flavor">This is the flavor of the item.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Pineapple)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Pecan)]
        public void ChangingFlavorShouldNotifyOfChange(PieFilling flavor)
        {
            var pie = new FriedPie();
            Assert.PropertyChanged(pie, "Flavor", () => {
                pie.Flavor = flavor;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var pie = new FriedPie();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(pie);
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Pineapple)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Pecan)]
        public void ToStringCheck(PieFilling flavor)
        {
            var pie = new FriedPie();
            pie.Flavor = flavor;
            Assert.Equal(pie.Name, pie.ToString());
        }

        /// <summary>
        /// tests the name property.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Pineapple)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Pecan)]
        public void PropertyChangedShouldBeInvokedOnName(PieFilling flavor)
        {
            var item = new FriedPie();
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
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Pineapple)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Pecan)]
        public void PropertyChangedShouldBeInvokedOnCalories(PieFilling flavor)
        {
            var item = new FriedPie();
            Assert.PropertyChanged(item, "Calories", () =>
            {
                item.Flavor = flavor;
            });
        }
    }
}
