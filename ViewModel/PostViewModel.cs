using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationsDemoExperion.ViewModel
{
    public class PostViewModel
    {
        public int PId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public int? CId { get; set; }

        public string CategoryName { get; set; }
    }
}



/*        
        "Title": "Bidhu",
        "Description": "My Movie is Nice",
        "CId": 1
*/