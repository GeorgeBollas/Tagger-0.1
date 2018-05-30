using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Tagger.Entities;
using Tagger.Services;
using Tagger.Views;

namespace Tagger.ViewModels
{
    public class TagManagerViewModel : ViewModelBase
    {

        private ICommand createTagTypeCommand;

        private TagType _selected;

        public TagType Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<TagType> TagTypes { get; private set; } = new ObservableCollection<TagType>();

        public TagManagerViewModel()
        {
        }

        public ICommand CreateTagTypeCommand => createTagTypeCommand ?? (createTagTypeCommand = new RelayCommand(OnCreateTagTypeInvoked));

        private async void OnCreateTagTypeInvoked()
        {
            await WindowManagerService.Current.TryShowAsStandaloneAsync("Add new tag type", typeof(EditTagTypePage));
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            //TagTypes.Clear();

            //var data = await SampleDataService.GetSampleModelDataAsync();

            //foreach (var item in data)
            //{
            //    TagTypes.Add(item);
            //}

            //if (viewState == MasterDetailsViewState.Both)
            //{
            //    Selected = TagTypes.First();
            //}
        }
    }
}
