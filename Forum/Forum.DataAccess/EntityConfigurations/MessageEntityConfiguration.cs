using Forum.DomainClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.EntityConfigurations
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.MessageId)
                   .HasColumnType("uniqueidentifier");

            builder.HasKey(m => m.MessageId);

            builder.Property(m => m.ReceiverId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(m => m.SenderId)
                   .HasColumnType("uniqueidentifier")
                   .IsRequired();

            builder.Property(m => m.SenderUsername)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(m => m.Content)
                   .IsRequired();

            builder.Property(m => m.DateSent)
                   .HasColumnType("datetime2(7)")
                   .IsRequired();
        }
    }
}
