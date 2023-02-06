using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPratico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.data.UnitOfWork.Mapping
{
    public class DifficultyLevelMap : IEntityTypeConfiguration<DifficultyLevel>
    {
 
        public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Level)
                .HasConversion(d => d.Value, d => DifficultyLevelCondition.Create(d).Value)
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}
