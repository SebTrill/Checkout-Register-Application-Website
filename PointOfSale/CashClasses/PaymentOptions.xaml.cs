using FriedPiper.Data;
using FriedPiper.Data.MenuItems;
using RoundRegister;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        /// <summary>
        /// This is the backing for the MainWindow parameter.
        /// </summary>
        private MainWindow _main;

        public PaymentOptions(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        /// <summary>
        /// This is the handler for the cash payment button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        void CashPaymentHandler(object sender, RoutedEventArgs e)
        {
            var t = new CashPayment(_main, this);
            if(this.DataContext is Order o)
            {
                //t.DataContext = new CashDrawerVM(_main, o.Total);
                _main.borderContainer.Child = t;
            }
        }

        /// <summary>
        /// This is the handler for the card payment button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        void CardPaymentHandler(object sender, RoutedEventArgs e)
        {
            CardTransactionResult result = CardReader.RunCard();
            
            switch (result)
            {
                case CardTransactionResult.Declined:
                    MessageBox.Show("Card Decline: ur broke");
                    break;
                case CardTransactionResult.ReadError:
                    MessageBox.Show("Card read error: ur card is broke");
                    break;
                case CardTransactionResult.InsufficientFunds:
                    MessageBox.Show("Insufficient Funds: no ur ACTUALLY broke");
                    break;
                case CardTransactionResult.IncorrectPin:
                    MessageBox.Show("Incorrect Pin: bro, is this even ur card?");
                    break;
                case CardTransactionResult.Approved:
                    MessageBox.Show("Transaction Approved");
                    PrintReceipt('a', 0);
                    _main.DataContext = new Order();
                    _main.borderContainer.Child = new MenuItemSelectionControl(_main);
                    _main.selectMore.IsEnabled = false;
                    break;
            }
        }

        /// <summary>
        /// This prints the receipt.
        /// </summary>
        /// <param name="type">This is the type of payment.</param>
        /// <param name="change_due">This is the amount of change due.</param>
        public void PrintReceipt(char type, decimal change_due)
        {
            Order current = (Order)_main.DataContext;
            ReceiptPrinter.PrintLine(current.OrderNumber);
            ReceiptPrinter.PrintLine(DateTime.Now.ToString());
            ReceiptPrinter.PrintLine("");
            IMenuItem[] items = new IMenuItem[current.Count];
            current.CopyTo(items, 0);

            foreach (IMenuItem item in items)
            {
                string[] customize;
                var str = MakeReceiptLine(item, out customize);
                ReceiptPrinter.PrintLine(str);

                if (!customize[0].Equals(""))
                {
                    if(item is Popper)
                    {
                        ReceiptPrinter.PrintLine("  " + customize[0]);
                    }
                    else if (item is PopperPlatter)
                    {
                        ReceiptPrinter.PrintLine("  " + customize[0]);
                    }
                    else if (item is PiperPlatter)
                    {
                        ReceiptPrinter.PrintLine("  " + customize[0]);
                        ReceiptPrinter.PrintLine("  " + customize[1]);
                        ReceiptPrinter.PrintLine("  " + customize[2]);
                        ReceiptPrinter.PrintLine("  " + customize[3]);
                    }
                }
            }

            ReceiptPrinter.PrintLine("");
            ReceiptPrinter.PrintLine("Subtotal: " + String.Format("{0:C}", current.Subtotal));
            ReceiptPrinter.PrintLine("Tax: " + String.Format("{0:C}", current.Tax));
            ReceiptPrinter.PrintLine("Total: " + String.Format("{0:C}", current.Total));
            ReceiptPrinter.PrintLine("");

            if (type == 'a')
            {
                ReceiptPrinter.PrintLine("Payment Method: Credit/Debit Card");
                ReceiptPrinter.PrintLine("Change Owed: $0.00");
            }
            else if(type == 'b')
            {
                ReceiptPrinter.PrintLine("Payment Method: Cash");
                ReceiptPrinter.PrintLine("Change Owed: " + String.Format("{0:C}", change_due));
            }
            ReceiptPrinter.CutTape();
        }

        /// <summary>
        /// This is the receipt customization.
        /// </summary>
        /// <param name="item">This is the menu item.</param>
        /// <param name="custom">This returns the customized strings.</param>
        /// <returns>Returns the custom made strings.</returns>
        private string MakeReceiptLine(IMenuItem item, out string[] custom)
        {
            custom = new string[4];

            if(item is AppleFritters x)
            {
                if(x.Glazed == false)
                {
                    custom[0] = "No Glaze";
                }
                else
                {
                    custom[0] = "Glazed";
                }
                string price = String.Format("{0:C}", x.Price);
                return x.ToString() + "  " + price;
            }
            else if (item is FriedBananas q)
            {
                if (q.Glazed == false)
                {
                    custom[0] = "No Glaze";
                }
                else
                {
                    custom[0] = "Glazed";
                }
                string price = String.Format("{0:C}", q.Price);
                return q.ToString() + "  " + price;
            }
            else if (item is FriedCheesecake c)
            {
                if (c.Glazed == false)
                {
                    custom[0] = "No Glaze";
                }
                else
                {
                    custom[0] = "Glazed";
                }
                string price = String.Format("{0:C}", c.Price);
                return c.ToString() + "  " + price;
            }
            else if (item is FriedOreos o)
            {
                if (o.Glazed == false)
                {
                    custom[0] = "No Glaze";
                }
                else
                {
                    custom[0] = "Glazed";
                }
                string price = String.Format("{0:C}", o.Price);
                return o.ToString() + "  " + price;
            }
            else if (item is FriedPie p)
            {
                custom[0] = "";
                string price = String.Format("{0:C}", p.Price);
                return p.ToString() + "  " + price;
            }
            else if (item is FriedCandyBar b)
            {
                custom[0] = "";
                string price = String.Format("{0:C}", b.Price);
                return b.ToString() + "  " + price;
            }
            else if (item is FriedIceCream i)
            {
                custom[0] = "";
                string price = String.Format("{0:C}", i.Price);
                return i.ToString() + "  " + price;
            }
            else if (item is FriedTwinkie t)
            {
                custom[0] = "";
                string price = String.Format("{0:C}", t.Price);
                return t.ToString() + "  " + price;
            }
            else if (item is PiperPlatter pip)
            {
                custom[0] = pip.RightPie.ToString();
                custom[1] = pip.LeftPie.ToString();
                custom[2] = pip.RightIceCream.ToString();
                custom[3] = pip.LeftIceCream.ToString();
                string price = String.Format("{0:C}", pip.Price);
                return pip.ToString() + "  " + price;
            }
            else if (item is PopperPlatter pop)
            {
                if (pop.Glazed == false)
                {
                    custom[0] = "No Glaze";
                }
                else
                {
                    custom[0] = "Glazed";
                }
                string price = String.Format("{0:C}", pop.Price);
                return pop.ToString() + "  " + price;
            }

            return "item";
        }

        /// <summary>
        /// This is the handler for the return button.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        void ReturnHandler(object sender, RoutedEventArgs e)
        {
            _main.borderContainer.Child = new MenuItemSelectionControl(_main);
        }
    }
}