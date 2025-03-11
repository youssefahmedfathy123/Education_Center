using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.AttendanceConfig
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.User).WithMany(m => m.Attendances).HasForeignKey(f => f.Student_id);
            builder.HasOne(o => o.User).WithMany(m => m.Attendances).HasForeignKey(f => f.Recorded_by);
        }
    }
}
