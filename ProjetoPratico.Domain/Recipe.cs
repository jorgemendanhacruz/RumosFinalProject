using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class Recipe : AggregateRoot
    {
        
        
        private Recipe() //Construtor criado para evitar bug SQL
        {
        }

       public Recipe(Name name, CookingTime cookingTime, DifficultyLevel difficultyLevel, Execution execution, ICollection<IngredientRecipe> ingredients, RecipeCategory recipeCategory)
        {
            Name = name;
            CookingTime = cookingTime;
            DifficultyLevel = difficultyLevel;
            Execution = execution;
            Ingredients = ingredients;
            RecipeCategory = recipeCategory;
        }
        public Name Name { get; }

        public CookingTime CookingTime { get; }

        public DifficultyLevel DifficultyLevel { get; }

        public Execution Execution { get; }

        public ICollection<IngredientRecipe> Ingredients { get; }

        public RecipeCategory RecipeCategory { get; }

        public User UserId { get; }




    }
}
