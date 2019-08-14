using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedMe.Model
{
    public partial class Detail
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("date")]
        public string Date { get; set; }
        [Column("restraunt")]
        [StringLength(20)]
        public string Restraunt { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("Img_url")]
        public string Img_url { get; set; }
    }
}
