using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedTwinkie class.
    /// </summary>
    public class FriedTwinkieUnitTests
    {
        /// <summary>
        /// This is a test method to check whether the FriedTwinkie class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var twink = new FriedTwinkie();
            Assert.IsAssignableFrom<IMenuItem>(twink);
        }

        /// <summary>
        /// This is a test method for the Name method in the FriedTwinkie class.
        /// </summary>
        [Fact]
        public void NameShouldBeCorrectly()
        {
            var twink = new FriedTwinkie();
            string name = "Fried Twinkie";
            Assert.Equal(name, twink.Name);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedTwinkie class.
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var twink = new FriedTwinkie();
            decimal price = 2.25m;
            Assert.Equal(price, twink.Price);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedTwinkie class.
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var twink = new FriedTwinkie();
            uint cals = 420;
            Assert.Equal(cals, twink.Calories);
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var twink = new FriedTwinkie();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(twink);
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        [Fact]
        public void ToStringCheck()
        {
            var twink = new FriedTwinkie();
            Assert.Equal("Fried Twinkie", twink.ToString());
        }
    }
}
