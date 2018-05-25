using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Entities
{
    public class TagType:EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //todo move to extension or something
        public string SearchTerms { get { return Name + Description; } }

        public ICollection<Tag> Tags { get; set; }
    }
}
