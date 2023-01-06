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
    /// Interaction logic for AmountDisplay.xaml
    /// </summary>
    public partial class AmountDisplay : UserControl
    {
        /// <summary>
        /// Customer quantity dependency.
        /// </summary>
        public static DependencyProperty AmountDueProperty = DependencyProperty.Register("AmountDue", typeof(string), typeof(AmountDisplay), customerMetaData);

        /// <summary>
        /// control for customer quantity.
        /// </summary>
        public uint AmountDue
        {
            get => (uint)GetValue(AmountDueProperty);
            set => SetValue(AmountDueProperty, value);
        }

        /// <summary>
        /// framework for the customer quantity.
        /// </summary>
        static FrameworkPropertyMetadata customerMetaData = new FrameworkPropertyMetadata((string)"$0.00", FrameworkPropertyMetadataOptions.AffectsRender);

        public AmountDisplay()
        {
            InitializeComponent();
        }
    }
}
