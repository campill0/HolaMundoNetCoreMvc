using HolaMundoNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HolaMundoNetCoreMvc.Controllers
{
    public class OperacionMathController : Controller
    {
        private readonly ILogger<OperacionMathController> _logger;

        public OperacionMathController(ILogger<OperacionMathController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(OperacionMathViewModel modelo)
        {
            if (modelo == null)
            {
                modelo = new OperacionMathViewModel();
               
            }
            modelo = new OperacionMathViewModel();
            RellenarModelo(modelo);
            return View("~/Views/OperacionMath/Index.cshtml", modelo);
        }
        public  enum Operacion
        {
            SUMA,RESTA,MULTIPLICACION,DIVISION,EXPONENCIACION,MODULO
        }
        public void RellenarModelo(OperacionMathViewModel modelo)
        {
            modelo.Operaciones = new List<SelectListItem>
            {
                new SelectListItem{Value=Operacion.SUMA.ToString(),Text="A+B"},
                new SelectListItem{Value=Operacion.RESTA.ToString(),Text="A-B"},
                new SelectListItem{Value=Operacion.MULTIPLICACION.ToString(),Text="A*B"},
                new SelectListItem{Value=Operacion.DIVISION.ToString(),Text="A/B"},
                new SelectListItem{Value=Operacion.EXPONENCIACION.ToString(),Text="A^B"},
                 new SelectListItem{Value=Operacion.MODULO.ToString(),Text="A%B"}

            };
        }
        public IActionResult RealizarOperacion(OperacionMathViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
               
                return Index(modelo);
            }
            switch (modelo.Operacion)
            {
                case Operacion.SUMA: modelo.Resultado = Double.Parse(modelo.Operando1) + Double.Parse(modelo.Operando2); break;
                case Operacion.RESTA: modelo.Resultado = Double.Parse(modelo.Operando1) - Double.Parse(modelo.Operando2); break;
                case Operacion.MULTIPLICACION: modelo.Resultado = Double.Parse(modelo.Operando1) * Double.Parse(modelo.Operando2); break;
                case Operacion.DIVISION:modelo.Resultado = Double.Parse(modelo.Operando1) / Double.Parse(modelo.Operando2); break;
                case Operacion.EXPONENCIACION: modelo.Resultado = Math.Pow(Double.Parse(modelo.Operando1), Double.Parse(modelo.Operando2)); break;
                case Operacion.MODULO: modelo.Resultado= Double.Parse(modelo.Operando1) % Double.Parse(modelo.Operando2); break;
            }
            return View("~/Views/OperacionMath/Result.cshtml", modelo);
        }


     
    }
}