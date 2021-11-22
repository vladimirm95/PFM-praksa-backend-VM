using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transactions.Database.Entities;

namespace Transactions.Database.Configurations
{

    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
      public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("transactions");

          
                builder.HasKey(x => x.id);
           builder.Property(x => x.id);
            builder.Property(x => x.beneficiary_name);
            builder.Property(x => x.date);
            builder.Property(x => x.direction);
            builder.Property(x => x.amount);
            builder.Property(x => x.description);
            builder.Property(x => x.currency);
            builder.Property(x => x.mcc);
            builder.Property(x => x.kind);
            
        }
        }
    }
