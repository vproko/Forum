using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                   .HasColumnType("uniqueidentifier");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();
            
            builder.Property(u => u.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Joined)
                   .HasColumnType("datetime2(7)")
                   .IsRequired();

            builder.Property(u => u.Online)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(u => u.Suspended)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(u => u.IsItAdministrator)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(u => u.Avatar)
                   .HasMaxLength(400);

            builder.Ignore(u => u.PostsCount);

            builder.Ignore(u => u.RepliesCount);

            builder.Ignore(u => u.MessagesCount);

            builder.HasMany(u => u.Posts)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Messages)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.ReceiverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Replies)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
