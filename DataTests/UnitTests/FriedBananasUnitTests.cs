using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedBananas class.
    /// </summary>
    public class FriedBananasUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the FriedBananas class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, "Small Fried Bananas")]
        [InlineData(ServingSize.Medium, "Medium Fried Bananas")]
        [InlineData(ServingSize.Large, "Large Fried Bananas")]
        public void NameShouldBeCorrect(ServingSize size, string name)
        {
            var ban = new FriedBananas();
            ban.Size = size;
            Assert.Equal(name, ban.Name);
        }

        /// <summary>
        /// This is a test method to check whether the FriedBananas class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var ban = new FriedBananas();
            Assert.IsAssignableFrom<IMenuItem>(ban);
        }

        /// <summary>
        /// This is a test method to check whether the FriedBananas class inherits from the Poppers abstract class.
        /// </summary>
        [Fact]
        public void ShouldExtendPopper()
        {
            var ban = new FriedBananas();
            Assert.IsAssignableFrom<Popper>(ban);
        }

        /// <summary>
        /// This is a test method to check whether or not the Glazed property can be changed.
        /// </summary>
        /// <param name="glazed">This tells whether or not the item is glazed.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetGlazed(bool glazed)
        {
            var ban = new FriedBananas();
            ban.Glazed = glazed;
            Assert.Equal(glazed, ban.Glazed);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedBananas class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="glazed">This tells whether or not the item is glazed.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 160 + 130)]
        [InlineData(ServingSize.Medium, true, 240 + 130)]
        [InlineData(ServingSize.Large, true, 320 + 130)]
        [InlineData(ServingSize.Small, false, 160)]
        [InlineData(ServingSize.Medium, false, 240)]
        [InlineData(ServingSize.Large, false, 320)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool glazed, uint calories)
        {
            var ban = new FriedBananas();
            ban.Size = size;
            ban.Glazed = glazed;
            Assert.Equal(calories, ban.Calories);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedBananas class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="price">This is the price of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, 3.75)]
        [InlineData(ServingSize.Medium, 4.50)]
        [InlineData(ServingSize.Large, 5.25)]
        public void PriceShouldBeCorrectly(ServingSize size, decimal price)
        {
            var ban = new FriedBananas();
            ban.Size = size;
            Assert.Equal(price, ban.Price);
        }

        /// <summary>
        /// This checks the PropertyChanged property.
        /// </summary>
        /// <param name="size">This is the size of the item.</param>
        /// <param name="glazed">This is the glazed property.</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, false)]
        public void ChangingFlavorShouldNotifyOfChangeSize(ServingSize size, bool glazed)
        {
            var ban = new FriedBananas();
            Assert.PropertyChanged(ban, "Size", () => {
                ban.Size = size;
            });
            Assert.PropertyChanged(ban, "Glazed", () => {
                ban.Glazed = glazed;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var ban = new FriedBananas();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(ban);
        }

        /// <summary>
        /// This tests the ToString override.
        /// </summary>
        /// <param name="size">This is the size.</param>
        [Theory]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void ToStringCheck(ServingSize size)
        {
            var ban = new FriedBananas();
            ban.Size = size;
            Assert.Equal(ban.Name, ban.ToString());
        }

        /// <summary>
        /// tests the price property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnPrice()
        {
            var item = new FriedBananas();
            Assert.PropertyChanged(item, "Price", () =>
            {
                item.Size = ServingSize.Large;
            });
            Assert.PropertyChanged(item, "Price", () =>
            {
                item.Size = ServingSize.Medium;
            });
            Assert.PropertyChanged(item, "Price", () =>
            {
                item.Size = ServingSize.Small;
            });
        }

        /// <summary>
        /// tests the name property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnName()
        {
            var item = new FriedBananas();
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Large;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Medium;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Small;
            });
        }
        /// <summary>
        /// tests the calories property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnCalories()
        {
            var item = new FriedBananas();
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Large;
                item.Glazed = true;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Medium;
                item.Glazed = true;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Small;
                item.Glazed = true;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Large;
                item.Glazed = false;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Medium;
                item.Glazed = false;
            });
            Assert.PropertyChanged(item, "Name", () =>
            {
                item.Size = ServingSize.Small;
                item.Glazed = false;
            });
        }
    }
}

