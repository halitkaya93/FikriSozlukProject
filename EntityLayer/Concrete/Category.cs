using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //Category i kaldırmak yerine pasif hale getirmek için bool kullandık

        //Category ile Heading tablosu arasındaki ilişkiyi kurarak başlıyoruz.
        public ICollection<Heading> Headings { get; set; }     //bir collection türündeki interface


    }
}
