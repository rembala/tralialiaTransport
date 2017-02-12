using System.Collections.Generic;

namespace Transport.Core.Validation
{
    public class ValidationResult
    {
        public bool Result { get; set; }
        public List<ValidationErrorRow> ErrorList { get; set; }

        public ValidationResult(List<ValidationErrorRow> errorList)
        {
            ErrorList = errorList;
            Result = (errorList ?? new List<ValidationErrorRow>()).Count == 0;
        }
    }
}
