﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        //List<Message> GetListInbox();
        //List<Message> GetListSendbox();
        //void MessageAdd(Message message);
        //Message GetById(int id);
        //void MessageDelete(Message message);
        //void MessageUpdate(Message message);

        //List<Message> GetListInbox(string session);
        //List<Message> GetListSendbox(string session);
        //List<Message> GetReadList(string session);
        //List<Message> GetUnReadList(string session);
        //List<Message> IsDraft(string session);
        //List<Message> GetListDraft(string session);
        //List<Message> GetListTrash();
        //List<Message> GetListSpam(string session);
        //List<Message> GetListImportant(string session);
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string P);
        //List<Message> GetReadList();
        //List<Message> GetUnReadList();
        List<Message> IsDraft();
        List<Message> GetListDraft();
        List<Message> GetListTrash();
        //List<Message> GetListSpam();
        //List<Message> GetListImportant();
        Message GetByID(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
