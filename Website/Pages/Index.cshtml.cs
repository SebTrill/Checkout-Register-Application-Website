using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;

namespace Website.Pages
{
    /// <summary>
    /// This is the index  model.
    /// </summary>
    public class IndexModel : PageModel
    {
        /*
        /// <summary>
        /// This is the backing for the logger.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;
        */

        /// <summary>
        /// This is the entire menu.
        /// </summary>
        public IEnumerable<IMenuItem> Menu { get; set; }

        /// <summary>
        /// This is the list of treats.
        /// </summary>
        public IEnumerable<IMenuItem> Treats { get; set; }

        /// <summary>
        /// This is the list of poppers.
        /// </summary>
        public IEnumerable<IMenuItem> Poppers { get; set; }

        /// <summary>
        /// This is the list of platters.
        /// </summary>
        public IEnumerable<IMenuItem> Platters { get; set; }

        /// <summary>
        /// This is the term that is searched.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// This is the max range of price.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// This is the min range of price.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// This is the max range for calories.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? CalorieMax { get; set; }

        /// <summary>
        /// This is the min range for calories.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? CalorieMin { get; set; }

        /// <summary>
        /// This is the name of the type.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string Treat { get; set; }

        /// <summary>
        /// This is the name of the type.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string Popper { get; set; }

        /// <summary>
        /// This is the name of the type.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string Platter { get; set; }

        /// <summary>
        /// These are the different types of items.
        /// </summary>
        public string[] Names = { "Treats", "Poppers", "Platters" };

        /*
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        */

        /// <summary>
        /// This is the GET.
        /// </summary>
        public void OnGet()
        {
            Menu = FriedPiper.Data.Menu.FullMenu;

            if (SearchTerms != null) // Filters through the search term.
            {
                List<IMenuItem> temp = new List<IMenuItem>();
                char[] sep = { ' ', ',' };
                var terms = SearchTerms.Split(sep);
                foreach (string str in terms)
                {
                    foreach (IMenuItem item in Menu)
                    {
                        if (item.Name != null && item.Name.Contains(str, StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!(temp.Contains(item))) temp.Add(item);
                        }
                    }
                }
                Menu = temp;
            }

            if(Treat != null || Popper != null || Platter != null) // This filters by type.
            {
                List<IMenuItem> list = new List<IMenuItem>();
                if (Treat != null)
                {
                    foreach (IMenuItem item in Menu)
                    {
                        if (item is FriedPie a) list.Add(a);
                        if (item is FriedTwinkie b) list.Add(b);
                        if (item is FriedIceCream c) list.Add(c);
                        if (item is FriedCandyBar d) list.Add(d);
                    }
                }
                if (Popper != null)
                {
                    foreach (IMenuItem item in Menu)
                    {
                        if (item is FriedBananas e) list.Add(e);
                        if (item is FriedCheesecake f) list.Add(f);
                        if (item is FriedOreos g) list.Add(g);
                        if (item is AppleFritters h) list.Add(h);
                    }
                }
                if (Platter != null)
                {
                    foreach (IMenuItem item in Menu)
                    {
                        if (item is PiperPlatter i) list.Add(i);
                        if (item is PopperPlatter j) list.Add(j);
                    }
                }
                Menu = list;
            }

            if (!(PriceMin == null && PriceMax == null)) // This filters through price.
            {
                if (PriceMin == null) Menu = Menu.Where(menu => menu.Price <= PriceMax);
                else if (PriceMax == null)  Menu = Menu.Where(menu => menu.Price >= PriceMin);
                else Menu = Menu.Where(menu => menu.Price >= PriceMin && menu.Price <= PriceMax);
            }

            if (!(CalorieMin == null && CalorieMax == null)) // This filters through calories.
            {
                if (CalorieMin == null) Menu = Menu.Where(menu => menu.Calories <= CalorieMax);
                else if (CalorieMax == null) Menu = Menu.Where(menu => menu.Calories >= CalorieMin);
                else Menu = Menu.Where(menu => menu.Calories >= CalorieMin && menu.Calories <= CalorieMax);
            }

            OrganizeMenu();
        }

        /// <summary>
        /// This organizes the menu.
        /// </summary>
        void OrganizeMenu()
        {
            List<IMenuItem> treats = new List<IMenuItem>();
            List<IMenuItem> poppers = new List<IMenuItem>();
            List<IMenuItem> platters = new List<IMenuItem>();

            foreach (IMenuItem item in Menu)
            {
                if (item is FriedPie a) treats.Add(a);
                if (item is FriedTwinkie b) treats.Add(b);
                if (item is FriedIceCream c) treats.Add(c);
                if (item is FriedCandyBar d) treats.Add(d);
                if (item is FriedBananas e) poppers.Add(e);
                if (item is FriedCheesecake f) poppers.Add(f);
                if (item is FriedOreos g) poppers.Add(g);
                if (item is AppleFritters h) poppers.Add(h);
                if (item is PiperPlatter i) platters.Add(i);
                if (item is PopperPlatter j) platters.Add(j);
            }

            Treats = treats;
            Poppers = poppers;
            Platters = platters;
        }
    }
}
