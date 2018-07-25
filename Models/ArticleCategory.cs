using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ArticleCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="文章栏目不能为空")]
        public int ChannelID { get; set; }

        [ForeignKey("ChannelID")]
        public virtual Channel Channel { get; set;}

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 父栏目ID
        /// </summary>
        public int? ParentId { get; set;}
    }
}
