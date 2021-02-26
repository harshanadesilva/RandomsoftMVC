using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MytestApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        //public DateTime CreatedTime { get; set; }
        public string AuthorName { get; set; }
        public int TotalLikes { get; set; }
    }
}