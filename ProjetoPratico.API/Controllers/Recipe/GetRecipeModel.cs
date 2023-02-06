using ProjetoPratico.API.Controllers.Recipe;

namespace ProjetoPratico.API.Controllers.Ingredient
{
    public class GetRecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }

        public int DifficultyLevel { get; set; }

        public string Execution { get; set; }

        public string RecipeCategory { get; set; }

        public int UserId { get; set; }

        public IList<GetRecipeIngredientModel> Ingredients { get; set; }


        public GetRecipeModel()
        {

        }
           
    
    }
}
        


