using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.ViewModels.Common
{
    public class TaggerViewModelBase: ViewModelBase
    {
        public TaggerViewModelBase(IDialogService dialogService)
        {
            DialogService = dialogService;    
        }

        public IDialogService DialogService { get; }

    }
}
