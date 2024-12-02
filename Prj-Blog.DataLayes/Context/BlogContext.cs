﻿using Microsoft.EntityFrameworkCore;
using Prj_Blog.DataLayes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.DataLayes.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options)
        {
            
        }

       
        public  DbSet<Category> Categories { get; set; }
        public DbSet <Post> Posts { get; set; }
        public DbSet <PostComment> postComments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }


    }
}
