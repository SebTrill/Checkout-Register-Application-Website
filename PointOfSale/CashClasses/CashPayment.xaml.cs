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
using RoundRegister;

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashPayment.xaml
    /// </summary>
    public partial class CashPayment : UserControl
    {
        /// <summary>
        /// This is the backing for the Main Window.
        /// </summary>
        private MainWindow _main;

        /// <summary>
        /// This is a private backing for the Cash Drawer.
        /// </summary>
        private CashDrawerVM _cdvm;

        /// <summary>
        /// Private backing for the payment options.
        /// </summary>
        private PaymentOptions _pay;

        /// <summary>
        /// This is a backing var for the amount due.
        /// </summary>
        private decimal _amount_due = 0m;

        public CashPayment(MainWindow main, PaymentOptions pay)
        {
            InitializeComponent();
            _amount_due = ((Order)main.DataContext).Total;
            CashDrawerVM cdvm = new(_main, _amount_due);
            this.DataContext = cdvm;
            _main = main;
            _pay = pay;
            _cdvm = cdvm;

            hundreds.amountName.Text = "$100";
            fifties.amountName.Text = "$50";
            twenties.amountName.Text = "$20";
            tens.amountName.Text = "$10";
            fives.amountName.Text = "$5";
            twos.amountName.Text = "$2";
            ones.amountName.Text = "$1";

            dollar_coin.amountName.Text = "100₵";
            fifty_cents.amountName.Text = "50₵";
            twenty_five_cents.amountName.Text = "25₵";
            ten_cents.amountName.Text = "10₵";
            five_cents.amountName.Text = "5₵";
            pennies.amountName.Text = "1₵";

            amountDue.text.Text = "Amount Due";
            //totalSale.amount.Text = String.Format("{0:C}", _amount_due);
            //CheckAmountDue(cdvm);
            changeOwed.text.Text = "Change Owed";
            //changeOwed.amount.Text = String.Format("{0:c}", cdvm.ChangeTotal);
        }

        /// <summary>
        /// This button returns to the order.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        void ReturnHandler(object sender, RoutedEventArgs e)
        {
            _main.borderContainer.Child = new MenuItemSelectionControl(_main);
        }

        /// <summary>
        /// This button finalizes the order.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        void FinalizeHandler(object sender, RoutedEventArgs e)
        {
            decimal change_total = _cdvm.FinalizeSale();            

            _pay.PrintReceipt('b', change_total);
            _main.DataContext = new Order();
            _main.borderContainer.Child = new MenuItemSelectionControl(_main);
            _main.selectMore.IsEnabled = false;
        }

        /// <summary>
        /// This is a helper for the finalize button.
        /// </summary>
        /// <param name="drawer">This is the drawer number.</param>
        /// <param name="payment">This is the payment number.</param>
        /// <param name="change">This is the change number.</param>
        /// <returns>Returns the number in the drawer.</returns>
        uint Helper(uint drawer, uint payment, uint change)
        {
            if (payment != 0)
            {
                drawer += payment;
                if (change != 0) drawer -= change;
            }
            return drawer;
        }
    }
}
