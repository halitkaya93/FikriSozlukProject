using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext       //bir başka sınıftan kalıtsal yolla alım yapmak için : kullanıyoruz
    {
        public DbSet<About> Abouts { get; set; }    //About benim projemin içinde yer alan sınıfın ismi, Abouts ise SQL de tablomuza yansıyacak ismi
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }    //sonradan eklenen tablo
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins{ get; set; }
    }
}
