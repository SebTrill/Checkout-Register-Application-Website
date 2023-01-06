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

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// Interaction logic for NotFinishedDisplay.xaml
    /// </summary>
    public partial class NotFinishedDisplay : UserControl
    {
        /// <summary>
        /// this is a Main Window backing variable.
        /// </summary>
        private MainWindow _main;

        public NotFinishedDisplay(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        /// <summary>
        /// This goes back to the cash screen.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        void BackHandler(object sender, RoutedEventArgs e)
        {
            //_main.borderContainer.Child = new CashPayment(_main);
        }
    }
}
