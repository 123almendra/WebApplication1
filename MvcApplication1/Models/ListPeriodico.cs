using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaModelo;

namespace MvcApplication1.Models
{
    public class ListPeriodico
    {
        public IEnumerable<CapaModelo.Periodico> Elementos { get; set; }
        public CapaModelo.Periodico Filtro { get; set; }

        public ListPeriodico (IEnumerable<CapaModelo.Periodico> elementos, CapaModelo.Periodico filtro)
        {
            Elementos = elementos;
            Filtro = filtro;
        }

    }
}