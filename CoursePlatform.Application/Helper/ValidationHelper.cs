using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Helper
{
    public class ValidationHelper
    {

        public static void ModelValidation(object? model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            ValidationContext validationContext = new ValidationContext(model);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (!isValid)
            {
                string allErrors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                throw new ValidationException($"Model validation failed: {allErrors}");
            }
        }

    }
}
