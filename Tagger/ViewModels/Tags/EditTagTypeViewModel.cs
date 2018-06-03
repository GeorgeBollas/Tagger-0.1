using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Tagger.Models;
using Tagger.Services;
using Windows.UI.Core;

namespace Tagger.ViewModels
{
    public class EditTagTypeViewModel : EditableItemViewModelBase<TagTypeModel>
    {

        public EditTagTypeViewModel()
        {
        }

        private ViewLifetimeControl _viewLifetimeControl;

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
