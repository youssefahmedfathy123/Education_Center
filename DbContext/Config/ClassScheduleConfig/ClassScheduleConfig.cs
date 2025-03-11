using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.ClassScheduleConfig
{
    public class ClassScheduleConfig : IEntityTypeConfiguration<ClassSchedule>
    {
        public void Configure(EntityTypeBuilder<ClassSchedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.User).WithMany(m => m.ClassSchedules).HasForeignKey(f => f.Teacher_id)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(o => o.Subject)
                    .WithMany(m => m.ClassSchedules)
                    .HasForeignKey(f => f.Subject_id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(o => o.Branch)
                    .WithMany(m => m.ClassSchedules)
                    .HasForeignKey(f => f.Branch_id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }

    }
}

