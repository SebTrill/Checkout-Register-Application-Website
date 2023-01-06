using System;
using Xunit;
using Website.Pages;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
using System.Collections.Generic;

namespace WebsiteTests
{
    /// <summary>
    /// This tests the website functionality.
    /// </summary>
    public class WebsiteFunctionality
    {
        /// <summary>
        /// This checks the items at default.
        /// </summary>
        [Fact]
        public void DefaultItemCountCorrect()
        {
            List<IMenuItem> treatlist = new List<IMenuItem>();
            List<IMenuItem> popperlist = new List<IMenuItem>();
            List<IMenuItem> platterlist = new List<IMenuItem>();

            foreach (IMenuItem item in Menu.Treats) treatlist.Add(item);
            foreach (IMenuItem item in Menu.Poppers) popperlist.Add(item);
            foreach (IMenuItem item in Menu.Platters) platterlist.Add(item);

            Assert.Equal(16, treatlist.Count);
            Assert.Equal(24, popperlist.Count);
            Assert.Equal(447, platterlist.Count);
        }

        /// <summary>
        /// This checks whether the search filters correctly.
        /// </summary>
        /// <param name="input">This is the search term.</param>
        [Theory]
        [InlineData("Fried Oreo")]
        [InlineData("Oreo Fried")]
        public void ReturnsCorrectSearchResults_Test1(string input)
        {
            IndexModel index = new IndexModel();
            index.SearchTerms = input;
            index.OnGet();

            List<IMenuItem> list = new List<IMenuItem>();
            foreach (IMenuItem item in index.Menu) list.Add(item);

            Assert.Equal(34, list.Count);
        }

        /// <summary>
        /// This checks whether the search filters correctly.
        /// </summary>
        /// <param name="input">This is the search term.</param>
        [Theory]
        [InlineData("Oreo")]
        [InlineData("Popper")]
        public void ReturnsCorrectSearchResults_Test2(string input)
        {
            IndexModel index = new IndexModel();
            index.SearchTerms = input;
            index.OnGet();

            List<IMenuItem> list = new List<IMenuItem>();
            foreach (IMenuItem item in index.Menu) list.Add(item);

            Assert.Equal(6, list.Count);
        }

        /// <summary>
        /// This checks whether the price filters correctly.
        /// </summary>
        [Fact]
        public void ReturnsCorrectPriceRange()
        {
            IndexModel index = new IndexModel();
            index.PriceMin = 3.00m;
            index.PriceMax = 4.00m;
            index.OnGet();

            List<IMenuItem> list = new List<IMenuItem>();
            foreach (IMenuItem item in index.Menu) list.Add(item);

            Assert.Equal(20, list.Count);
        }

        /// <summary>
        /// This checks whether the calories filters correctly.
        /// </summary>
        [Fact]
        public void ReturnsCorrectCalorieRange()
        {
            IndexModel index = new IndexModel();
            index.CalorieMin = 300;
            index.CalorieMax = 320;
            index.OnGet();

            List<IMenuItem> list = new List<IMenuItem>();
            foreach (IMenuItem item in index.Menu) list.Add(item);

            Assert.Equal(7, list.Count);
        }
    }
}
