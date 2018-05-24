using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public EntityState EntityState { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public void SetDatesNew()
        {
            var now = DateTime.Now;

            Created = now;
            Modified = now;
        }

        public void SetDatesModified()
        {
            Modified = DateTime.Now;
        }
    }
}
