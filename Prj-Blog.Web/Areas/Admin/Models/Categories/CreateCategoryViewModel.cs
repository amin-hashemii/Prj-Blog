﻿using Prj_Blog.CoreLayer.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace Prj_Blog.Web.Areas.Admin.Models.Categories
{
    public partial class CreateCategoryViewModel
    {
        [Display(Name ="عنوان")]
        [Required(ErrorMessage = "وارد کردن {0}اجباری است")]
        public string Title { get; set; }

         [Display(Name ="Slug")]
       [Required(ErrorMessage = "وارد کردن {0}اجباری است")]
        public string Slug { get; set; }

        public int? ParentId { get; set; }
        [Display(Name = "Metatag(با - از هم جدا کنید)")]
        
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }


        public CreateCategoryDto  MapToDto()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                MetaDescription = MetaDescription,
                Slug = Slug,
                ParentId = ParentId,
                MetaTag = MetaTag

            };


        }

        }
}
