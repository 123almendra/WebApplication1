using Microsoft.SqlServer.Server;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
//using System.IFormatProvider
namespace CapaModelo
{
    public class Periodico
    {

        public int Fk_Cat {get;set;}
        public int Pk_Doc {get;set;}
        public string Categoria  {get;set;}
        public DateTime dateInclude {get;set;}

        [UIHint("dateInicio")]
        public string dateInicio { get; set; }

        [UIHint("dateFin")]
        public string dateFin { get; set; }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }

    }
}

