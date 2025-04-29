using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.DTOs.Post
{
    public class PostFilterDto
    {   
        public int PageCount { get; set; }
        public PostFilterParams FilterParams { get; set; }
        public List<PostDto> posts { get; set; }
    }

    public class PostFilterParams
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string CategorySlug { get; set; }
        public string Title { get; set; }
    }

}
