namespace ProjetoPratico.API.Controllers.Recipe
{
    public class PostRecipeModel
    {
        public string Name { get; set; }
        public int CookingTime { get; set; }

        public int DifficultyLevel { get; set; }

        public string Execution { get; set; }

        public int RecipeCategoryId { get; set; }
       
        public IList<PostRecipeIngredientModel> Ingredients { get; set; }
        public int UserId { get; set; }

        public PostRecipeModel()
        {
            
        }

    }
}
