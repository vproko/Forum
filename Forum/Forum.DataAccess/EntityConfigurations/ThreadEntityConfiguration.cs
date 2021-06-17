using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.EntityConfigurations
{
    public class ThreadEntityConfiguration : IEntityTypeConfiguration<Thread>
    {
        public void Configure(EntityTypeBuilder<Thread> builder)
        {
            builder.Property(t => t.ThreadId)
                   .HasColumnType("uniqueidentifier");

            builder.HasKey(t => t.ThreadId);

            builder.Property(t => t.CategoryId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(t => t.Title)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(t => t.DateCreated)
                   .HasColumnType("datetime2(7)")
                   .IsRequired();

            builder.Property(t => t.Locked)
                    .HasColumnType("bit")
                    .HasDefaultValue(false)
                    .IsRequired();

            builder.Property(t => t.Sticky)
                    .HasColumnType("bit")
                    .HasDefaultValue(false)
                    .IsRequired();

            builder.Ignore(t => t.PostsCount);

            builder.HasMany(t => t.Posts)
                   .WithOne(p => p.Thread)
                   .HasForeignKey(p => p.ThreadId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
