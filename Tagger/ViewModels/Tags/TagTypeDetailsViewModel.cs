using System;
using System.Collections.Generic;
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
    public class TagTypeDetailsViewModel : GenericDetailsViewModel<TagTypeDetailsModel>
    {
        private readonly ITagsService tagsService;

        public TagTypeDetailsViewModel(
            IDialogService dialogService,
            ITagsService tagsService) : base(dialogService)
        {
            this.tagsService = tagsService;

            this.Item = new TagTypeDetailsModel() { Id = 1, Name = "A" };
            this.EditableItem = new TagTypeDetailsModel() { Name = "b" };

            Errors = new List<InputValidationError>()
            {
                new InputValidationError() { ErrorMessage="error" },
                new InputValidationError() { ErrorMessage="error2" }
            };

            IsEditMode = true;
        }

        public List<InputValidationError> Errors { get; set; }

        private ViewLifetimeControl _viewLifetimeControl;

        public override bool ItemIsNew => Item?.IsNew ?? true;

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

        protected override async Task<bool> SaveItemAsync(TagTypeDetailsModel model)
        {
            try
            {
                if (model.IsNew)
                    await tagsService.CreateTagTypeAsync(model.Name, model.Description, model.MinCount, model.MaxCount);
                else
                    await tagsService.UpdateTagTypeAsync(model.Id, model.Name, model.Description, model.MinCount, model.MaxCount);
                //todo fix this, handle errors, validation etc
            }
            catch (Exception ex)
            {
                //todo show error to user
                return false;
            }

            return true;
        }

        protected override Task<bool> DeleteItemAsync(TagTypeDetailsModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
