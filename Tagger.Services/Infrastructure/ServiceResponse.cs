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
                if (Messages.Count == 0)
                    return MessageLevel.Success;

                return Messages.Max(m => m.ResultLevel);
            }
        }

        public List<ResponseMessage> Messages { get; set; }

        public T ReturnValue { get; set; }

    }

}
