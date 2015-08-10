using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Entitys
{
    [Table("About")]
    public class About : BaseEntity
    {

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// QQ官方交流群
        /// </summary>
        [Required]
        public string QQGroupNumber { get; set; }

        /// <summary>
        /// 微信公众号
        /// </summary>
        [Required]
        public string WeChatNumber { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Required]
        public string VersionNumber { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

    }
}
