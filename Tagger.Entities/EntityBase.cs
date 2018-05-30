using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Entities
{
    public class EntityBase
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        public EntityState EntityState { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public void Initialize(int id)
        {
            Id = id;


            Guid = Guid.NewGuid();

            var now = DateTime.Now;

            Created = now;
            Modified = now;
        }

        public void MarkModified()
        {
            Modified = DateTime.Now;
        }
    }
}
