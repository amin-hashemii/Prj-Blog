using Prj_Blog.CoreLayer.DTOs.Category;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category category)
        {
            return new CategoryDto()
            {

                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Title = category.Title,
                ParentId = category.ParentId,
                Slug = category.Slug,
                Id = category.Id


            };
        }
    }
}
