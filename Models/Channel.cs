using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Channel
    {
        [Key]
        public int Id { get; set; }

        public string ChannelName { get; set; }

        public int SortId { get; set; }

        public string Url { get; set; }
    }
}
