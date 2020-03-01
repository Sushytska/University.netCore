using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;

namespace BLL
{
    public class AttributeValidator: IValidator
    {
        private ValidationContext _validationContext;
        private List<ValidationResult> _validationResults;

        public bool IsValid<T>(T obj)
        {
            _validationContext = new ValidationContext(obj);
            _validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, _validationContext, _validationResults, true);
        }

        public void Validate<T>(T obj)
        {
            if (IsValid(obj) == false)
            {
                throw new ValidationException(_validationResults[0].ErrorMessage);
            }
        }
    }
}