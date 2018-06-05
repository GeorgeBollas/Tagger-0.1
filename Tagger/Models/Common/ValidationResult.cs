using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models.Common
{
    public class ValidationResult
    {
        public ValidationStatus Status { get; set; }
    }

    public enum ValidationStatus
    {
        OK,
        Warnings,
        Errors
    }
}
