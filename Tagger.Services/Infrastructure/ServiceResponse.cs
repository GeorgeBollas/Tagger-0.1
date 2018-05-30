using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tagger.Services
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            Messages = new List<ResponseMessage>();
        }

        public MessageLevel HighestMessageLevel
        {
            get
            {
                return Messages.Max(m => m.ResultLevel);
            }
        }

        public List<ResponseMessage> Messages { get; set; }

        public T ReturnValue { get; set; }

    }

}
