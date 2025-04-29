using Microsoft.Identity.Client;
using Prj_Blog.CoreLayer.DTOs.Category;
using Prj_Blog.CoreLayer.Mappers;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Context;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Prj_Blog.CoreLayer.Services.Categorys
{
 
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            if (IsSlugExists(command.Slug))
                return OperationResult.Error("slug is exist");

            var category = new Category()
            {
                Title = command.Title,
                IsDeleted =false,
                ParentId = command.ParentId,
                Slug = command.Slug,
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription,
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
           var category = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            if (category ==null)
                return OperationResult.NotFound();


            if(command.Slug.ToSlug() !=category.Slug)
                if (IsSlugExists(command.Slug))
                    return OperationResult.Error("slug is exist");

            category.MetaDescription = command.MetaDescription;
            category.Slug = command.Slug;
            category.Title = command.Title;
            category.MetaTag = command.MetaTag;
           
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
           return _context.Categories.Select(category =>CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return null;
         return  CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public bool IsSlugExists(string slug)
        {
           return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
