using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class Post :BaseEntitiy
    {
   
        public int UserId { get; set; }

     
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }

        public string ImageName {  get; set; }
        public int Visit { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }

        public ICollection<PostComment> PostComments { get; set; }
    }
}
