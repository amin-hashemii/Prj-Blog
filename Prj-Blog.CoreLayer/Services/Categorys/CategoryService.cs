using Microsoft.Identity.Client;
using Prj_Blog.CoreLayer.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Services.Categorys
{
    public class CategoryService : ICategoryService
    {
        public void CreateCategory(CreateCategoryDto createdto)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(EditCategoryDto createdto)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
