using FriedPiper.Data.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FriedPiper.Data
{
    /// <summary>
    /// This class covers the order actions.
    /// </summary>
    public class Order : ObservableCollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        //public event NotifyCollectionChangedEventHandler CollectionChangedTwo;

        //public event PropertyChangedEventHandler PropertyChangedTwo;

        /// <summary>
        /// This gives the time at the placemnt of the order.
        /// </summary>
        public DateTime PlacedAt { get; } = DateTime.Now;

        /// <summary>
        /// This keeps track of the next order number.
        /// </summary>
        private static int _nextOrderNumber = 1;

        /// <summary>
        /// This is the current order number.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// This is the sales tax for the order.
        /// </summary>
        public decimal SalesTaxRate { get; set; } = 0.09m;

        /// <summary>
        /// This is the subtotal of the items in the order (before tax).
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal sub = 0;
                IMenuItem[] items = new IMenuItem[Count];
                CopyTo(items, 0);
                foreach (IMenuItem item in items)
                {
                    if (item != null) sub += item.Price;
                }
                return sub;
            }
        }

        /// <summary>
        /// This is the tax on all of the items in the order.
        /// </summary>
        public decimal Tax
        {
            get { return Subtotal * SalesTaxRate; }
        }

        /// <summary>
        /// This is the total cost on all of the items in the order (after tax).
        /// </summary>
        public decimal Total
        {
            get { return Subtotal + Tax; }
        }

        /// <summary>
        /// This is the callories of all the items in the order.
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 0;
                IMenuItem[] items = new IMenuItem[Count];
                CopyTo(items, 0);
                foreach (IMenuItem item in items)
                {
                    if (item != null) cals += item.Calories;
                }
                return cals;
            }
        }

        public Order()
        {
            Number = _nextOrderNumber;
            _nextOrderNumber++;
            CollectionChanged += CollectionChangedListener;
        }
        
        /// <summary>
        /// This handles the updates.
        /// </summary>
        public void Update()
        {
            
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            
            
            /*
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            */
        }

        /// <summary>
        /// This gives the order number.
        /// </summary>
        public string OrderNumber
        {
            get
            {
                return $"Order #{Number}";
            }
        }

        /// <summary>
        /// This is the event listener for collection changed.
        /// </summary>
        /// <param name="sender">this is the sender.</param>
        /// <param name="e">this is the argument.</param>
        public void CollectionChangedListener(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(IMenuItem item in e.NewItems)
                    {
                        item.PropertyChanged += ItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach(IMenuItem item in e.OldItems)
                    {
                        item.PropertyChanged += ItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Replace: /// This might need to be removed if it causes issues.
                    foreach(IMenuItem item in e.OldItems)
                    {
                        item.PropertyChanged += ItemChangedListener;
                    }
                    break;
            }
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Subtotal)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Tax)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Total)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Calories)));
        }

        /// <summary>
        /// This is the event listener for item changed.
        /// </summary>
        /// <param name="sender">this is the sender.</param>
        /// <param name="e">this is the argument.</param>
        public void ItemChangedListener(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Price")
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Subtotal)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Tax)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Total)));
            }
            if(e.PropertyName == "Calories")
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Calories)));
            }
        }
    }
}
