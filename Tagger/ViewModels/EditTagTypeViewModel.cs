using System;

using GalaSoft.MvvmLight;
using Tagger.Services;
using Windows.UI.Core;

namespace Tagger.ViewModels
{
    public class EditTagTypeViewModel : ViewModelBase
    {

        public EditTagTypeViewModel()
        {
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { Set(ref description, value); }
        }

        private int minCount;

        public int MinCount
        {
            get { return minCount; }
            set { Set(ref minCount, value); }
        }

        private int maxCount;

        public int MaxCount
        {
            get { return maxCount; }
            set { Set(ref maxCount, value); }
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
