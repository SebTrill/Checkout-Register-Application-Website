using FriedPiper.Data.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriedPiper.Data
{
    /// <summary>
    /// This is the menu.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// private backing variable for the treats.
        /// </summary>
        static List<IMenuItem> _treats = new();

        /// <summary>
        /// This populates the traet list.
        /// </summary>
        /// <param name="list">This is the list.</param>
        static void PopulateTreatList(List<IMenuItem> list)
        {
            foreach(PieFilling p in Enum.GetValues(typeof(PieFilling)))
            {
                FriedPie pie = new();
                pie.Flavor = p;
                list.Add(pie);
            }
            foreach (IceCreamFlavor i in Enum.GetValues(typeof(IceCreamFlavor)))
            {
                FriedIceCream ice = new();
                ice.Flavor = i;
                list.Add(ice);
            }
            foreach (CandyBar c in Enum.GetValues(typeof(CandyBar)))
            {
                FriedCandyBar bar = new();
                bar.Flavor = c;
                list.Add(bar);
            }
            list.Add(new FriedTwinkie());
        }

        /// <summary>
        /// This returns an IEnumerable containing an instance of all available fried treats.
        /// </summary>
        public static IEnumerable<IMenuItem> Treats
        {
            get
            {
                if(_treats.Count == 0) PopulateTreatList(_treats);
                foreach(IMenuItem i in _treats)
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// This fills the popper list.
        /// </summary>
        /// <param name="list">This is the list.</param>
        static void PopulatePopperList(List<IMenuItem> list)
        {
            foreach(ServingSize s in Enum.GetValues(typeof(ServingSize)))
            {
                AppleFritters item1 = new AppleFritters
                {
                    Size = s,
                    Glazed = true
                };
                AppleFritters item2 = new AppleFritters
                {
                    Size = s,
                    Glazed = false
                };
                FriedBananas item3 = new FriedBananas
                {
                    Size = s,
                    Glazed = true
                };
                FriedBananas item4 = new FriedBananas
                {
                    Size = s,
                    Glazed = false
                };
                FriedCheesecake item5 = new FriedCheesecake
                {
                    Size = s,
                    Glazed = true
                };
                FriedCheesecake item6 = new FriedCheesecake
                {
                    Size = s,
                    Glazed = false
                };
                FriedOreos item7 = new FriedOreos
                {
                    Size = s,
                    Glazed = true
                };
                FriedOreos item8 = new FriedOreos
                {
                    Size = s,
                    Glazed = false
                };
                list.Add(item1);
                list.Add(item2);
                list.Add(item3);
                list.Add(item4);
                list.Add(item5);
                list.Add(item6);
                list.Add(item7);
                list.Add(item8);
            }
        }

        /// <summary>
        /// This is the backing variable for the poppers.
        /// </summary>
        static List<IMenuItem> _poppers = new();

        /// <summary>
        /// This returns an IEnumerable containing an instance of all available poppers.
        /// </summary>
        public static IEnumerable<IMenuItem> Poppers
        {
            get
            {
                if (_poppers.Count == 0) PopulatePopperList(_poppers);
                foreach (IMenuItem i in _poppers)
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Private backing variable for the platters.
        /// </summary>
        static List<IMenuItem> _platters = new();

        /// <summary>
        /// This populates the platter list.
        /// </summary>
        /// <param name="list">This is the list.</param>
        static void PopulatePlatterList(List<IMenuItem> list)
        {
            foreach (ServingSize s in Enum.GetValues(typeof(ServingSize)))
            {
                PopperPlatter item1 = new(s, true);
                PopperPlatter item2 = new(s, false);
                list.Add(item1);
                list.Add(item2);
            }

            foreach(PieFilling f1 in Enum.GetValues(typeof(PieFilling)))
            {
                foreach (PieFilling f2 in Enum.GetValues(typeof(PieFilling)))
                {
                    foreach (IceCreamFlavor f3 in Enum.GetValues(typeof(IceCreamFlavor)))
                    {
                        foreach (IceCreamFlavor f4 in Enum.GetValues(typeof(IceCreamFlavor)))
                        {
                            PiperPlatter p = new();
                            p.LeftPie.Flavor = f1;
                            p.RightPie.Flavor = f2;
                            p.LeftIceCream.Flavor = f3;
                            p.RightIceCream.Flavor = f4;
                            list.Add(p);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This returns an IEnumerable containing all available platters.
        /// </summary>
        public static IEnumerable<IMenuItem> Platters
        {
            get
            {
                if (_platters.Count == 0) PopulatePlatterList(_platters);
                foreach (IMenuItem i in _platters)
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Private backing variable for the fullmenu.
        /// </summary>
        static List<IMenuItem> _fullMenu = new();

        /// <summary>
        /// this fills the menu list.
        /// </summary>
        static void FillMenu()
        {
            PopulateTreatList(_fullMenu);
            PopulatePopperList(_fullMenu);
            PopulatePlatterList(_fullMenu);
        }

        /// <summary>
        /// This return an IEnumerable containing all of the items on the menu.
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                if (_fullMenu.Count == 0) FillMenu();
                foreach (IMenuItem i in _fullMenu)
                {
                    yield return i;
                }
            }
        }
    }
}
