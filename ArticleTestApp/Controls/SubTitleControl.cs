using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using ArticleLib.Data;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ArticleTestApp.Controls
{
    public sealed class SubTitleControl : Control
    {      
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register("FirstName", typeof(string), typeof(SubTitleControl), new PropertyMetadata(null, null));

        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string), typeof(SubTitleControl), new PropertyMetadata(null, null));

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(string), typeof(SubTitleControl), new PropertyMetadata(null, null));
        
        public string FirstName
        {
            get => (string)GetValue(FirstNameProperty);
            set => SetValue(FirstNameProperty, value);
        }

        public string LastName
        {
            get => (string)GetValue(LastNameProperty);
            set => SetValue(LastNameProperty, value);
        }

        public string Date
        {
            get => (string)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        } 

        public SubTitleControl()
        {
            this.DefaultStyleKey = typeof(SubTitleControl);
        }
    }
}
