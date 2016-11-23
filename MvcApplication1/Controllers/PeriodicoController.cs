using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class PeriodicoController : Controller
    {
        //
        // GET: /Periodico/

        PeriodicoLogica pLogica = new PeriodicoLogica();
        
        public ActionResult Index()
        {          
                return View(Crear());            
        }

        public ActionResult Grid(string dateInicio, string dateFin)
        {            
            var periodico = new CapaModelo.Periodico();
            periodico.dateInicio = dateInicio;
            periodico.dateFin = dateFin;
            pLogica.getAllDocs(periodico);
            return PartialView("Grid", Crear(periodico));
        }

        public ListPeriodico Crear (CapaModelo.Periodico Item = null)
        {       
            if (Item == null)
                Item = new CapaModelo.Periodico();
            
            var Elementos = pLogica.getAllDocs(Item);          
            return new ListPeriodico(Elementos, Item);
        }

       //public ActionResult Busqueda(string dateInicio, string dateFin)
       // {
       //     var periodico = new CapaModelo.Periodico();
       //     periodico.dateInicio = dateInicio;
       //     periodico.dateFin = dateFin;
       //     var Filtro = pLogica.getByDateInclude(periodico);

       //     return PartialView("Grid");
       // }

    }
}
