﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Entities
{
    public class Category:BaseEntitiy
    {
     
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription  { get; set; }
        public int? ParentId { get; set; }

        [InverseProperty("Category")]
        public ICollection<Post> Posts { get; set; }

        [InverseProperty("SubCategory")]
        public ICollection<Post> SubPosts { get; set; }
    }
}
