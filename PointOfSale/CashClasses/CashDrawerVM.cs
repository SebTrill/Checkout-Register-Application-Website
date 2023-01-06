using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundRegister;

namespace FriedPiper.PointOfSale
{
    /// <summary>
    /// This is the View Model for the Cash Drawer.
    /// </summary>
    public class CashDrawerVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// backing var;
        /// </summary>
        private MainWindow _main;

        /// <summary>
        /// Backing field for the number of dollars or coins needed.
        /// </summary>
        private uint[] _change = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public CashDrawerVM(MainWindow main, decimal order_total)
        {
            _main = main;
            _orderTotal = order_total;
        }

        /// <summary>
        /// These are the cash types.
        /// </summary>
        public enum CashTypes
        {
            HUNDRED,
            FIFTY,
            TWENTY,
            TEN,
            FIVE,
            TWO,
            ONE,
            DOLLAR,
            HALFDOLLAR,
            QUARTER,
            DIME,
            NICKEL,
            PENNY
        }

        /// <summary>
        /// invokes property changed.
        /// </summary>
        /// <param name="propertyname">property name.</param>
        protected virtual void OnPropertyChanged(string propertyname)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        /// <summary>
        /// This gets and sets the amount of change.
        /// </summary>
        public uint PenniesDrawer
        {
            get => CashDrawer.Pennies;
            set { CashDrawer.Pennies = value; OnPropertyChanged("PenniesDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _penniesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint PenniesPayment
        {
            get => _penniesPayment;
            set { _penniesPayment = value; OnPropertyChanged("PenniesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint PenniesChange
        {
            get => _change[(int)CashTypes.PENNY];
        }

        /// <summary>
        /// This gets and sets the amount of Nickles.
        /// </summary>
        public uint NickelsDrawer
        {
            get => CashDrawer.Nickles;
            set { CashDrawer.Nickles = value; OnPropertyChanged("NickelsDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _nickelsPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint NickelsPayment
        {
            get => _nickelsPayment;
            set { _nickelsPayment = value; OnPropertyChanged("NickelsPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint NickelsChange
        {
            get => _change[(int)CashTypes.NICKEL];
        }

        /// <summary>
        /// This gets and sets the amount of Dimes.
        /// </summary>
        public uint DimesDrawer
        {
            get => CashDrawer.Dimes;
            set { CashDrawer.Dimes = value; OnPropertyChanged("DimesDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _dimesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint DimesPayment
        {
            get => _dimesPayment;
            set { _dimesPayment = value; OnPropertyChanged("DimesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint DimesChange
        {
            get => _change[(int)CashTypes.DIME];
        }

        /// <summary>
        /// This gets and sets the amount of Quarters.
        /// </summary>
        public uint QuartersDrawer
        {
            get => CashDrawer.Quarters;
            set { CashDrawer.Quarters = value; OnPropertyChanged("QuartersDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _quartersPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint QuartersPayment
        {
            get => _quartersPayment;
            set { _quartersPayment = value; OnPropertyChanged("QuartersPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint QuartersChange
        {
            get => _change[(int)CashTypes.QUARTER];
        }

        /// <summary>
        /// This gets and sets the amount of Half Dollars.
        /// </summary>
        public uint HalfDollarsDrawer
        {
            get => CashDrawer.HalfDollarCoins;
            set { CashDrawer.HalfDollarCoins = value; OnPropertyChanged("HalfDollarsDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _halfDollarsPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint HalfDollarsPayment
        {
            get => _halfDollarsPayment;
            set { _halfDollarsPayment = value; OnPropertyChanged("HalfDollarsPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint HalfDollarsChange
        {
            get => _change[(int)CashTypes.HALFDOLLAR];
        }

        /// <summary>
        /// This gets and sets the amount of Dollar Coins.
        /// </summary>
        public uint DollarCoinsDrawer
        {
            get => CashDrawer.DollarCoins;
            set { CashDrawer.DollarCoins = value; OnPropertyChanged("DollarCoinsDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _dollarCoinsPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint DollarCoinsPayment
        {
            get => _dollarCoinsPayment;
            set { _dollarCoinsPayment = value; OnPropertyChanged("DollarCoinsPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint DollarCoinsChange
        {
            get => _change[(int)CashTypes.DOLLAR];
        }

        /// <summary>
        /// This gets and sets the amount of Ones.
        /// </summary>
        public uint OnesDrawer
        {
            get => CashDrawer.Ones;
            set { CashDrawer.Ones = value; OnPropertyChanged("OnesDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _onesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint OnesPayment
        {
            get => _onesPayment;
            set { _onesPayment = value; OnPropertyChanged("OnesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint OnesChange
        {
            get => _change[(int)CashTypes.ONE];
        }

        /// <summary>
        /// This gets and sets the amount of Twos.
        /// </summary>
        public uint TwosDrawer
        {
            get => CashDrawer.Twos;
            set { CashDrawer.Twos = value; OnPropertyChanged("TwosDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _twosPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint TwosPayment
        {
            get => _twosPayment;
            set { _twosPayment = value; OnPropertyChanged("TwosPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint TwosChange
        {
            get => _change[(int)CashTypes.TWO];
        }

        /// <summary>
        /// This gets and sets the amount of Fives.
        /// </summary>
        public uint FivesDrawer
        {
            get => CashDrawer.Fives;
            set { CashDrawer.Fives = value; OnPropertyChanged("FivesDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _fivesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint FivesPayment
        {
            get => _fivesPayment;
            set { _fivesPayment = value; OnPropertyChanged("FivesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint FivesChange
        {
            get => _change[(int)CashTypes.FIVE];
        }

        /// <summary>
        /// This gets and sets the amount of Tens.
        /// </summary>
        public uint TensDrawer
        {
            get => CashDrawer.Tens;
            set { CashDrawer.Tens = value; OnPropertyChanged("TensDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _tensPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint TensPayment
        {
            get => _tensPayment;
            set { _tensPayment = value; OnPropertyChanged("TensPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint TensChange
        {
            get => _change[(int)CashTypes.TEN];
        }

        /// <summary>
        /// This gets and sets the amount of Twenties.
        /// </summary>
        public uint TwentiesDrawer
        {
            get => CashDrawer.Twenties;
            set { CashDrawer.Twenties = value; OnPropertyChanged("TensDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _twentiesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint TwentiesPayment
        {
            get => _twentiesPayment;
            set { _twentiesPayment = value; OnPropertyChanged("TwentiesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint TwentiesChange
        {
            get => _change[(int)CashTypes.TWENTY];
        }

        /// <summary>
        /// This gets and sets the amount of Fifties.
        /// </summary>
        public uint FiftiesDrawer
        {
            get => CashDrawer.Fifties;
            set { CashDrawer.Fifties = value; OnPropertyChanged("FiftiesDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _fiftiesPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint FiftiesPayment
        {
            get => _fiftiesPayment;
            set { _fiftiesPayment = value; OnPropertyChanged("FiftiesPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint FiftiesChange
        {
            get => _change[(int)CashTypes.FIFTY];
        }

        /// <summary>
        /// This gets and sets the amount of Hundreds.
        /// </summary>
        public uint HundredsDrawer
        {
            get => CashDrawer.Hundreds;
            set { CashDrawer.Hundreds = value; OnPropertyChanged("HundredsDrawer"); }
        }

        /// <summary>
        /// the private backing for the change in payment.
        /// </summary>
        private uint _hundredsPayment = 0;

        /// <summary>
        /// This gets and sets the change that the customer gives
        /// </summary>
        public uint HundredsPayment
        {
            get => _hundredsPayment;
            set { _hundredsPayment = value; OnPropertyChanged("HundredsPayment"); OnChange(); }
        }

        /// <summary>
        /// This gets and sets the change
        /// </summary>
        public uint HundredsChange
        {
            get => _change[(int)CashTypes.HUNDRED];
        }

        /// <summary>
        /// This covers the property changed of the change.
        /// </summary>
        void OnChange()
        {
            GetChange();
            OnPropertyChanged("ChangeTotal");
            OnPropertyChanged("PaymentTotal");
            OnPropertyChanged("AmountsDue");
            OnPropertyChanged("PenniesChange");
            OnPropertyChanged("NickelsChange");
            OnPropertyChanged("DimesChange");
            OnPropertyChanged("QuartersChange");
            OnPropertyChanged("HalfDollarsChange");
            OnPropertyChanged("DollarCoinsChange");
            OnPropertyChanged("OnesChange");
            OnPropertyChanged("TwosChange");
            OnPropertyChanged("FivesChange");
            OnPropertyChanged("TensChange");
            OnPropertyChanged("TwentiesChange");
            OnPropertyChanged("FiftiesChange");
            OnPropertyChanged("HundredsChange");
        }

        /// <summary>
        /// This is the backing var for the order total;
        /// </summary>
        private decimal _orderTotal = 0;

        /// <summary>
        /// This is the order total.
        /// </summary>
        public decimal OrderTotal { get { return _orderTotal; } }

        /// <summary>
        /// This is the payment total.
        /// </summary>
        public decimal PaymentTotal { get { return ((decimal)((100 * HundredsPayment) + (50 * FiftiesPayment) + (20 * TwentiesPayment) + (10 * TensPayment) + (5 * FivesPayment) + (2 * TwosPayment) + 
                    (1 * OnesPayment) + (1 * DollarCoinsPayment) + (0.50 * HalfDollarsPayment) + (0.25 * QuartersPayment) + (0.10 * DimesPayment) + (0.05 * NickelsPayment) + (0.01 * PenniesPayment))); } }

        /// <summary>
        /// This is the change total.
        /// </summary>
        public decimal ChangeTotal
        {
            get
            {
                decimal val = PaymentTotal - OrderTotal;
                if (val > 0) return val;
                else return 0.00m;
            }
        }


        /// <summary>
        /// This is the amount due.
        /// </summary>
        public decimal AmountsDue
        {
            get
            {
                decimal val = OrderTotal - PaymentTotal;
                if (val > 0) return val;
                else return 0.00m;
            }
        }

        /// <summary>
        /// This gets the change.
        /// </summary>
        private void GetChange()
        {
            decimal[] values = { 100.00m, 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 1.00m, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m };
            uint[] amounts = { HundredsDrawer, FiftiesDrawer, TwentiesDrawer, TensDrawer, FivesDrawer, TwosDrawer, OnesDrawer, DollarCoinsDrawer, HalfDollarsDrawer,
                QuartersDrawer, DimesDrawer, NickelsDrawer, PenniesDrawer };
            //_change = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            decimal total = ChangeTotal;

            for(int i = 0; i < values.Length; i++)
            {
                _change[i] = 0;
                while(total >= values[i] && amounts[i] > 0)
                {
                    total = total - values[i];
                    amounts[i]--;
                    _change[i]++;
                }
            }
        }

        /// <summary>
        /// This is a helper for the finalize button in the Cash Payment class.
        /// </summary>
        /// <returns>This returns the Change Total.</returns>
        public decimal FinalizeSale()
        {
            CashDrawer.Open();

            PenniesDrawer += PenniesPayment - PenniesChange;
            NickelsDrawer += NickelsPayment - NickelsChange;
            DimesDrawer += DimesPayment - DimesChange;
            QuartersDrawer += QuartersPayment - QuartersChange;
            HalfDollarsDrawer += HalfDollarsPayment - HalfDollarsChange;
            DollarCoinsDrawer += DollarCoinsPayment - DollarCoinsChange;
            OnesDrawer += OnesPayment - OnesChange;
            TwosDrawer += TwosPayment - TwosChange;
            FivesDrawer += FivesPayment - FivesChange;
            TensDrawer += TensPayment - TensChange;
            TwentiesDrawer += TwentiesPayment - TwentiesChange;
            FiftiesDrawer += FiftiesPayment - FiftiesChange;
            HundredsDrawer += HundredsPayment - HundredsChange;

            return ChangeTotal;
        }
    }
}
