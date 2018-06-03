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
        where TModel: EditableItemModel
    {

        public TModel Item { get; set; }

        public TModel EditableItem { get; set; }

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

                isEditMode = true;
                MessengerInstance.Send(new EditModeMessage(Item, EditAction.Begin));
                //todo what else 
            });

        public ICommand SaveCommand => new RelayCommand(
            () =>
                {
                },
            () => IsDirty) ;

        public ICommand CancelCommand => new RelayCommand(
            () =>
            {
                if (IsDirty)
                    EditableItem.Merge(Item);

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
