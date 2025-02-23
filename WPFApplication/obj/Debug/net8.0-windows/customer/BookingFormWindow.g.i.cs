﻿#pragma checksum "..\..\..\..\customer\BookingFormWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "776CC5F0D7EB2469AE8030F37BFC9E4BEBBB29D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WPFApplication.customer {
    
    
    /// <summary>
    /// BookingFormWindow
    /// </summary>
    public partial class BookingFormWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker BookingDatePicker;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SlotComboBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ServiceTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberOfPoolsTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AdditionalNotesTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DepositAmountTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\customer\BookingFormWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PaymentMethodComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFApplication;component/customer/bookingformwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\customer\BookingFormWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BookingDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.SlotComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ServiceTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\..\customer\BookingFormWindow.xaml"
            this.ServiceTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ServiceTypeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumberOfPoolsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AdditionalNotesTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DepositAmountTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PaymentMethodComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 42 "..\..\..\..\customer\BookingFormWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConfirmBookingButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 44 "..\..\..\..\customer\BookingFormWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

