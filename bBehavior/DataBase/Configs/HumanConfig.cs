using bModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bBehavior.DataBase.Configs
{
    public class HumanConfig : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.HasOne(u => u.User)
            //    .WithOne(u => u.Human).HasForeignKey<Human>(u => u.UserId);
            //builder.HasOne(u => u.Card)
            //    .WithOne(u => u.Owner).HasForeignKey<Human>(u => u.CardId);
            builder.HasIndex(u => u.PasportNum).IsUnique();
        }
    }
}
