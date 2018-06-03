using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Models.Common;

namespace Tagger.ViewModels.Common
{
    public class EditModeMessage
    {
        public EditModeMessage(EditableItemModel item, EditAction action)
        {
            Item = item;
            Action = action;
        }

        public EditAction Action { get; private set; }
        public EditableItemModel Item { get; private set; }
    }
}
