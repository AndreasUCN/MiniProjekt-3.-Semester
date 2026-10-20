using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string BlogTitle { get; set; } = string.Empty;
    }
}
