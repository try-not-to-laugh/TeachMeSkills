﻿using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Comment> Comments => Set<Comment>();
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {
        }
    }
}