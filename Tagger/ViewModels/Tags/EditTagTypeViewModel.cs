using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tagger.Models;
using Tagger.Services;
using Windows.UI.Core;

namespace Tagger.ViewModels
{
    public class EditTagTypeViewModel 
    {

        public EditTagTypeViewModel(IDialogService dialogService, ITagsService tagsService)
        {
            TagTypeDetailsViewModel = new TagTypeDetailsViewModel(dialogService, tagsService);
        }

        private ViewLifetimeControl _viewLifetimeControl;

        public TagTypeDetailsViewModel TagTypeDetailsViewModel { get; set; }

        public void Initialize(ViewLifetimeControl viewLifetimeControl)
        {
            _viewLifetimeControl = viewLifetimeControl;
            _viewLifetimeControl.Released += OnViewLifetimeControlReleased;
        }

        private async void OnViewLifetimeControlReleased(object sender, EventArgs e)
        {
            _viewLifetimeControl.Released -= OnViewLifetimeControlReleased;
            await WindowManagerService.Current.MainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                WindowManagerService.Current.SecondaryViews.Remove(_viewLifetimeControl);
            });
        }
    }
}
