using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.DTOs.Post
{
    public class CreatePostDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public string Title { get; set; }
      
        public string Slug { get; set; }
       
        public string Description { get; set; }
      
    }

}
