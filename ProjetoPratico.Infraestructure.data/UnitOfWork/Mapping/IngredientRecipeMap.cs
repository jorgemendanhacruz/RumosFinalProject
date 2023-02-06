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
    public class IngredientRecipeMap : IEntityTypeConfiguration<IngredientRecipe>
    {
        public void Configure(EntityTypeBuilder<IngredientRecipe> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.HasOne<Ingredient>(i => i.Ingredient);
        }
    }
}
