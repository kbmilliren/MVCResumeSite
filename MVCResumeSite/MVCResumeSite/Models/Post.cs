using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCResumeSite.Models
{

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [DisplayFormat( DataFormatString="{0:dd/MM/yy}", ApplyFormatInEditMode=true )]
        public DateTimeOffset DateCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset DateUpdated { get; set; }
        [AllowHtml]
        [Required]
        public string Body { get; set; }
        public string MediaUrl { get; set; }
        public bool Published { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new HashSet<Comment>();
        }

    }

}