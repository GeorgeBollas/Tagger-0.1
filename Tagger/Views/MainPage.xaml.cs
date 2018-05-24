using System;

using Tagger.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Tagger.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
