using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikriSozlukProject.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        [AllowAnonymous]
        public ActionResult HomePageHeadings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        [AllowAnonymous]
        public PartialViewResult HomePageIndex(int id = 0)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
        [AllowAnonymous]
        public ActionResult GetAllHomeContent(string p)
        {
            var values = cm.GetList(p);
            if (p == null)
            {
                return View(cm.GetList(""));
            }
            return View(values);
        }       

    }
}