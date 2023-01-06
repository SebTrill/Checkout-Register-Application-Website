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
using FriedPiper.Data.MenuItems;
using FriedPiper.Data;

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the remove button in the control.
        /// </summary>
        /// <param name="sender">This is the remove button.</param>
        /// <param name="e">This is the argument.</param>
        void OnRemoveButton(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)((DockPanel)((Grid)this.Parent).Parent).Parent;
            ((Order)this.DataContext).Remove((IMenuItem)((Button)sender).DataContext);
            if (!(win.borderContainer.Child is MenuItemSelectionControl)) win.borderContainer.Child = new MenuItemSelectionControl(win);
            ((Order)this.DataContext).Update();
        }

        /// <summary>
        /// This displays more info.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        void DisplayMoreInfo(object sender, RoutedEventArgs e)
        {
            if(((Border)sender).DataContext is Popper)
            {
                if(((Popper)(((Border)sender).DataContext)).Glazed == false)
                {
                    ((Border)sender).Child = new PopperDisplay();
                }
                else if (((Popper)(((Border)sender).DataContext)).Glazed == true)
                {
                    ((Border)sender).Child = new PopperDisplay2();
                }
            }
            else if (((Border)sender).DataContext is PopperPlatter)
            {
                if (((PopperPlatter)(((Border)sender).DataContext)).Glazed == false)
                {
                    ((Border)sender).Child = new PopperDisplay();
                }
                else if (((PopperPlatter)(((Border)sender).DataContext)).Glazed == true)
                {
                    ((Border)sender).Child = new PopperDisplay2();
                }
            }
            else if (((Border)sender).DataContext is PiperPlatter)
            {
                ((Border)sender).Child = new PiperPlatterDisplay();
            }
        }

        /// <summary>
        /// This edits the item.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        void EditAnExistingItem(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)((DockPanel)((Grid)this.Parent).Parent).Parent;

            if(((ListView)sender).SelectedItem is AppleFritters)
            {
                PoppersCustomization pop = new();
                pop.glazedDropdown.Items.Add(true);
                pop.glazedDropdown.Items.Add(false);
                win.borderContainer.Child = pop;
                ((PoppersCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedBananas)
            {
                PoppersCustomization pop = new();
                pop.glazedDropdown.Items.Add(true);
                pop.glazedDropdown.Items.Add(false);
                win.borderContainer.Child = pop;
                ((PoppersCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedCheesecake)
            {
                PoppersCustomization pop = new();
                pop.glazedDropdown.Items.Add(true);
                pop.glazedDropdown.Items.Add(false);
                win.borderContainer.Child = pop;
                ((PoppersCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedOreos)
            {
                PoppersCustomization pop = new();
                pop.glazedDropdown.Items.Add(true);
                pop.glazedDropdown.Items.Add(false);
                win.borderContainer.Child = pop;
                ((PoppersCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedCandyBar)
            {
                win.borderContainer.Child = new FriedCandyBarCustomization();
                ((FriedCandyBarCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedIceCream)
            {
                win.borderContainer.Child = new FriedIceCreamCustomization();
                ((FriedIceCreamCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedPie)
            {
                win.borderContainer.Child = new FriedPieCustomization();
                ((FriedPieCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is FriedTwinkie)
            {
                win.borderContainer.Child = new FriedTwinkieCustomization();
                ((FriedTwinkieCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is PopperPlatter)
            {
                PopperPlatterCustomization pop = new();
                pop.glazedDropdown.Items.Add(true);
                pop.glazedDropdown.Items.Add(false);
                win.borderContainer.Child = pop;
                ((PopperPlatterCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
            else if (((ListView)sender).SelectedItem is PiperPlatter)
            {
                win.borderContainer.Child = new PiperPlatterCustomization();
                ((PiperPlatterCustomization)win.borderContainer.Child).DataContext = ((ListView)sender).SelectedItem;
                win.selectMore.IsEnabled = true;
            }
        }
    }
}
