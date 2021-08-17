using System;
using System.Collections.Generic;
using System.Text;

namespace SEDOLValidators
{
    public class ValidationResult : ISedolValidationResult
    {
        public string InputString { get; set; }

        public bool IsValidSedol { get; set; }

        public bool IsUserDefined { get; set; }

        public string ValidationDetails { get; set; }
    }
}
