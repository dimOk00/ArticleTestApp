using Windows.UI.Xaml.Controls;

namespace ArticleTestApp.Helpers
{
    public class BasePage : Page
    {
        private const string ViewModelPropertyName = "ViewModel";

        protected BasePage()
        {
            DataContextChanged += (s, e) =>
            {
                SyncVmWithDataContext();
            };
        }

        private void SyncVmWithDataContext()
        {
            var vmProperty = GetType().GetProperty(ViewModelPropertyName);
            if (vmProperty != null)
            {
                vmProperty.SetMethod.Invoke(this, new[] { DataContext });
            }
        }
    }
}