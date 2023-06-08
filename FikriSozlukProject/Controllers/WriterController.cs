using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikriSozlukProject.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();

        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)     //EĞER SONUÇLAR GEÇERLİYSE
            {
                if (Request.Files.Count>0)
                {
                    string imagefilename = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);    //uzantı 
                    string yol = "~/Image/" + imagefilename + extension;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/Image/" + imagefilename + extension;                   

                }
                wm.WriterAdd(p);                    //PARAMETREDEN GELEN DEĞERİ EKLE
                
                return RedirectToAction("WriterLogin","Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);     //AKSİ DURUMDA ERROR MESAJI VER
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)     //EĞER SONUÇLAR GEÇERLİYSE
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);     //AKSİ DURUMDA ERROR MESAJI VER
                }
            }
            return View();

        }
        
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/AdminLTE-3.2.0/image/"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("AddWriter");
        }
    }
}