using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the PopperPlatter class.
    /// </summary>
    public class PopperPlatterUnitTests
    {
        /// <summary>
        /// This is a test method to check whether the PopperPlatter class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var pop = new PopperPlatter(ServingSize.Small, true);
            Assert.IsAssignableFrom<IMenuItem>(pop);
        }

        /// <summary>
        /// This is a test method to check whether or not the Size property can be changed.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void ShouldBeAbleToSetSize(ServingSize size)
        {
            var pop = new PopperPlatter(size, true);
            Assert.Equal(size, pop.Size);
        }

        /// <summary>
        /// This is a test method to check if all poppers size property change when the PopperPlatters Size property changes.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small)]
        [InlineData(ServingSize.Medium)]
        [InlineData(ServingSize.Large)]
        public void SettingSizeShouldAlsoSetPopperSize(ServingSize size)
        {
            var pop = new PopperPlatter(size, true);
            Assert.Equal(size, pop.AppleFritters.Size);
            Assert.Equal(size, pop.FriedBananas.Size);
            Assert.Equal(size, pop.FriedCheesecake.Size);
            Assert.Equal(size, pop.FriedOreos.Size);
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
            var pop = new PopperPlatter(ServingSize.Small, glazed);
            Assert.Equal(glazed, pop.Glazed);
        }

        /// <summary>
        /// This is a test method to check if all poppers galzed property change when the PopperPlatters Glazed property changes.
        /// </summary>
        /// <param name="glazed">This tells whether or not the item is glazed.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SettingGlazedShouldAlsoSetPopperGlazed(bool glazed)
        {
            var pop = new PopperPlatter(ServingSize.Small, glazed);
            Assert.Equal(glazed, pop.AppleFritters.Glazed);
            Assert.Equal(glazed, pop.FriedBananas.Glazed);
            Assert.Equal(glazed, pop.FriedCheesecake.Glazed);
            Assert.Equal(glazed, pop.FriedOreos.Glazed);
        }

        /// <summary>
        /// This is a test method for the Name method in the PopperPlatter class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, "Small Popper Platter")]
        [InlineData(ServingSize.Medium, "Medium Popper Platter")]
        [InlineData(ServingSize.Large, "Large Popper Platter")]
        public void NameShouldBeCorrectly(ServingSize size, string name)
        {
            var pop = new PopperPlatter(size, true);
            Assert.Equal(name, pop.Name);
        }

        /// <summary>
        /// This is a test method for the Price method in the PopperPlatter class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="price">This is the price of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, 12.00)]
        [InlineData(ServingSize.Medium, 16.00)]
        [InlineData(ServingSize.Large, 20.00)]
        public void PriceShouldBeCorrectly(ServingSize size, decimal price)
        {
            var pop = new PopperPlatter(size, true);
            Assert.Equal(price, pop.Price);
        }

        /// <summary>
        /// This is a test method for the Calories method in the PopperPlatter class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="glazed">This tells whether or not the item is glazed.</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, false)]
        public void ShouldHaveCorrectCalories(ServingSize size, bool glazed)
        {
            var pop = new PopperPlatter(size, glazed);
            uint cals = pop.AppleFritters.Calories + pop.FriedBananas.Calories + pop.FriedCheesecake.Calories + pop.FriedOreos.Calories;
            Assert.Equal(cals, pop.Calories);
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
            var plat = new PopperPlatter(size, glazed);
            Assert.PropertyChanged(plat, "Size", () => {
                plat.Size = size;
            });
            Assert.PropertyChanged(plat, "Glazed", () => {
                plat.Glazed = glazed;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var popplat = new PopperPlatter(ServingSize.Small, true);
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(popplat);
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
            var pope = new PopperPlatter(size, true);
            Assert.Equal(pope.Name, pope.ToString());
        }

        /// <summary>
        /// tests the price property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnPrice()
        {
            var item = new PopperPlatter(ServingSize.Small, true);
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
            var item = new PopperPlatter(ServingSize.Small, true);
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
            var item = new PopperPlatter(ServingSize.Small, true);
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
