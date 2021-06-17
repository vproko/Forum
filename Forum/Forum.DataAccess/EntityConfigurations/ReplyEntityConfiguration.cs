using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.EntityConfigurations
{
    public class ReplyEntityConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.Property(r => r.ReplyId)
                   .HasColumnType("uniqueidentifier");

            builder.HasKey(r => r.ReplyId);

            builder.Property(r => r.UserId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(r => r.PostId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(r => r.Username)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(r => r.Content)
                   .IsRequired();

            builder.Property(r => r.Reported)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(r => r.DateReplied)
                   .HasColumnType("datetime2(7)")
                   .IsRequired();

            builder.Property(r => r.Edited)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(r => r.EditedBy)
                   .HasMaxLength(100)
                   .IsRequired(false);
        }
    }
}