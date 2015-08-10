using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            UpdateTime = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
