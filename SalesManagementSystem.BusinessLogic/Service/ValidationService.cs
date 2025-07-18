using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.BusinessLogic
{
    public static class ValidationService
    {
        public static IList<ValidationResult> Validate<T>(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, serviceProvider: null, items: null);
            Validator.TryValidateObject(entity, context, results, validateAllProperties: true);
            return results;
        }
    }
}
