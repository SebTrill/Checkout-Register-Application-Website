using System;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
// Had issues using the "using FriedPiper.Data.Enums".

namespace DataTests.UnitTests
{
    /// <summary>
    /// This is a test class for the FriedCheesecake class.
    /// </summary>
    public class FriedCheesecakeUnitTests
    {
        /// <summary>
        /// This is a test method for the Name method in the FriedCheesecake class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="name">This is the name given to the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, "Small Fried Cheesecake")]
        [InlineData(ServingSize.Medium, "Medium Fried Cheesecake")]
        [InlineData(ServingSize.Large, "Large Fried Cheesecake")]
        public void NameShouldBeCorrect(ServingSize size, string name)
        {
            var cake = new FriedCheesecake();
            cake.Size = size;
            Assert.Equal(name, cake.Name);
        }

        /// <summary>
        /// This is a test method to check whether the FriedCheesecake class inherits from the IMenuItem Interface.
        /// </summary>
        [Fact]
        public void ShouldImplementIMenuItem()
        {
            var cake = new FriedCheesecake();
            Assert.IsAssignableFrom<IMenuItem>(cake);
        }

        /// <summary>
        /// This is a test method to check whether the FriedCheesecake class inherits from the Poppers abstract class.
        /// </summary>
        [Fact]
        public void ShouldExtendPopper()
        {
            var cake = new FriedCheesecake();
            Assert.IsAssignableFrom<Popper>(cake);
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
            var cake = new FriedCheesecake();
            cake.Glazed = glazed;
            Assert.Equal(glazed, cake.Glazed);
        }

        /// <summary>
        /// This is a test method for the Calories method in the FriedCheesecake class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="glazed">This tells whether or not the item is glazed.</param>
        /// <param name="calories">This is the calorie count of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 310 + 130)]
        [InlineData(ServingSize.Medium, true, 425 + 130)]
        [InlineData(ServingSize.Large, true, 620 + 130)]
        [InlineData(ServingSize.Small, false, 310)]
        [InlineData(ServingSize.Medium, false, 425)]
        [InlineData(ServingSize.Large, false, 620)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool glazed, uint calories)
        {
            var cake = new FriedCheesecake();
            cake.Size = size;
            cake.Glazed = glazed;
            Assert.Equal(calories, cake.Calories);
        }

        /// <summary>
        /// This is a test method for the Price method in the FriedCheesecake class.
        /// </summary>
        /// <param name="size">This is the serving size of the item.</param>
        /// <param name="price">This is the price of the item.</param>
        [Theory]
        [InlineData(ServingSize.Small, 3.75)]
        [InlineData(ServingSize.Medium, 4.50)]
        [InlineData(ServingSize.Large, 5.25)]
        public void PriceShouldBeCorrectly(ServingSize size, decimal price)
        {
            var cake = new FriedCheesecake();
            cake.Size = size;
            Assert.Equal(price, cake.Price);
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
            var cake = new FriedCheesecake();
            Assert.PropertyChanged(cake, "Size", () => {
                cake.Size = size;
            });
            Assert.PropertyChanged(cake, "Glazed", () => {
                cake.Glazed = glazed;
            });
        }

        /// <summary>
        /// Checks if the item impliments the INotify interface
        /// </summary>
        [Fact]
        public void ShouldImplimentNotifyPropertyChanged()
        {
            var cake = new FriedCheesecake();
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(cake);
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
            var cake = new FriedCheesecake();
            cake.Size = size;
            Assert.Equal(cake.Name, cake.ToString());
        }

        /// <summary>
        /// tests the price property.
        /// </summary>
        [Fact]
        public void PropertyChangedShouldBeInvokedOnPrice()
        {
            var item = new FriedCheesecake();
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
            var item = new FriedCheesecake();
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
            var item = new FriedCheesecake();
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

