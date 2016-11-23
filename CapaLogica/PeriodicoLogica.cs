using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;
using CapaModelo;

namespace CapaLogica
{
    public class PeriodicoLogica
    {
        PeriodicoDAO pDao = new PeriodicoDAO();

        public List<Periodico> ListPagination(int pageIndex, int pageSize, int pageCount)
        {

            return pDao.ListPagination(pageIndex,pageSize,pageCount);
        }

        public List<Periodico> getAllDocs(Periodico Item)
        {
            return pDao.getAllDocs(Item);
        }


    }
}
