using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();


        [Authorize] //Yani Inbox sayfasını sadece giriş yapanlar görebilecek
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
            //string session = (string)Session["AdminMail"];
            //var messageListInbox = mm.GetListInbox(session).ToPagedList(page ?? 1, 8); //? işaretleri boş gelme/boş olma durumuna karşı önlem amaçlı,kacinci sayfadan baslasin, sayfada kac deger olsun anlamina gelmektedir..
            //return View(messageListInbox);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
            //string session = (string)Session["AdminMail"];
            //var messageListSendbox = mm.GetListSendbox(session);
            //return View(messageListSendbox);
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


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string menuName)
        {
            ValidationResult result = messagevalidator.Validate(p);

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menuName == "send")
            {
                if (result.IsValid)     //EĞER SONUÇLAR GEÇERLİYSE
                {
                    p.SenderMail = "admin@admin.com";
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
                    p.SenderMail = "admin@admin.com";
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
        //Taslaklara ekleme işlemi yapılması için
        public ActionResult AddDraft()
        {
            var result = mm.IsDraft();
            return View(result);
        }
        //Taslaklara gönderilen mesajın tekrar çağırılması için
        public ActionResult GetDraftDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult NewMessage(Message message, string menuName)
        //{
        //    string session = (string)Session["AdminMail"];
        //    ValidationResult results = messagevalidator.Validate(message);
        //    //Yeni Mesaj sayfasındaki buton isimlerine göre kontroller aşagıdaki gibi yapılır

        //    //Eğer kullanıcı Gönder tuşuna basarsa;
        //    if (menuName == "send")
        //    {
        //        if (results.IsValid)
        //        {
        //            message.SenderMail = session;
        //            //message.IsDraft = false;
        //            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //            mm.MessageAdd(message);
        //            return RedirectToAction("Sendbox");
        //        }
        //        else
        //        {
        //            foreach (var item in results.Errors)
        //            {
        //                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //            }
        //        }
        //    }
        //    //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
        //    else if (menuName == "draft")
        //    {
        //        if (results.IsValid)
        //        {
        //            message.SenderMail = session;
        //            message.IsDraft = true;
        //            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //            mm.MessageAdd(message);
        //            return RedirectToAction("DraftMessages");
        //        }
        //        else
        //        {
        //            foreach (var item in results.Errors)
        //            {
        //                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //            }
        //        }
        //    }
        //    //Eğer kullanıcı İptal tuşuna basarsa;
        //    else if (menuName == "cancel")
        //    {
        //        return RedirectToAction("NewMessage");
        //    }
        //    return View();
        //}




        public ActionResult DraftMessages()
        {
            //string session = (string)Session["AdminMail"];
            var result = mm.IsDraft();
            return View(result);
        }



        public ActionResult DeleteMessage() //Bu alan gelen mesajlarindaki silindi butonundan gelen degeri DB yazar --> Henüz inbox da bu buton eklenmedi !!!
        {
            var result = mm.GetListTrash();
            //if (result.Trash == true)
            //{
            //    result.Trash = false;
            //}
            //else
            //{
            //    result.Trash = true;
            //}
            //mm.MessageDelete(result);
            return View(result);
        }





        //public ActionResult IsRead(int id) //Bu alan gelen mesajlarindaki okundu butonundan gelen degeri DB yazar
        //{
        //    var messageValue = mm.GetByID(id);

        //    if (messageValue.IsRead)
        //    {
        //        messageValue.IsRead = false;
        //    }
        //    else
        //    {
        //        messageValue.IsRead = true;
        //    }

        //    mm.MessageUpdate(messageValue);
        //    return RedirectToAction("Inbox");
        //}

        //public ActionResult IsImportant(int id) //Bu alan gelen mesajlarindaki önemli butonundan gelen degeri DB yazar
        //{
        //    var messageValue = mm.GetByID(id);

        //    if (messageValue.IsImportant)
        //    {
        //        messageValue.IsImportant = false;
        //    }
        //    else
        //    {
        //        messageValue.IsImportant = true;
        //    }

        //    mm.MessageUpdate(messageValue);
        //    return RedirectToAction("Inbox");
        //}
    }
}