using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCResumeSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public string UpdateReason { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}