using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikriSozlukProject.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public int id;
        public ActionResult IstatistikIndex()
        {
            var TotalCategories = c.Categories.Count(); //Toplam Kategori sayısı
            var TotalSofwareHeading = c.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count();  //Toplam "Yazılım" Kategorisine ait başlık sayısı
            var TotalWriterWithLetterA = c.Writers.Where(x => x.WriterName.Contains("a")).Count();  //İsminde "a" harfi bulunan yazarlar

            var countCategoryList = c.Headings.GroupBy(x => x.CategoryID).Select(y => new { y.Key, Count = y.Count() }).ToList();


            int max = 0;

            foreach (var items in countCategoryList)
            {
                if (items.Count > max)
                {
                    max = items.Count;
                    id = items.Key;
                }
            }
            var CategoryOfTheMostHeading = c.Categories.Where(x => x.CategoryID == id).Select(y => y.CategoryName).FirstOrDefault();

            var TotalCategoryTrue = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var TotalCategoryFalse = c.Categories.Where(x => x.CategoryStatus == false).Count();
            var TrueFalseDifferences = TotalCategoryTrue - TotalCategoryFalse;

            ViewBag.TotalCategories = TotalCategories;
            ViewBag.TotalSofwareHeading = TotalSofwareHeading;
            ViewBag.TotalWriterWithLetterA = TotalWriterWithLetterA;
            ViewBag.CategoryOfTheMostHeading = CategoryOfTheMostHeading;
            ViewBag.TrueFalseDifferences = TrueFalseDifferences;

            //var catId = c.Headings.GroupBy(x => x.CategoryID).Where(g => g.Count() > 1).OrderByDescending(g => g.Count()).Select(g => g.Key).Take(1).FirstOrDefault();
            //var mostused = c.Categories.Where(x => x.CategoryID == catId).Select(x => x.CategoryName).FirstOrDefault();
            //ViewBag.mostused = mostused;

            return View("IstatistikIndex");
        }
    }
}