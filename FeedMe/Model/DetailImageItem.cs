using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedMe.Models
{
    public class DetailImageItem
    {
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Restraunt { get; set; }

    }
}