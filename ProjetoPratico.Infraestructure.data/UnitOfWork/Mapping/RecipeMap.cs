using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPratico.Domain;

namespace ProjetoPratico.Infraestructure.data.Mapping
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                 .HasKey(r => r.Id);

            builder
                .Property(u => u.Name)
                .HasConversion(u => u.Value, u => Name.CreateName(u).Value)
                .HasMaxLength(15)
                .HasColumnType("varchar")
                .IsRequired();

            builder
               .Property(r => r.CookingTime)
               .HasConversion(r => r.Value, r => CookingTime.Add(r).Value)
               .HasColumnType("integer")
               .IsRequired();

            builder
              .Property(r => r.Execution)
              .HasConversion(r => r.Value, r => Execution.Create(r).Value)
              .HasColumnType("varchar")
              .HasMaxLength(200)
              .IsRequired();


            builder.HasOne<DifficultyLevel>(r => r.DifficultyLevel);

            builder.HasOne<RecipeCategory>(r => r.RecipeCategory);

            builder.HasMany<IngredientRecipe>(i => i.Ingredients);

            

           
;                


        }
    }
}