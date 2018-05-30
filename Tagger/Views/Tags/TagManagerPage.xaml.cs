using System;

using Tagger.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tagger.Views
{
    public sealed partial class TagManagerPage : Page
    {
        private TagManagerViewModel ViewModel
        {
            get { return DataContext as TagManagerViewModel; }
        }

        public TagManagerPage()
        {
            InitializeComponent();
            Loaded += TagManagerPage_Loaded;
        }

        private async void TagManagerPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
