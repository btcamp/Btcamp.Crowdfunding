using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("City")]
    public class City : BaseEntity
    {
        public int NID { get; set; }
        public string CityName { get; set; }
        public int PID { get; set; }

        public string ZipCode { get; set; }
    }
}
