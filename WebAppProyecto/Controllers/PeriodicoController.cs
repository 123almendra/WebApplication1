using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProyecto.Models.Periodico;

namespace WebAppProyecto.Controllers
{
    public class PeriodicoController : Controller
    {
        PeriodicoLogica pLogica = new PeriodicoLogica();

        public ActionResult Index()
        {

            return View(Crear());
        }

        public ActionResult Index2(int id = 1)
        {                       
            return View(Buscar(id));
        }

        public ActionResult Grid(string dateInicio, string dateFin)
        {
            var periodico = new CapaModelo.Periodico();
            periodico.dateInicio = dateInicio;
            periodico.dateFin = dateFin;
            pLogica.getAllDocs(periodico);
            return PartialView("Grid", Crear(periodico));
            //return PartialView(Buscar(id));
        }

        public ActionResult Grid2(int id = 1)
        {
            return PartialView("Grid", Buscar(id));
        }


        public ListPeriodico Crear(CapaModelo.Periodico Item = null)
        {
            if (Item == null)
                Item = new CapaModelo.Periodico();

            var Elementos = pLogica.getAllDocs(Item);
            return new ListPeriodico(Elementos, Item);
        }

        public ListPeriodico Crear2(int id = 1)
        {
            CapaModelo.Periodico Item = new CapaModelo.Periodico();
            int pageCount = 0;
            
            List<CapaModelo.Periodico> Elementos = pLogica.ListPagination(id, 30, pageCount);
            ViewBag.PageCount = pageCount;
            
            return new ListPeriodico(Elementos, Item);
        }

        public ActionResult ListDocs (int id = 1)
        {

            return PartialView(Buscar(id));
        }

        public ListPeriodico Buscar(int pageIndex)
        {
            CapaModelo.Periodico Item = new CapaModelo.Periodico();
            int pageCount = 0;

            List<CapaModelo.Periodico> docs = pLogica.ListPagination(pageIndex, 10, pageCount);
            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;

            return new ListPeriodico(docs, Item); 
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