using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class PostComment :BaseEntitiy
    {
   
        public int UserID {  get; set; }
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
