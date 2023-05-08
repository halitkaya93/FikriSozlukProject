using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikriSozlukProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
       
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
            
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
            
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var sendvalues = mm.GetByID(id);
            return View(sendvalues);
        }
        public PartialViewResult MessageListMenu() 
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string menuName)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messagevalidator.Validate(p);

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menuName == "send")
            {
                if (result.IsValid)     //EĞER SONUÇLAR GEÇERLİYSE
                {
                    p.SenderMail = sender;
                    p.IsDraft = false;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);                    //PARAMETREDEN GELEN DEĞERİ EKLE
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);     //AKSİ DURUMDA ERROR MESAJI VER
                    }
                }
            }
            //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
            else if (menuName == "addDraft")
            {
                if (result.IsValid)
                {
                    p.SenderMail = sender;
                    p.IsDraft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı İptal tuşuna basarsa;
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }
    }
}