using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Models;

namespace Tagger.ViewModels.Common
{
    public class EditModeMessage
    {
        public EditModeMessage(ObservableModel item, EditAction action)
        {
            Item = item;
            Action = action;
        }

        public EditAction Action { get; private set; }
        public ObservableModel Item { get; private set; }
    }
}
