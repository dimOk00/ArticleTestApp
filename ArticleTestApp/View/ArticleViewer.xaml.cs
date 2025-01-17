﻿using ArticleTestApp.Helpers;
using ArticleTestApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArticleTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : BasePage
    { 
        public MainPage()
        {
            this.InitializeComponent();        
        }

        public ArticleViewerVM ViewModel { get; set; }
    }
}
