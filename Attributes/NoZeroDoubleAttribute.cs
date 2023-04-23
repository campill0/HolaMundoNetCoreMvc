using HolaMundoNetCoreMvc.Models;
using System.ComponentModel.DataAnnotations;
namespace HolaMundoNetCoreMvc.Attributes
{
    public class NoZeroDoubleAttribute : ValidationAttribute
    {
        public HolaMundoNetCoreMvc.Controllers.OperacionMathController.Operacion Operacion { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((OperacionMathViewModel)validationContext.ObjectInstance).Operacion != HolaMundoNetCoreMvc.Controllers.OperacionMathController.Operacion.DIVISION)
            {
                return ValidationResult.Success;
            }

            if (value != null && double.TryParse(value.ToString(), out double result))
            {
                if (result != 0.0)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "El valor del segundo operando no puede ser cero en una división.");
        }
    }

}
