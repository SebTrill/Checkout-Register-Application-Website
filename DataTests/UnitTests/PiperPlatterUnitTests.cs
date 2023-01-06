using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the PiperPlatter class.
    /// </summary>
    public class PiperPlatterUnitTests
    {
        /// <summary>
        /// This is a test method to check whether the FriedTwinkie class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var pip = new PiperPlatter();
            Assert.IsAssignableFrom<IMenuItem>(pip);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed for the left pie.
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
        public void ShouldBeAbleToSetLeftPieFilling(PieFilling flav)
        {
            var pip = new PiperPlatter();
            pip.LeftPie.Flavor = flav;
            Assert.Equal(flav, pip.LeftPie.Flavor);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed for the right pie.
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
        public void ShouldBeAbleToSetRightPieFilling(PieFilling flav)
        {
            var pip = new PiperPlatter();
            pip.RightPie.Flavor = flav;
            Assert.Equal(flav, pip.RightPie.Flavor);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed for the left ice cream.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void ShouldBeAbleToSetLeftIceCreamFlavor(IceCreamFlavor flav)
        {
            var pip = new PiperPlatter();
            pip.LeftIceCream.Flavor = flav;
            Assert.Equal(flav, pip.LeftIceCream.Flavor);
        }

        /// <summary>
        /// This is a test method to check whether or not the Flavor property can be changed for the right ice cream.
        /// </summary>
        /// <param name="flav">This is the flavor of the item.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void ShouldBeAbleToSetRightIceCreamFlavor(IceCreamFlavor flav)
        {
            var pip = new PiperPlatter();
            pip.RightIceCream.Flavor = flav;
            Assert.Equal(flav, pip.RightIceCream.Flavor);
        }

        /// <summary>
        /// This is a test method for the Name method in the PiperPlatter class.
        /// </summary>
        [Fact]
        public void NameShouldBeCorrectly()
        {
            var pip = new PiperPlatter();
            string name = "Piper Platter";
            Assert.Equal(name, pip.Name);
        }

        /// <summary>
        /// This is a test method for the Price method in the PiperPlatter class.
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var pip = new PiperPlatter();
            decimal price = 12.00m;
            Assert.Equal(price, pip.Price);
        }

        /// <summary>
        /// This is a test method for the Calories method in the PiperPlatter class.
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var pip = new PiperPlatter();
            uint cals = (pip.LeftPie.Calories + pip.RightPie.Calories + pip.LeftIceCream.Calories + pip.RightIceCream.Calories);
            Assert.Equal(cals, pip.Calories);
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var pipplat = new PiperPlatter();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(pipplat);
        }

        /// <summary>
        /// This checks for a change in calories when the left pie is changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the pie.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Pecan)]
        [InlineData(PieFilling.Pineapple)]
        public void LeftPieChangeShouldChangeCalories(PieFilling flav)
        {
            var pip = new PiperPlatter();
            Assert.PropertyChanged(pip, nameof(pip.Calories), () =>
            {
                pip.LeftPie.Flavor = flav;
            });
        }

        /// <summary>
        /// This checks for a change in calories when the right pie is changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the pie.</param>
        [Theory]
        [InlineData(PieFilling.Cherry)]
        [InlineData(PieFilling.Apple)]
        [InlineData(PieFilling.Apricot)]
        [InlineData(PieFilling.Blueberry)]
        [InlineData(PieFilling.Peach)]
        [InlineData(PieFilling.Pecan)]
        [InlineData(PieFilling.Pineapple)]
        public void RightPieChangeShouldChangeCalories(PieFilling flav)
        {
            var pip = new PiperPlatter();
            Assert.PropertyChanged(pip, nameof(pip.Calories), () =>
            {
                pip.RightPie.Flavor = flav;
            });
        }

        /// <summary>
        /// This checks for a change in calories when the left ice cream is changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the ice cream.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void LeftIceCreamChangeShouldChangeCalories(IceCreamFlavor flav)
        {
            var pip = new PiperPlatter();
            Assert.PropertyChanged(pip, nameof(pip.Calories), () =>
            {
                pip.LeftIceCream.Flavor = flav;
            });
        }

        /// <summary>
        /// This checks for a change in calories when the right ice cream is changed.
        /// </summary>
        /// <param name="flav">This is the flavor of the ice cream.</param>
        [Theory]
        [InlineData(IceCreamFlavor.Vanilla)]
        [InlineData(IceCreamFlavor.Chocolate)]
        [InlineData(IceCreamFlavor.Strawberry)]
        public void RightIceCreamChangeShouldChangeCalories(IceCreamFlavor flav)
        {
            var pip = new PiperPlatter();
            Assert.PropertyChanged(pip, nameof(pip.Calories), () =>
            {
                pip.RightIceCream.Flavor = flav;
            });
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        [Fact]
        public void ToStringCheck()
        {
            var pipe = new PiperPlatter();
            Assert.Equal("Piper Platter", pipe.ToString());
        }
    }
}
