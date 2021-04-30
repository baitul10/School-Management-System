using Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Structure.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired().HasMaxLength(200);

            builder.Property(p => p.Roll).IsRequired();

            builder.Property(p => p.Phone).HasMaxLength(20);

            builder.Property(p => p.Email).HasMaxLength(500);

            builder.HasOne(b => b.School).WithMany()
                .HasForeignKey(p => p.SchoolId);

            builder.HasOne(b => b.Classes).WithMany()
                .HasForeignKey(p => p.ClassesId);
        }
    }
}
