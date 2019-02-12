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
using Windows.UI.Xaml.Media.Imaging;
using ArticleLib.Data;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ArticleTestApp.Controls
{
    public sealed class GalleryItemControl : Control
    {
        private ImageBrush MainImage { get; set; }

        public string NameOfImage
        {
            get => (string)GetValue(NameOfImageProperty);
            set => SetValue(NameOfImageProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public Uri UriSource
        {
            get => (Uri)GetValue(UriSourceProperty);
            set => SetValue(UriSourceProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MainImage = GetTemplateChild("MainImage") as ImageBrush;
        }

        public static readonly DependencyProperty NameOfImageProperty =
            DependencyProperty.Register("NameOfImage", typeof(string), typeof(GalleryItemControl), new PropertyMetadata(null, null));

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(GalleryItemControl), new PropertyMetadata(null, null));

        public static readonly DependencyProperty UriSourceProperty =
            DependencyProperty.Register("UriSource", typeof(Uri), typeof(GalleryItemControl), new PropertyMetadata(null, OnImageChange));

        private static void OnImageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var img = (d as GalleryItemControl)?.MainImage;
            if (img != null)
            {
                var uri = e.NewValue as Uri;
                img.ImageSource = uri == null ? null : new BitmapImage(uri);
            }
        }

        public GalleryItemControl()
        {
            DefaultStyleKey = typeof(GalleryItemControl);
        }
    }
}
