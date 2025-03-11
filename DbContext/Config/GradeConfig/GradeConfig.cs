using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.GradeConfig
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.User)
                 .WithMany(m => m.Grades)
                 .HasForeignKey(f => f.Teacher_id);
            builder
                .HasOne(o => o.Subject)
                .WithMany(m => m.Grades)
                .HasForeignKey(f => f.Subject_id);
            builder
                .HasOne(o => o.GradeType)
                .WithMany(m => m.Grades)
                .HasForeignKey(f => f.Grade_type_id);
        }
    }
}
