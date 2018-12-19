using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            Parallel.ForEach(list, (l) => { });
            return View();
        }
    }
}
