using System;
using Tagger.Services;
using Tagger.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Tagger.Views
{
    public sealed partial class EditTagTypePage : Page
    {
        private EditTagTypeViewModel ViewModel
        {
            get { return DataContext as EditTagTypeViewModel; }
        }

        public EditTagTypePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as ViewLifetimeControl);
        }

    }
}
