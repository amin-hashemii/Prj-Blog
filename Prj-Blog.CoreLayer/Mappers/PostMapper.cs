using Prj_Blog.CoreLayer.DTOs.Category;
using Prj_Blog.CoreLayer.DTOs.Post;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug,
                Title = dto.Title,
                UserId = dto.UserId,
                Visit = 0,
                IsDeleted = false
            };
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserId = post.UserId,
                Visit = 0,
               CreationDate = post.CreationDate,
               Category =CategoryMapper.Map(post.Category),
               ImageName = post.ImageName,
               PostId = post.Id,
            };
        }
        public static Post EditPost(EditPostDto editdto, Post post)
        {
            post.Description = editdto.Description;
            post.CategoryId = editdto.CategoryId;
            post.Slug = editdto.Slug.ToSlug();
            post.Title = editdto.Title;
            return post;
        }

    }
}
