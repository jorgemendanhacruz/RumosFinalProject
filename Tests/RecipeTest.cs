using ProjetoPratico.Domain;
using Xunit;

namespace Tests
{
    public class RecipeTest
    {
       
        [Fact]
        public void ShouldRecipeBeCreated()
        {
            // Arrange
            var name = Name.CreateName("name");
            var cookingTime = CookingTime.Add(20);
            var value = DifficultyLevelCondition.Create(3);
            var difficultyLevel = new DifficultyLevel(value.Value);
            var execution = Execution.Create("Description");
            var recipeCategoryDescription = RecipeCategoryDescription.Create("Description");
            var recipeCategory = new RecipeCategory(recipeCategoryDescription.Value);

            var ingredients = new List<IngredientRecipe>();
            var ingredientDescription = IngredientDescription.Create("Ingredient");
            var validIngredient = new Ingredient(ingredientDescription.Value);
            var ingredientRecipe = new IngredientRecipe(validIngredient);
            ingredients.Add(ingredientRecipe);

            // Act
            var recipeTest = new Recipe(
                name: name.Value,
                cookingTime: cookingTime.Value,
                difficultyLevel: difficultyLevel,
                execution: execution.Value,
                ingredients: ingredients,
                recipeCategory: recipeCategory
                );

            // Assert
            Assert.Equal(name.Value, recipeTest.Name);
            Assert.Equal(cookingTime.Value, recipeTest.CookingTime);
            Assert.Equal(difficultyLevel, recipeTest.DifficultyLevel);
            Assert.Equal(execution.Value, recipeTest.Execution);
            Assert.Equal(ingredients ,recipeTest.Ingredients);
            Assert.Equal(recipeCategory, recipeTest.RecipeCategory);
          
        }
    }
}
    