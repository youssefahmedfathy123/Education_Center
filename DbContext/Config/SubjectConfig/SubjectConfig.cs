using Education_Center_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.SubjectConfig
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(o => o.Branch)
                  .WithMany(m => m.Subjects)
                  .HasForeignKey(f => f.Branch_id);
        }
    }
}
