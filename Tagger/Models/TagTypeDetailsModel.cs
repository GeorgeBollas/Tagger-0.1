using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models
{
    public class TagTypeDetailsModel : ObservableModel

    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        [Required]
        [MinLength(4)]
        public string Name
        {
            get { return name; }
            set
            {
                //todo move this to base Set statement
                // may already to comparer
                if (!EqualityComparer<string>.Default.Equals(name, value))
                    Validate(value, nameof(Name));

                Set(ref name, value);
            }
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

        public bool IsNew => Id <= 0;

        public override void Merge(object item)
        {
            if (!(item is TagTypeDetailsModel))
                throw new InvalidOperationException();

            Merge(item as TagTypeDetailsModel);
        }

        public void Merge(TagTypeDetailsModel item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            MinCount = item.MinCount;
            MaxCount = item.MaxCount;
        }

        public override void RaisePropertiesChanged()
        {
            //todo do we need this as each item will raise chang
        }
    }

}
