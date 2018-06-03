using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models
{
    public class TagTypeModel:ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { Set(ref description, value); }
        }

        private double minCount;

        public double MinCount
        {
            get { return minCount; }
            set { Set(ref minCount, value); }
        }

        private double maxCount;

        public double MaxCount
        {
            get { return maxCount; }
            set { Set(ref maxCount, value); }
        }

    }
}
