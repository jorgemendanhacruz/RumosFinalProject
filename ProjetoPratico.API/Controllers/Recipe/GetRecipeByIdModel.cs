namespace ProjetoPratico.API.Controllers.Recipe
{
    public class GetRecipeByIdModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }

        public int DifficultyLevel { get; set; }

        public string Execution { get; set; }

        public string RecipeCategory { get; set; }

        public int UserId { get; set; }

        public IList<GetRecipeIngredientModelById> Ingredients { get; set; }


        public GetRecipeByIdModel()
        {

        }
    }
}
