using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Entities
{
    public class TagType:EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int MinCount { get; set; } = 0;

        [Required]
        public int MaxCount { get; set; } = 99999999; //todo make a constant

        //todo move to extension or something
        [NotMapped]
        public string SearchTerms { get { return Name + Description; } }

        public ICollection<Tag> Tags { get; set; }
    }
}
