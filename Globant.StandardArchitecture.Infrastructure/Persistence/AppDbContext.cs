using Globant.StandardArchitecture.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Globant.StandardArchitecture.Infrastructure.Persistence.Entity
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DatabaseType databaseType, string connectionString)
            : base(databaseType, connectionString) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupUser> UserGroupUsers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(u => u.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(u => u.Email)
                    .HasColumnName("email")
                    .HasMaxLength(300)
                    .IsRequired();

                entity.Property(u => u.UpsertBy)
                    .HasColumnName("upsert_by")
                    .IsRequired(false);

                entity.Property(u => u.UpsertAt)
                    .HasColumnName("upsert_at")
                    .IsRequired();

                entity.Property(u => u.Active)
                    .HasColumnName("active")
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(u => u.UpsertBy);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("user_group");
                entity.HasKey(ug => ug.Id);

                entity.Property(ug => ug.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(ug => ug.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(ug => ug.UpsertBy)
                    .HasColumnName("upsert_by")
                    .IsRequired();

                entity.Property(ug => ug.UpsertAt)
                    .HasColumnName("upsert_at")
                    .IsRequired();

                entity.Property(ug => ug.Active)
                    .HasColumnName("active")
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ug => ug.UpsertBy);
            });

            modelBuilder.Entity<UserGroupUser>(entity =>
            {
                entity.ToTable("user_group_user");
                entity.HasKey(ugu => ugu.Id);

                entity.Property(ugu => ugu.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(ugu => ugu.UserId)
                    .HasColumnName("user_id")
                    .IsRequired();

                entity.Property(ugu => ugu.UserGroupId)
                    .HasColumnName("user_group_id")
                    .IsRequired();

                entity.Property(ugu => ugu.UpsertBy)
                    .HasColumnName("upsert_by")
                    .IsRequired();

                entity.Property(ugu => ugu.UpsertAt)
                    .HasColumnName("upsert_at")
                    .IsRequired();

                entity.Property(ugu => ugu.Active)
                    .HasColumnName("active")
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ugu => ugu.UpsertBy);

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ugu => ugu.UserId);

                entity.HasOne<UserGroup>()
                    .WithMany()
                    .HasForeignKey(ugu => ugu.UserGroupId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
