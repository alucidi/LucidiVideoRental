using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidiVideoRental.Models
{
    public class Video
    {
        public int id { get; set; }
        public string name { get; set; }

        public string category { get; set; }
    }
}