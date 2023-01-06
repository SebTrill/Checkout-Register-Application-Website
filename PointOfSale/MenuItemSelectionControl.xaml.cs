using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FriedPiper.Data;
using FriedPiper.Data.MenuItems;

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// This is a private variable.
        /// </summary>
        private MainWindow _menu;

        public MenuItemSelectionControl(MainWindow menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        // TREATS //

        /// <summary>
        /// This is the event handler for the FriedPie button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedPieHandler(object sender, RoutedEventArgs e)
        {
            _menu.borderContainer.Child = new FriedPieCustomization();
            FriedPie pie = new();
            ((Order)_menu.DataContext).Add(pie);
            ((FriedPieCustomization)_menu.borderContainer.Child).DataContext = pie;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedIceCream button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedIceCreamHandler(object sender, RoutedEventArgs e)
        {
            _menu.borderContainer.Child = new FriedIceCreamCustomization();
            FriedIceCream item = new();
            ((Order)_menu.DataContext).Add(item);
            ((FriedIceCreamCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedCandyBar button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedCandyBarHandler(object sender, RoutedEventArgs e)
        {
            _menu.borderContainer.Child = new FriedCandyBarCustomization();
            FriedCandyBar item = new();
            ((Order)_menu.DataContext).Add(item);
            ((FriedCandyBarCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedTwinkie button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedTwinkiesHandler(object sender, RoutedEventArgs e)
        {
            FriedTwinkieCustomization twink = new FriedTwinkieCustomization();
            _menu.borderContainer.Child = twink;
            FriedTwinkie item = new();

            twink.flavorDropdown.Items.Add("No Flavor");

            ((Order)_menu.DataContext).Add(item);
            ((FriedTwinkieCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        // POPPERS //

        /// <summary>
        /// This is the event handler for the AppleFritter button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void AppleFrittersHandler(object sender, RoutedEventArgs e)
        {
            PoppersCustomization newpopper = new();
            _menu.borderContainer.Child = newpopper;
            AppleFritters item = new();

            newpopper.glazedDropdown.Items.Add(true);
            newpopper.glazedDropdown.Items.Add(false);
            newpopper.itemName.Text = "Customize Apple Fritter";

            ((Order)_menu.DataContext).Add(item);
            ((PoppersCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedBananas button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedBananasHandler(object sender, RoutedEventArgs e)
        {
            PoppersCustomization newpopper = new();
            _menu.borderContainer.Child = newpopper;
            FriedBananas item = new();

            newpopper.glazedDropdown.Items.Add(true);
            newpopper.glazedDropdown.Items.Add(false);
            newpopper.itemName.Text = "Customize Fried Banana";

            ((Order)_menu.DataContext).Add(item);
            ((PoppersCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedCheesecake button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedCheesecakeHandler(object sender, RoutedEventArgs e)
        {
            PoppersCustomization newpopper = new();
            _menu.borderContainer.Child = newpopper;
            FriedCheesecake item = new();

            newpopper.glazedDropdown.Items.Add(true);
            newpopper.glazedDropdown.Items.Add(false);
            newpopper.itemName.Text = "Customize Fried Cheesecake";

            ((Order)_menu.DataContext).Add(item);
            ((PoppersCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the FriedOreos button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void FriedOreosHandler(object sender, RoutedEventArgs e)
        {
            PoppersCustomization newpopper = new();
            _menu.borderContainer.Child = newpopper;
            FriedOreos item = new();

            newpopper.glazedDropdown.Items.Add(true);
            newpopper.glazedDropdown.Items.Add(false);
            newpopper.itemName.Text = "Customize Fried Oreo";

            ((Order)_menu.DataContext).Add(item);
            ((PoppersCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        // PLATTERS //

        /// <summary>
        /// This is the event handler for the PiperPlatter button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void PiperPlatterHandler(object sender, RoutedEventArgs e)
        {
            _menu.borderContainer.Child = new PiperPlatterCustomization();
            PiperPlatter item = new();
            ((Order)_menu.DataContext).Add(item);
            ((PiperPlatterCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }

        /// <summary>
        /// This is the event handler for the PopperPlatter button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void PopperPlatterHandler(object sender, RoutedEventArgs e)
        {
            PopperPlatterCustomization newpopper = new();
            _menu.borderContainer.Child = newpopper;
            PopperPlatter item = new(ServingSize.Small, true);

            newpopper.glazedDropdown.Items.Add(true);
            newpopper.glazedDropdown.Items.Add(false);

            ((Order)(_menu.DataContext)).Add(item);
            ((PopperPlatterCustomization)_menu.borderContainer.Child).DataContext = item;
            _menu.selectMore.IsEnabled = true;
        }
    }
}
