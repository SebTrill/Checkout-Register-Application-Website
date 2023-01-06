using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;

namespace FriedPiper.DataTests.UnitTests
{
    /// <summary>
    /// This is a testing class for the menu class.
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// This checks if the number of items is correct in treats.
        /// </summary>
        [Fact]
        public void TreatMenuCountCorrect()
        {
            IEnumerable<IMenuItem> items = Menu.Treats;
            int counter = 0;
            foreach (IMenuItem x in items)
            {
                counter++;
            }
            Assert.Equal(16, counter);
        }

        /// <summary>
        /// This checks if the number of items is correct in poppers.
        /// </summary>
        [Fact]
        public void PopperMenuCountCorrect()
        {
            IEnumerable<IMenuItem> items = Menu.Poppers;
            int counter = 0;
            foreach (IMenuItem x in items)
            {
                counter++;
            }
            Assert.Equal(24, counter);
        }

        /// <summary>
        /// This checks if the number of items is correct in platters.
        /// </summary>
        [Fact]
        public void PlatterMenuCountCorrect()
        {
            IEnumerable<IMenuItem> items = Menu.Platters;
            int counter = 0;
            foreach (IMenuItem x in items)
            {
                counter++;
            }
            Assert.Equal(447, counter);
        }

        /// <summary>
        /// This checks if the number of items is correct in the full menu.
        /// </summary>
        [Fact]
        public void FullMenuCountCorrect()
        {
            IEnumerable<IMenuItem> items = Menu.FullMenu;
            int counter = 0;
            foreach (IMenuItem x in items)
            {
                counter++;
            }
            Assert.Equal(487, counter);
        }

        /// <summary>
        /// Checks if all the treats are unique.
        /// </summary>
        [Fact]
        public void AllUniqueTreatItems()
        {
            foreach (PieFilling p in Enum.GetValues(typeof(PieFilling)))
            {
                Assert.Contains(Menu.Treats, item =>
                {
                    if (item is FriedPie x)
                    {
                        if (x.Flavor == p) return true;
                    }
                    return false;
                });
            }
            foreach (IceCreamFlavor i in Enum.GetValues(typeof(IceCreamFlavor)))
            {
                Assert.Contains(Menu.Treats, item =>
                {
                    if (item is FriedIceCream x)
                    {
                        if (x.Flavor == i) return true;
                    }
                    return false;
                });
            }
            foreach (CandyBar c in Enum.GetValues(typeof(CandyBar)))
            {
                Assert.Contains(Menu.Treats, item =>
                {
                    if (item is FriedCandyBar x)
                    {
                        if (x.Flavor == c) return true;
                    }
                    return false;
                });
            }
            Assert.Contains(Menu.Treats, item =>
            {
                if (item is FriedTwinkie x) return true;
                return false;
            });
        }

        /// <summary>
        /// Checks if all the poppers are unique.
        /// </summary>
        [Fact]
        public void AllUniquePopperItems()
        {
            foreach (ServingSize s in Enum.GetValues(typeof(ServingSize)))
            {
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is AppleFritters x)
                    {
                        if (x.Glazed == true && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is AppleFritters x)
                    {
                        if (x.Glazed == false && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedBananas x)
                    {
                        if (x.Glazed == true && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedBananas x)
                    {
                        if (x.Glazed == false && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedCheesecake x)
                    {
                        if (x.Glazed == true && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedCheesecake x)
                    {
                        if (x.Glazed == false && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedOreos x)
                    {
                        if (x.Glazed == true && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Poppers, item =>
                {
                    if (item is FriedOreos x)
                    {
                        if (x.Glazed == false && x.Size == s) return true;
                    }
                    return false;
                });
            }
        }

        /// <summary>
        /// Checks if all the platters are unique.
        /// </summary>
        [Fact]
        public void AllUniquePlatterItems()
        {
            foreach (ServingSize s in Enum.GetValues(typeof(ServingSize)))
            {
                Assert.Contains(Menu.Platters, item =>
                {
                    if (item is PopperPlatter x)
                    {
                        if (x.Glazed == true && x.Size == s) return true;
                    }
                    return false;
                });
                Assert.Contains(Menu.Platters, item =>
                {
                    if (item is PopperPlatter x)
                    {
                        if (x.Glazed == false && x.Size == s) return true;
                    }
                    return false;
                });
            }

            foreach(PieFilling pie1 in Enum.GetValues(typeof(PieFilling)))
            {
                foreach (PieFilling pie2 in Enum.GetValues(typeof(PieFilling)))
                {
                    foreach (IceCreamFlavor ice1 in Enum.GetValues(typeof(IceCreamFlavor)))
                    {
                        foreach (IceCreamFlavor ice2 in Enum.GetValues(typeof(IceCreamFlavor)))
                        {
                            Assert.Contains(Menu.Platters, item =>
                            {
                                if (item is PiperPlatter x)
                                {
                                    if (x.LeftPie.Flavor == pie1 && x.RightPie.Flavor == pie1 && x.LeftIceCream.Flavor == ice1 && x.RightIceCream.Flavor == ice2) return true;
                                }
                                return false;
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if all items are unique
        /// </summary>
        [Fact]
        public void AllUniqueMenuItems()
        {
            AllUniqueTreatItems();
            AllUniquePopperItems();
            AllUniquePlatterItems();
        }
    }
}
