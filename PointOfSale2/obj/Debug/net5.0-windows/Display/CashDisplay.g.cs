﻿#pragma checksum "..\..\..\..\Display\CashDisplay.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1FFFF54731E3BCEC82E5B22A931D466207E3D44D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FriedPiper.PointOfSale;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FriedPiper.PointOfSale {
    
    
    /// <summary>
    /// CashDisplay
    /// </summary>
    public partial class CashDisplay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border colorShit;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock amountName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button incrementCount;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customerCount;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button decrementCount;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Display\CashDisplay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cashierCount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FriedPiper.PointOfSale;component/display/cashdisplay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Display\CashDisplay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.colorShit = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.amountName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.incrementCount = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Display\CashDisplay.xaml"
            this.incrementCount.Click += new System.Windows.RoutedEventHandler(this.IncrementHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.customerCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.decrementCount = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Display\CashDisplay.xaml"
            this.decrementCount.Click += new System.Windows.RoutedEventHandler(this.DecrementHandler);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cashierCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

