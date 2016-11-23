using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MvcApplication1.Models
{
    public class Periodico
    {
        public int Fk_Cat { get; set; }
        public int Pk_Doc { get; set; }
        public string Categoria { get; set; }
        public string dateInclude { get; set; }
        public string dateInicio { get; set; } 
        public string dateFin { get; set; }
    }
}