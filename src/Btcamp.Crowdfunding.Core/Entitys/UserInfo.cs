using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("UserInfo")]
    public class UserInfo : BaseEntity
    {
        public UserInfo()
        {
            CreateDateTime = DateTime.Now;
            LastLoginDateTime = DateTime.Now;
        }
        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        public int LoginErrorCount { get; set; }

        [StringLength(512)]
        public string AuthorityUrl { get; set; }
    }
}
