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

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// private variable.
        /// </summary>
        private MenuItemSelectionControl _menu;

        /// <summary>
        /// This is my cash drawer model view.
        /// </summary>
        public CashDrawerVM cdmv;

        public MainWindow()
        {
            InitializeComponent();
            _menu = new MenuItemSelectionControl(this);
            //cdmv = new CashDrawerVM(this);
            borderContainer.Child = _menu;
            selectMore.IsEnabled = false;
            this.DataContext = new Order();
        }

        /// <summary>
        /// This is the event handler for the Cancel Order button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void CancelOrderHandler(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Order();
            borderContainer.Child = _menu;
            selectMore.IsEnabled = false;
        }

        /// <summary>
        /// This is the event handler for the Select More Items button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void SelectMoreItemsHandler(object sender, RoutedEventArgs e)
        {
            ((Order)this.DataContext).Update();
            borderContainer.Child = _menu;
            selectMore.IsEnabled = false;
            //order.orderDetails.SelectedItem = null;
        }

        /// <summary>
        /// This is the event handler for the Complete Order button.
        /// </summary>
        /// <param name="sender">This is the button object.</param>
        /// <param name="e">This is the argument.</param>
        public void CompleteOrderHandler(object sender, RoutedEventArgs e)
        {
            borderContainer.Child = new PaymentOptions(this);
            selectMore.IsEnabled = false;
        }

        /// <summary>
        /// Shows up when there is not enough change.
        /// </summary>
        public void ShowMessage()
        {
            MessageBox.Show("Not Enough Change");
        }
    }
}
