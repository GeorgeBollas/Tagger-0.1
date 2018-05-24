using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Entities.Tags
{
    public class TagType:EntityBase
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
