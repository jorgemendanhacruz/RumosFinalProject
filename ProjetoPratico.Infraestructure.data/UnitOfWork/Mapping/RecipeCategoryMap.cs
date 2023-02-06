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
    public class RecipeCategoryMap : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            
            builder
                .HasKey (c => c.Id);

            builder
                .Property(c => c.Category)
                .HasConversion(c => c.Value, c => RecipeCategoryDescription.Create(c).Value)
                .HasMaxLength(12)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
