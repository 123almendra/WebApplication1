using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using CapaModelo;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        UserLogica uLogica = new UserLogica();

        public ActionResult Index()
        {
            return View(uLogica.getAllUser());
        }

    }
}
