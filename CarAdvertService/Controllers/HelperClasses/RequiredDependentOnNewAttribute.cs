using System.ComponentModel.DataAnnotations;

namespace CarAdvertService.Controllers.HelperClasses
{
    public class RequiredDependentOnNewAttribute : ValidationAttribute
    {
        /// <summary>
        /// Provides validation for properties of <see cref="CarAdvertViewModel"/>, 
        /// which are dependent on the <see cref="CarAdvertViewModel.New"/> property.
        /// </summary>
        /// <param name="value">Property value of dependent property.</param>
        /// <param name="validationContext">Validation object</param>
        /// <returns>Validation result of type <see cref="ValidationResult"/></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var advert = (CarAdvertViewModel)validationContext.ObjectInstance;
            if (advert.New == true)
            {
                return ValidationResult.Success;
            }
            var property = value?.ToString() ?? null;
            return string.IsNullOrEmpty(property) ? new ValidationResult("Value is required.") : ValidationResult.Success;
        }
    }
}