using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class BlogPost
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public string PostContent { get; set; } = string.Empty;
        public DateTime PostCreationDate { get; set; }
    }
}