using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.SessionsAttendanceConfig
{
    class SessionsAttendanceConfig : IEntityTypeConfiguration<SessionAttendance>
    {
        public void Configure(EntityTypeBuilder<SessionAttendance> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.User)
                   .WithMany(m => m.SessionAttendances)
                   .HasForeignKey(f => f.Student_id);

            builder.HasOne(o => o.User)
                  .WithMany(m => m.SessionAttendances)
                  .HasForeignKey(f => f.recorded_by);

            builder.HasOne(o => o.ClassSessions)
                   .WithMany(m => m.SessionAttendances)
                   .HasForeignKey(f => f.Session_id);
        }
    }
}
