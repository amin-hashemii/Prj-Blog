using Prj_Blog.CoreLayer.DTOs.Category;
using Prj_Blog.CoreLayer.DTOs.Post;
using Prj_Blog.CoreLayer.Mappers;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Context;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Services.Post
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);
        OperationResult Edit(EditPostDto command);
        PostDto GetCateGoryBy(int PostId);

        PostFilterDto GetPostByFilter(PostFilterParams filterParams);
        bool IsSlugExist(string slug);
    }
    public class PostService : IPostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreatePost(CreatePostDto command)
        {
            var post =PostMapper.MapCreateDtoToPost(command);
            _context.Posts.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult Edit(EditPostDto command)
        {
            var post = _context.Posts.FirstOrDefault(c=>c.Id==command.PostId);
            if(post == null)
                return OperationResult.NotFound();

            PostMapper.EditPost(command,post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public PostDto GetCateGoryBy(int PostId)
        {
           var post = _context.Posts.FirstOrDefault(c=> c.Id==PostId);
            return PostMapper.MapToDto(post);
        }

        public PostFilterDto GetPostByFilter(PostFilterParams filterParams)
        {
           var resault =_context.Posts.OrderByDescending(d=>d.CreationDate).AsQueryable();

            if(!string.IsNullOrWhiteSpace(filterParams.CategorySlug))
                resault = resault.Where(r=>r.Category.Slug==filterParams.CategorySlug);

            if (!string.IsNullOrWhiteSpace(filterParams.Title))
                resault = resault.Where(t => t.Category.Title == filterParams.Title);

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var pageCount = resault.Count() / filterParams.Take;

            return new PostFilterDto()
            {
                posts = resault.Skip(skip).Take(filterParams.Take).
                Select(Post => PostMapper.MapToDto(Post)).ToList(),
                FilterParams = filterParams,
                PageCount = pageCount,
            };   
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Posts.Any(c=>c.Slug==slug.ToSlug());
        }
    }
}
