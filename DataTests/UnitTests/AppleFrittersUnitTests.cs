using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the AppleFritters class.
    /// </summary>
    public class AppleFrittersUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the AppleFritters class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, "Small Apple Fritters")]
        [InlineData(ServingSize.Medium, "Medium Apple Fritters")]
        [InlineData(ServingSize.Large, "Large Apple Fritters")]
        public void NameShouldBeCorrect(ServingSize size, string name)
        {
            var fritters = new AppleFritters();
            fritters.Size = size;
            Assert.Equal(name, fritters.Name);
        }

        /// <summary>
        /// This is a test method for the Price method in the AppleFritters class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="price">This is the price of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, 3.00)]
        [InlineData(ServingSize.Medium, 4.00)]
        [InlineData(ServingSize.Large, 5.00)]
        public void PriceShouldBeCorrectly(ServingSize size, decimal price)
        {
            var appleFritters = new AppleFritters();
            appleFritters.Size = size;
            Assert.Equal(price, appleFritters.Price);
        }

        /// <summary>
        /// This is a test method to check whether the Glazed method is initialized to 'true' by default.
        /// </summary>
        [Fact]
        public void ShouldBeGlazedByDefault()
        {
            var appleFritters = new AppleFritters();
            Assert.True(appleFritters.Glazed);
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
            var appleFritters = new AppleFritters();
            appleFritters.Glazed = glazed;
            Assert.Equal(glazed, appleFritters.Glazed);
        }

        /// <summary>
        /// This is a test method for the Calories method in the AppleFritters class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="glazed">This tells whether the item is glazed or not.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 370)]
        [InlineData(ServingSize.Medium, true, 490)]
        [InlineData(ServingSize.Large, true, 610)]
        [InlineData(ServingSize.Small, false, 240)]
        [InlineData(ServingSize.Medium, false, 360)]
        [InlineData(ServingSize.Large, false, 480)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool glazed, uint calories)
        {
            var appleFritters = new AppleFritters();
            appleFritters.Size = size;
            appleFritters.Glazed = glazed;
            Assert.Equal(calories, appleFritters.Calories);
        }

        /// <summary>
        /// This is a test method to check whether the AppleFritters class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var fritters = new AppleFritters();
            Assert.IsAssignableFrom<IMenuItem>(fritters);
        }

        /// <summary>
        /// This is a test method to check whether the AppleFritters class inherits from the Poppers abstract class.
        /// </summary>
        [Fact]
        public void ShouldExtendPopper()
        {
            var frit = new AppleFritters();
            Assert.IsAssignableFrom<Popper>(frit);
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
            var frit = new AppleFritters();
            Assert.PropertyChanged(frit, "Size", () => {
                frit.Size = size;
            });
            Assert.PropertyChanged(frit, "Glazed", () => {
                frit.Glazed = glazed;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var frit = new AppleFritters();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(frit);
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
            var frit = new AppleFritters();
            frit.Size = size;
            Assert.Equal(frit.Name, frit.ToString());
        }

        /// <summary>
        /// tests the price property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnPrice()
        {
            var item = new AppleFritters();
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
            var item = new AppleFritters();
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
            var item = new AppleFritters();
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
