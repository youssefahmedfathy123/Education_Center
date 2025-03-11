using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.StudentSubjectsConfig
{
    public class StudentSubjectsConfig : IEntityTypeConfiguration<StudentSubjects>
    {
        public void Configure(EntityTypeBuilder<StudentSubjects> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.User)
                .WithMany(m => m.StudentSubjects)
                .HasForeignKey(f => f.Student_id);

            builder.HasOne(o => o.Subject)
                 .WithMany(m => m.StudentSubjects)
                 .HasForeignKey(f => f.Subject_id);
        }
    }
}
