using System;
using System.Collections.Generic;

namespace WebApplicationsDemoExperion.Models
{
    public partial class Post
    {
        public int PId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public int? CId { get; set; }

        public virtual Category C { get; set; }
    }
}
