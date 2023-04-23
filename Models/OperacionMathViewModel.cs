using HolaMundoNetCoreMvc.Attributes;
using HolaMundoNetCoreMvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HolaMundoNetCoreMvc.Models
{
    public class OperacionMathViewModel
    {
        public OperacionMathViewModel()
        {
            Operaciones = new List<SelectListItem>();
            Operando1 = "0";
            Operando2 = "0";
        }
        [RegularExpression(@"^\d+(,\d+)?$",ErrorMessage = "Número incorrecto, compruebe el formato.")]
        [Required (ErrorMessage ="El primer operando es obligatorio.")]
        public string Operando1 { get; set; }
        [NoZeroDoubleAttribute(ErrorMessage ="El segundo operando no puede ser cero en la división")]
        [RegularExpression(@"^\d+(,\d+)?$", ErrorMessage = "Número incorrecto, compruebe el formato.")]
        [Required(ErrorMessage ="El segundo operando es obligatorio")]
        public string Operando2 { get; set; }

        public List<SelectListItem> Operaciones { get; set; }
        public OperacionMathController.Operacion Operacion { get; set; }

        
        public double Resultado { get; set; }
    }
}
