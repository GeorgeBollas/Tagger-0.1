using System;

using Tagger.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Tagger.Views
{
    public sealed partial class SearchPage : Page
    {
        private SearchViewModel ViewModel
        {
            get { return DataContext as SearchViewModel; }
        }

        public SearchPage()
        {
            InitializeComponent();
        }
    }
}
