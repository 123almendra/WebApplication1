using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProyecto.Controllers
{
    public class UserController : Controller
    {
        UserLogica uLogica = new UserLogica();
        public ActionResult Index()
        {
            return View(uLogica.getAllUser());
        }
    }
}