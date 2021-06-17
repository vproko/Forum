using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.PostId)
                   .HasColumnType("uniqueidentifier");

            builder.HasKey(p => p.PostId);

            builder.Property(p => p.ThreadId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(p => p.UserId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(p => p.Username)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(p => p.Content)
                   .IsRequired();

            builder.Property(p => p.Reported)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(p => p.Edited)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(p => p.EditedBy)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(p => p.DatePosted)
                   .HasColumnType("datetime2(7)")
                   .IsRequired();

            builder.Ignore(p => p.RepliesCount);

            builder.HasMany(p => p.Replies)
                   .WithOne(r => r.Post)
                   .HasForeignKey(r => r.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}