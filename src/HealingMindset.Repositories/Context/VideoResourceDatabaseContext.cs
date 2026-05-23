using System;
using System.Collections.Generic;
using HealingMindset.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace HealingMindset.Repositories.Context
{
    public partial class VideoResourceDatabaseContext : DbContext
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
                entity.HasKey(e => e.VideoResourceId);

                entity.Property(e => e.Title).HasMaxLength(200);
                entity.Property(e => e.YoutubeId).HasMaxLength(20);
                entity.Property(e => e.Description).HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
