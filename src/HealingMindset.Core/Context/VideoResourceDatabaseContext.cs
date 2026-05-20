using System;
using System.Collections.Generic;
using HealingMindset.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace HealingMindset.Repositories.Context
{
    public class VideoResourceDatabaseContext : DbContext
    {
        public VideoResourceDatabaseContext () { }

        public VideoResourceDatabaseContext(DbContextOptions<VideoResourceDatabaseContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<VideoResourceModel> VideoResources { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoResourceModel>(entity =>
            {
                entity.HasKey(e => e.)
            })
        }
    }
}
