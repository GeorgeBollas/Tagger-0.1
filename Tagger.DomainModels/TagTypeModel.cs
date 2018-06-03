using System;
using System.Collections.Generic;
using System.Text;
using Tagger.Entities;
using Tagger.Models;

namespace Tagger.Models
{
    public class TagTypeModel : AggregateModelBase
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int MinCount { get; set; }

        public int MaxCount { get; set; }

        public static TagTypeModel CreateTagType(string name, string description, int minCount, int maxCount)
        {

            var tt = new TagTypeModel()
            {
                Name = name,
                Description = description,
                MinCount = minCount,
                MaxCount = maxCount
            };

            tt.Initialise();

            return tt;
        }

        public object GetEntity()
        {
            var entity = new TagType()
            {
                Id = Id,
                Name = Name,
                Description = 
            }
        }
    }
}
