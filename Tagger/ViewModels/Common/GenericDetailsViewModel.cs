using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tagger.Models;
using Tagger.ViewModels.Common;

namespace Tagger.ViewModels
{
    public abstract class GenericDetailsViewModel<TModel> : TaggerViewModelBase
        where TModel : ObservableModel, new()
    {
        public GenericDetailsViewModel(IDialogService dialogService) : base(dialogService)
        {

        }

        //todo move to TaggerViewModelBase??
        public bool IsMainView => false; // ContextService.IsMainView;

        public bool IsDataAvailable => item != null;
        public bool IsDataUnavailable => !IsDataAvailable;

        //public bool CanGoBack => !IsMainView && NavigationService.CanGoBack;

        // in ViewModelBase originally
        virtual public string Title => String.Empty;
        
        private TModel item = null;
        public TModel Item
        {
            get { return item; }
            set
            {
                if (Set(ref item, value))
                {
                    EditableItem = item;
                    IsEnabled = (!item?.IsEmpty) ?? false;
                    RaisePropertyChanged(nameof(IsDataAvailable));
                    RaisePropertyChanged(nameof(IsDataUnavailable));
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        private TModel editableItem;
        public TModel EditableItem
        {
            get { return editableItem; }
            set { Set(ref editableItem, value); }
        }

        private bool isEditMode;
        public bool IsEditMode
        {
            get { return isEditMode; }
            set { Set(ref isEditMode, value); }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        public ICommand BackCommand => new RelayCommand(OnBack);
        virtual protected void OnBack()
        {
            //StatusReady();
            //if (NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
        }

        public ICommand EditCommand => new RelayCommand(
            () =>
            {
                BeginEdit();
            });

        private void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;
                // Create a copy for edit
                var editableItem = new TModel();
                editableItem.Merge(Item);
                EditableItem = editableItem;

                MessengerInstance.Send(new EditModeMessage(Item, EditAction.Begin));
            }
        }

        public ICommand CancelCommand => new RelayCommand(
            () =>
            {
                CancelEdit();
                MessengerInstance.Send(new EditModeMessage(Item, EditAction.Cancel));
            });

        virtual public void CancelEdit()
        {
            if (ItemIsNew)
            {
                // We were creating a new item: cancel means exit
                //if (NavigationService.CanGoBack)
                //{
                //    NavigationService.GoBack();
                //}
                //else
                //{
                //    NavigationService.CloseViewAsync();
                //}
                return;
            }

            // We were editing an existing item: just cancel edition
            if (IsEditMode)
            {
                EditableItem = Item;
            }
            IsEditMode = false;
        }

        public ICommand SaveCommand => new RelayCommand(
            async () =>
                {
                    //todo fix validation
                    //var result = Validate(EditableItem);
                    //if (result.Status == ValidationStatus.OK)
                    //{
                        await SaveAsync();
                    //}
                    //else
                    //{
                    //    //todo build error string or integrate into UWP built in features
                    //    //await DialogService.ShowMessageBox(result.Message, $"{result.Description} Please, correct the error and try again.");
                    //}
                });
        virtual public async Task SaveAsync()
        {
            IsEnabled = false;
            bool isNew = ItemIsNew;
            if (await SaveItemAsync(EditableItem))
            {
                Item.Merge(EditableItem);
                Item.RaisePropertiesChanged();
                RaisePropertyChanged(nameof(Title));
                EditableItem = Item;

                if (isNew)
                {
                    MessengerInstance.Send(new NotificationMessage<TModel>(Item, "NewItemSaved"));
                }
                else
                {
                    MessengerInstance.Send(new NotificationMessage<TModel>(Item, "ItemChanged"));
                }
                IsEditMode = false;

                RaisePropertyChanged(nameof(ItemIsNew));
            }
            IsEnabled = true;
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        virtual protected async void OnDelete()
        {
            if (await ConfirmDeleteAsync())
            {
                await DeleteAsync();
            }
        }
        virtual public async Task DeleteAsync()
        {
            var model = Item;
            if (model != null)
            {
                IsEnabled = false;
                if (await DeleteItemAsync(model))
                {
                    MessengerInstance.Send(new NotificationMessage<TModel>(model, "ItemDeleted"));
                }
                else
                {
                    IsEnabled = true;
                }
            }
        }


        //public virtual ValidationResult Validate(TModel model) => new ValidationResult() { Status = ValidationStatus.OK };

        abstract public bool ItemIsNew { get; }

        abstract protected Task<bool> SaveItemAsync(TModel model);
        abstract protected Task<bool> DeleteItemAsync(TModel model);
        abstract protected Task<bool> ConfirmDeleteAsync();

    }

    public enum EditAction
    {
        Begin,
        Cancel,
        Save
    }
}
