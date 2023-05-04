using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }
        
        [StringLength(50)]
        public string AdminPassword { get; set; }

       [StringLength(1)]
        public string AdminRole { get; set; }

        //public string  AdminMail { get; set; }
        //public byte[] AdminMail { get; set; }

        //public byte[] AdminPasswordHash { get; set; }

        //public byte[] AdminPasswordSalt { get; set; }

        //public bool AdminStatus { get; set; }
        //public int? StatusId { get; set; }

        //public virtual Status Status { get; set; }

        //public int? RoleId { get; set; }

        //public virtual Role Role { get; set; }
    }
}
