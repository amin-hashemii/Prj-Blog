using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class User:BaseEntitiy
    {
    
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> postComments { get; set; }

    }

    public enum UserRole 
    {
        Admin,
        User,
        Writer
    }

}
