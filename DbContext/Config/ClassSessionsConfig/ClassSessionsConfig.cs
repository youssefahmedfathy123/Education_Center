using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.ClassSessionsConfig
{
    public class ClassSessionsConfig : IEntityTypeConfiguration<ClassSessions>
    {
        public void Configure(EntityTypeBuilder<ClassSessions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.ClassSchedule)
                   .WithMany(m => m.ClassSessions)
                   .HasForeignKey(f => f.Schedule_id);
        }
    }
}
