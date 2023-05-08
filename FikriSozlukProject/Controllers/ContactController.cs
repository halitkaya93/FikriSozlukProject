using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FikriSozlukProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalue = cm.GetList();
            return View(contactvalue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetByID(id);
            return View(contactvalue);
            
        }

        public PartialViewResult ContactPartial()
        {
            //sonrasında düzenlenecek
            //Context c = new Context();
            string p = (string)Session["WriterMail"];
            var TotalContacts = cm.GetList().Count(); //Toplam İletişim Mesaj sayısı
            var TotalInbox = mm.GetListInbox(p).Where(x => x.ReceiverMail == p).Count();  //Toplam Inbox sayısı
            var TotalSendbox = mm.GetListSendbox(p).Where(x => x.SenderMail == p).Count();  //Toplam Sendbox sayısı
           // var TotalIsDraft = mm.GetListSendbox(p).Where(x => x.IsDraft == true).Count();  //Toplam Draft sayısı

            ViewBag.TotalContacts = TotalContacts;
            ViewBag.TotalInbox = TotalInbox;
            ViewBag.TotalSendbox = TotalSendbox;
           // ViewBag.TotalIsDraft = TotalIsDraft;

            return PartialView();
        }
        public PartialViewResult PartialMessageList()   //Mesaj alanın üst tarafındaki küçük işlem kutucukları için
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageListFooter()     //Mesaj alanın alt tarafındaki küçük işlem kutucukları için
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageListFooterButton()    //Mesaj alanın En altta yer alan Gönder, Taslaklara Kadet, İptal kutucukları için
        {
            return PartialView();
        }
    }
}