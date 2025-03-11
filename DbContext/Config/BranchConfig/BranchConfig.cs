using Education_Center_Domain.Entities;
using Education_Center_Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext.Config.BranchConfig
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.User).WithMany(m => m.Branchs).HasForeignKey(f => f.ManagerId);
            builder.HasOne(o => o.Center).WithMany(m => m.Branches).HasForeignKey(f => f.CenterId);
        }
    }
}

