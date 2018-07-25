using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Description("文章模型")]
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="文章栏目不能为空")]
        public int ChannelID { get; set; }

        [ForeignKey("ChannelID")]
        public virtual Channel Channel { get; set; }

        [Required(ErrorMessage ="文章分类不能为空")]
        public int ClassID { get; set; }

        [ForeignKey("ClassID")]
        public virtual ArticleCategory Category { get; set; }

        /// <summary>
        /// 文章类型 1 为新闻 2 为下载 3为其他待定。后期修改为通过配置文件读取不同字段。
        /// </summary>
        public int TypeID { get; set; }

        [Required,MaxLength(25,ErrorMessage ="文章标题最多25个字符"),MinLength(2,ErrorMessage ="文章标题最少2个字符")]
        public string Title { get; set; }

        [Required(ErrorMessage ="文章内容不能为空")]
        public string Content { get; set; }

        public int Hits { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchText { get; set; }

        private DateTime _addTime { get; set; }

        public DateTime AddedDate
        {
            get
            {
                return _addTime;
            }
            set
            {
                _addTime = DateTime.Now;
            }

        }

        public int AdministratorID { get; set; }

        [ForeignKey("AdministratorID")]
        public virtual Administrator Creater { get; set; }

        public DateTime? UpdatedDate { get; set; }


        public int UpdatedPersonID { get; set;}

        [ForeignKey("UpdatedPersonID")]
        public virtual Administrator Updator { get; set; }

        /// <summary>
        /// 文章封面
        /// </summary>
        public string ImgSrc { get; set; }

        /// <summary>
        /// 文章排序ID，先按照排序ID排序，再按照创建时间排序
        /// </summary>
        public int SortId { get; set; }
    }
}
