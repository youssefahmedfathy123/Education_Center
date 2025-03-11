using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.TeacherSubjectConfig
{
    public class TeacherSubjectConfig : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.User)
            .WithMany(m => m.TeacherSubjects)
            .HasForeignKey(f => f.Teacher_id);

            builder.HasOne(o => o.Subject)
            .WithMany(m => m.TeacherSubjects)
            .HasForeignKey(f => f.Subject_id);
        }
    }
}
