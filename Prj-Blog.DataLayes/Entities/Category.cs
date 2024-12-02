using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class Category:BaseEntitiy
    {
     
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public int MetaDescription  { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
