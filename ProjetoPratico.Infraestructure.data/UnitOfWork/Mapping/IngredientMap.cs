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
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Ing)
                .HasConversion(i => i.Value, i => IngredientDescription.Create(i).Value)
                .HasMaxLength(12)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
