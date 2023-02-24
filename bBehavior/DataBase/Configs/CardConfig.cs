using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bBehavior.DataBase.Configs
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(u => u.Owner)
                .WithOne(u => u.Card).HasForeignKey<Human>(u => u.CardId);
            builder.Property(u => u.CVC).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.CardNumber);
        }
    }
}
