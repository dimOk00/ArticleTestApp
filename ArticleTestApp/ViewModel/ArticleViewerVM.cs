using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;
using ArticleLib;
using ArticleLib.Data;
using ArticleTestApp.Helpers;
using Microsoft.Toolkit.Uwp.UI;

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

            ImageCache.Instance.CacheDuration = TimeSpan.FromHours(24);
            ImageCache.Instance.MaxMemoryCacheCount = 100;

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
                    async () =>
                    {
                        await CacheArticleImagesAsync(article);
                        ArticleCollection.Add(article);
                    });
            }
        }

        private static async Task CacheArticleImagesAsync(Article article)
        {
            try
            {
                var filteredGalleryItems = new List<GalleryItem>(); 

                foreach (var galleryItem in article.Gallery)
                {
                    if (galleryItem == null)
                    {
                        break;
                    }

                    await ImageCache.Instance.PreCacheAsync(galleryItem.ImageURI);
                    var file = await ImageCache.Instance.GetFileFromCacheAsync(galleryItem.ImageURI);
                    if (file != null)
                    {
                        var uri = new Uri(file.Path);
                        galleryItem.ImageURI = uri;
                        filteredGalleryItems.Add(galleryItem);
                    }
                }

                article.Gallery = filteredGalleryItems;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void Dispose()
        {
            _generator.StopGenerating();
            _generator.ArticleGenerated -= Generator_ArticleGenerated;
        }
    }
}
