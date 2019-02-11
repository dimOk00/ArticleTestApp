using Windows.UI.Xaml.Controls;
using ArticleTestApp.ViewModel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ArticleTestApp.UserControls
{
    public sealed partial class ArticleUserControl : UserControl
    {
        public ArticleViewerVM ViewModel => DataContext as ArticleViewerVM;
        public ArticleLib.Data.Article Article => ViewModel.SelectedArticle;

        public ArticleUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (sender, args) => Bindings.Update();
        }
    }
}
