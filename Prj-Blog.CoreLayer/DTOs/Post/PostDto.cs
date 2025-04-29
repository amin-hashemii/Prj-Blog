using Prj_Blog.CoreLayer.DTOs.Category;

namespace Prj_Blog.CoreLayer.DTOs.Post
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
         public int Visit {  get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryDto Category { get; set; }
    }

}
