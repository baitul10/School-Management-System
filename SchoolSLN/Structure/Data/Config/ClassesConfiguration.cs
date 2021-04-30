using Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Structure.Data.Config
{
    public class ClassesConfiguration : IEntityTypeConfiguration<Classes>
    {
        public void Configure(EntityTypeBuilder<Classes> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired().HasMaxLength(500);
        }
    }
}
