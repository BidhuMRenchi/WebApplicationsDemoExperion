using System;
using System.Collections.Generic;

namespace WebApplicationsDemoExperion.Models
{
    public partial class Category
    { 
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int CId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
