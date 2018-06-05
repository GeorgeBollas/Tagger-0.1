using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tagger.Models.Common;
using Tagger.ViewModels.Common;

namespace Tagger.ViewModels
{
    public abstract class EditableItemViewModelBase<TModel>: ViewModelBase
        where TModel: EditableItemModel, new()
    {

        private TModel model;

        public TModel Item
        {
            get { return model; }
            set { Set(ref model, value); }
        }

        private bool isEditable;

        public bool IsEditable
        {
            get { return isEditable; }
            set { Set(ref isEditable, value); }
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

        private bool isDirty;

        public bool IsDirty
        {
            get { return isDirty; }
            set { Set(ref isDirty, value); }
        }


        public ICommand EditCommand => new RelayCommand(
            () =>
            {
                if (isEditMode)
                    return;

                BeginEdit();
            });

        private void BeginEdit()
        {
            isEditMode = true;
            var editableItem = new TModel();
            editableItem.Merge(Item);
            EditableItem = editableItem;

            MessengerInstance.Send(new EditModeMessage(Item, EditAction.Begin));
        }

        public ICommand SaveCommand => new RelayCommand(
            () =>
                {
                    var result = Validate();

                    if (result.Status == ValidationStatus.OK)
                    {
                        if (IsDirty)
                        {
                            Item.Merge(EditableItem);
                            IsDirty = false;
                            isEditMode = false;
                        }

                        MessengerInstance.Send(new EditModeMessage(Item, EditAction.Save));
                    }
                },
            () => IsDirty) ;

        public virtual ValidationResult Validate () => new ValidationResult() { Status = ValidationStatus.OK };

        public ICommand CancelCommand => new RelayCommand(
            () =>
            {
                if (IsDirty)
                {
                    var editableItem = new TModel();
                    EditableItem.Merge(Item);
                    IsDirty = false;
                    isEditMode = false;
                }

                MessengerInstance.Send(new EditModeMessage(Item, EditAction.Cancel));

            });

    }

    public enum EditAction
    {
        Begin,
        Cancel,
        Save
    }
}
