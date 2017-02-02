using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ErrorPagesController : Controller
    {
        // GET: Default
        public ActionResult error()
        {
            return View();
        }

		public ActionResult 404()
		{
			return View();
		}
	}
}