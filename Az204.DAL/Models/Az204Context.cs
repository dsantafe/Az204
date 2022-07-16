using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Az204.DAL.Models
{
    public partial class Az204Context : DbContext
    {
        public Az204Context()
        {
        }

        public Az204Context(DbContextOptions<Az204Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicative> Applicatives { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DevelopmentEngineer> DevelopmentEngineers { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectState> ProjectStates { get; set; } = null!;
        public virtual DbSet<Requirement> Requirements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Project_Customer");

                entity.HasOne(d => d.ProjectState)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStateId)
                    .HasConstraintName("FK_Project_ProjectState");
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.HasOne(d => d.Applicative)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.ApplicativeId)
                    .HasConstraintName("FK_Area_Applicative");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Requirement_Area");

                entity.HasOne(d => d.DevelopmentEngineer)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.DevelopmentEngineerId)
                    .HasConstraintName("FK_Area_DevelopmentEngineer");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK_Area_Priority");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Requirement_Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
