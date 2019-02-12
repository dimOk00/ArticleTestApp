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
using ArticleTestApp.ViewModel;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ArticleTestApp.Controls
{
    public sealed class ArticleUserControl : Control
    {
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ArticleViewerVM), typeof(SubTitleControl), new PropertyMetadata(null, null));

        public ArticleViewerVM ViewModel
        {
            get => (ArticleViewerVM)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        } 

        public ArticleUserControl()
        {
            this.DefaultStyleKey = typeof(ArticleUserControl);
        }
    }
}
