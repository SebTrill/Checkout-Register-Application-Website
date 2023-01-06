using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedCandyBar class.
    /// </summary>
    public class FriedCandyBarUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the FriedCandyBar class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(CandyBar.Snickers, "Fried Snickers")]
        [InlineData(CandyBar.MilkyWay, "Fried Milky Way")]
        [InlineData(CandyBar.Twix, "Fried Twix")]
        [InlineData(CandyBar.ThreeMusketeers, "Fried Three Musketeers")]
        [InlineData(CandyBar.ButterFingers, "Fried Butter Fingers")]
        public void NameShouldBeCorrectly(CandyBar flav, string name)
        {
            var bar = new FriedCandyBar();
            bar.Flavor = flav;
            Assert.Equal(name, bar.Name);
        }

        /// <summary>
        /// This is a test method to check whether the FriedCandyBar class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var bar = new FriedCandyBar();
            Assert.IsAssignableFrom<IMenuItem>(bar);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        [Theory]
        [InlineData(CandyBar.Snickers)]
        [InlineData(CandyBar.MilkyWay)]
        [InlineData(CandyBar.Twix)]
        [InlineData(CandyBar.ThreeMusketeers)]
        [InlineData(CandyBar.ButterFingers)]
        public void ShouldBeAbleToSetCandyBar(CandyBar flav)
        {
            var bar = new FriedCandyBar();
            bar.Flavor = flav;
            Assert.Equal(flav, bar.Flavor);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedCandyBar class.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(CandyBar.Snickers, 325)]
        [InlineData(CandyBar.MilkyWay, 213)]
        [InlineData(CandyBar.Twix, 396)]
        [InlineData(CandyBar.ThreeMusketeers, 350)]
        [InlineData(CandyBar.ButterFingers, 385)]
        public void CaloriesShouldBeCorrect(CandyBar flav, uint calories)
        {
            var bar = new FriedCandyBar();
            bar.Flavor = flav;
            Assert.Equal(calories, bar.Calories);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedCandyBar class.
        /// </summary>
        [Fact]
        public void PriceShouldBeCorrect()
        {
            var bar = new FriedCandyBar();
            decimal price = 2.50m;
            Assert.Equal(price, bar.Price);
        }

        /// <summary>
        /// This checks the PropertyChanged property.
        /// </summary>
        /// <param name="flavor">This is the flavor of the item.</param>
        [Theory]
        [InlineData(CandyBar.MilkyWay)]
        [InlineData(CandyBar.Twix)]
        [InlineData(CandyBar.ThreeMusketeers)]
        [InlineData(CandyBar.ButterFingers)]
        [InlineData(CandyBar.Snickers)]
        public void ChangingFlavorShouldNotifyOfChange(CandyBar flavor)
        {
            var bar = new FriedCandyBar();
            Assert.PropertyChanged(bar, "Flavor", () => {
                bar.Flavor = flavor;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var bar = new FriedCandyBar();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(bar);
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(CandyBar.MilkyWay)]
        [InlineData(CandyBar.Twix)]
        [InlineData(CandyBar.ThreeMusketeers)]
        [InlineData(CandyBar.ButterFingers)]
        [InlineData(CandyBar.Snickers)]
        public void ToStringCheck(CandyBar flavor)
        {
            var bar = new FriedCandyBar();
            bar.Flavor = flavor;
            Assert.Equal(bar.Name, bar.ToString());
        }
        /// <summary>
        /// tests the name property.
        /// </summary>
        /// <param name="flavor">This is the flavor.</param>
        [Theory]
        [InlineData(CandyBar.MilkyWay)]
        [InlineData(CandyBar.Twix)]
        [InlineData(CandyBar.ThreeMusketeers)]
        [InlineData(CandyBar.ButterFingers)]
        [InlineData(CandyBar.Snickers)]
        public void PropertyChangedShouldBeInvokedOnName(CandyBar flavor)
        {
            var item = new FriedCandyBar();
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
        [InlineData(CandyBar.MilkyWay)]
        [InlineData(CandyBar.Twix)]
        [InlineData(CandyBar.ThreeMusketeers)]
        [InlineData(CandyBar.ButterFingers)]
        [InlineData(CandyBar.Snickers)]
        public void PropertyChangedShouldBeInvokedOnCalories(CandyBar flavor)
        {
            var item = new FriedCandyBar();
            Assert.PropertyChanged(item, "Calories", () =>
            {
                item.Flavor = flavor;
            });
        }

    }
}

