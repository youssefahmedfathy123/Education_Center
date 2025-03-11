using Education_Center_Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.UserConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.Branch).WithMany(m => m.Users)
           .HasForeignKey(f => f.Branch_id).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
