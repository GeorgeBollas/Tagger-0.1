using System;
using System.Collections.Generic;
using System.Text;

namespace Tagger.Models
{
    public abstract class AggregateModelBase //todo Observable
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public ModelState State { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public void Initialise()
        {
            var now = DateTime.Now;

            CreatedDateTime = now;
            ModifiedDateTime = now;
            State = ModelState.New;
        }

    }
}
