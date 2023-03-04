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
    public class TransactConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasOne(x => x.Reciever).WithMany(x => x.TransactionsReciver);
            builder.HasOne(x => x.Sender).WithMany(x => x.TransactionsSener);
        }
    }
}
