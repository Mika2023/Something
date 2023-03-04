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
    public class CardTransactConfig : IEntityTypeConfiguration<CardTransact>
    {
        public void Configure(EntityTypeBuilder<CardTransact> builder)
        {
           
        }
    }
}
