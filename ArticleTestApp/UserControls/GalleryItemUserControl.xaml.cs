using Windows.UI.Xaml.Controls;
using ArticleLib.Data;

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
