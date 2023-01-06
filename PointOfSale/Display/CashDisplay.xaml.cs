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
    /// Interaction logic for CashDisplay.xaml
    /// </summary>
    public partial class CashDisplay : UserControl
    {       
        /// <summary>
        /// framework for the customer quantity.
        /// </summary>
        static FrameworkPropertyMetadata customerMetaData = new FrameworkPropertyMetadata((uint)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsRender); 

        /// <summary>
        /// Customer quantity dependency.
        /// </summary>
        public static DependencyProperty CustomerQuantityProperty = DependencyProperty.Register("CustomerQuantity", typeof(uint), typeof(CashDisplay), customerMetaData);

        /// <summary>
        /// control for customer quantity.
        /// </summary>
        public uint CustomerQuantity
        {
            get => (uint)GetValue(CustomerQuantityProperty);
            set => SetValue(CustomerQuantityProperty, value);
        }

        /// <summary>
        /// framework for the customer quantity.
        /// </summary>
        static FrameworkPropertyMetadata changeMetaData = new FrameworkPropertyMetadata((uint)0, FrameworkPropertyMetadataOptions.AffectsRender);

        /// <summary>
        /// Customer quantity dependency.
        /// </summary>
        public static DependencyProperty ChangeQuantityProperty = DependencyProperty.Register("ChangeQuantity", typeof(uint), typeof(CashDisplay), changeMetaData);

        /// <summary>
        /// control for customer quantity.
        /// </summary>
        public uint ChangeQuantity
        {
            get => (uint)GetValue(ChangeQuantityProperty);
            set => SetValue(ChangeQuantityProperty, value);
        }



        public CashDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Increments the customer count.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        void IncrementHandler(object sender, RoutedEventArgs e)
        {
            CustomerQuantity = CustomerQuantity + 1;
        }

        /// <summary>
        /// Decrements the customer count.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">e.</param>
        void DecrementHandler(object sender, RoutedEventArgs e)
        {
            if(CustomerQuantity != 0)
            {
                CustomerQuantity = CustomerQuantity - 1;
            }
        }
    }
}
