using Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Models.DbEntities.Attachments;
using Models.DbEntities.Hospitals;
using Models.DbEntities.Post;
using Models.DbEntities.Registration;
using Models.DbEntities.User;

namespace Data.Contexts
{
    public class ApplicationDbContext : DbContext, IDbContext
    {

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<BloodGroup> BloodGroups { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Register> Registers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterEntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasOne<UserInfo>(reg => reg.UserInfo)
                    .WithMany(user => user.Register)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne<BloodGroup>(res => res.BloodGroup)
                .WithMany(blood => blood.Registers)
                .HasForeignKey(res => res.BloodGroupId);
            });
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasOne<Category>(blog => blog.Category)
                    .WithMany(ctg => ctg.Blogs)
                    .HasForeignKey(e => e.CategoryId);
            });
            modelBuilder.Entity<BlogTag>().HasKey(sc => new { sc.BlogId, sc.TagId });


            modelBuilder.Entity<BlogTag>()
                .HasOne<Blog>(sc => sc.Blog)
                .WithMany(s => s.BlogTags)
                .HasForeignKey(sc => sc.BlogId);


            modelBuilder.Entity<BlogTag>()
                .HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.BlogTags)
                .HasForeignKey(sc => sc.TagId);

            modelBuilder.Entity<EventTag>()
                .HasOne<Event>(sc => sc.Event)
                .WithMany(s => s.EventTags)
                .HasForeignKey(sc => sc.EventId);

            modelBuilder.Entity<EventTag>().HasKey(sc => new { sc.EventId, sc.TagId });

            modelBuilder.Entity<EventTag>()
                .HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.EventTags)
                .HasForeignKey(sc => sc.TagId);

            modelBuilder.Entity<BloodGroup>()
                .HasMany<UserInfo>(sc => sc.UserInfo)
                .WithOne(s => s.BloodGroup)
                .HasForeignKey(sc => sc.BloodId);

        }

        public void RegisterEntityMapping(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false) &&
                (type.BaseType.GetGenericTypeDefinition() == typeof(MappingEntityTypeConfiguration<>))
            );
            foreach (var item in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(item);
                configuration.ApplyConfiguration(modelBuilder);
            }
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
