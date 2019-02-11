using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ArticleLib.Data;
using ArticleTestApp.ViewModel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ArticleTestApp.UserControls
{
    public sealed partial class GalleryItemUserControl : UserControl
    {
        public GalleryItem ViewModel => DataContext as GalleryItem;

        public GalleryItemUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (sender, args) => Bindings.Update();
        }
    }
}
