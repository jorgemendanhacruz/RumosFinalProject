namespace ProjetoPratico.API.Controllers.User
{
    public class GetUserByIdModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public string Pass { get; set; }

        public string Email { get; set; }

        public int RecipeId { get; set; }

        public GetUserByIdModel()
        {

        }
    }
}
