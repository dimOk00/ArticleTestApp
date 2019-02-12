using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using ArticleLib;
using ArticleLib.Data;
using ArticleTestApp.Helpers;

namespace ArticleTestApp.ViewModel
{
    public class ArticleViewerVM : ViewModelBase, IDisposable
    {
        private readonly ArticleGenerator _generator;
        private Article _selectedArticle;

        public ArticleViewerVM()
        {
            ArticleCollection = new ObservableCollection<Article>();
            CloseArticleCommand = new RelayCommand(() => SelectedArticle = null);

            _generator = new ArticleGenerator();
            _generator.ArticleGenerated += Generator_ArticleGenerated;
            _generator.StartGenerating();
        }

        public ObservableCollection<Article> ArticleCollection { get; }

        public Article SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                if (_selectedArticle != value)
                {
                    _selectedArticle = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                }
            }
        }

        public RelayCommand CloseArticleCommand { get; }

        private async void Generator_ArticleGenerated(Article article)
        {
            if (article != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =>
                    {
                        ArticleCollection.Add(article);
                    });
            }
        }

        public void Dispose()
        {
            _generator.StopGenerating();
            _generator.ArticleGenerated -= Generator_ArticleGenerated;
        }
    }
}
