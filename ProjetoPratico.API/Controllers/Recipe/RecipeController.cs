using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPratico.API.Controllers.Ingredient;
using ProjetoPratico.Domain;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.UnitOfWork;

namespace ProjetoPratico.API.Controllers.Recipe
{
    [Route("api/v1/recipe/")]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICookUnitOfWork _cookUnitOfWork;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly IUserRepository _userRepository;
        public RecipeController(
            IRecipeRepository recipeRepository,
            ICookUnitOfWork cookUnitOfWork,
            IIngredientRepository ingredientRepository,
            IRecipeCategoryRepository recipeCategoryRepository,
            IDifficultyLevelRepository difficultyLevelRepository,
            IUserRepository userRepository)
        {
            _recipeRepository = recipeRepository;
            _cookUnitOfWork = cookUnitOfWork;
            _ingredientRepository = ingredientRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
            _difficultyLevelRepository = difficultyLevelRepository;
            _userRepository = userRepository;
        }
        // GET: api/<Recipe>
        [HttpGet()]
        public async Task<IList<GetRecipeModel>> Get()
        {
            var recipe = _recipeRepository
                .GetAll();

            return recipe.Select(
                recipe => new GetRecipeModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name.Value,
                    Execution = recipe.Execution.Value,

                }).ToList();
        }

        // GET api/<Recipe>/5
        [HttpGet("{id}")]
        public async Task<GetRecipeByIdModel> Get(int id)
        {
            var recipe = await _recipeRepository
                .GetAsync(id);

            var ingredientRecipe = new List<GetRecipeIngredientModelById>();

            
            foreach (var ingredientsList in recipe.Ingredients)
            {
                var ingredient = new GetRecipeIngredientModelById();
                ingredient.IngridientId = ingredientsList.Id;
                ingredient.Quantity = ingredientsList.Quantity;
                ingredientRecipe.Add(ingredient);
            }

            return new GetRecipeByIdModel
            {
                Id = recipe.Id,
                Name = recipe.Name.Value,
                DifficultyLevel = recipe.DifficultyLevel.Level.Value,
                CookingTime = recipe.CookingTime.Value,
                Execution = recipe.Execution.Value,
                RecipeCategory = recipe.RecipeCategory.Category.Value,
                UserId = recipe.UserId.Id,
                Ingredients = ingredientRecipe
            };
        }

        // POST api/<Recipe>
        [HttpPost]
        public async Task Post([FromBody]PostRecipeModel post)
        {
            var name = ProjetoPratico.Domain.Name.CreateName(post.Name);

            var cookingTime = ProjetoPratico.Domain.CookingTime.Add(post.CookingTime);

            var execution = ProjetoPratico.Domain.Execution.Create(post.Execution);


            foreach (var IngredientsList in post.Ingredients)
            {
                var ingredient = await _ingredientRepository.GetAsync(IngredientsList.IngridientId);
            }

            var recipeCategory = await _recipeCategoryRepository.GetAsync(post.RecipeCategoryId);

            var difficultyLevel = await _difficultyLevelRepository.GetAsync(post.DifficultyLevel);

            var user = await _userRepository.GetAsync(post.UserId);

            var recipeIngredient = new List<IngredientRecipe>();


            foreach (var ingredient in post.Ingredients)
            {
                var ingredientById = await _ingredientRepository.GetAsync(ingredient.IngridientId);
                var ingredientRecipe = new IngredientRecipe(ingredientById);
                recipeIngredient.Add(ingredientRecipe);
            }

            var recipe = new ProjetoPratico.Domain.Recipe(
                                name: name.Value,
                                cookingTime: cookingTime.Value,
                                execution: execution.Value,
                                ingredients: recipeIngredient,
                                recipeCategory: recipeCategory,
                                difficultyLevel: difficultyLevel);

            _recipeRepository.Add(recipe);

            await _cookUnitOfWork.CommitAsync();

        }

        // PUT api/<Recipe>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PostRecipeModel post)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            
            if(recipe != null)
            {
                var name = ProjetoPratico.Domain.Name.CreateName(post.Name);

                var cookingTime = ProjetoPratico.Domain.CookingTime.Add(post.CookingTime);

                var execution = ProjetoPratico.Domain.Execution.Create(post.Execution);

               
                foreach(var IngredientsList in post.Ingredients)
                {
                    var ingredient = await _ingredientRepository.GetAsync(IngredientsList.IngridientId);
                }

                var recipeCategory = await _recipeCategoryRepository.GetAsync(post.RecipeCategoryId);

                var difficultyLevel = await _difficultyLevelRepository.GetAsync(post.DifficultyLevel);

                var user = await _userRepository.GetAsync(post.UserId);

                var recipeIngredient = new List<IngredientRecipe>();


                foreach (var ingredient in post.Ingredients)
                {
                    var ingredientById = await _ingredientRepository.GetAsync(ingredient.IngridientId);
                    var ingredientRecipe = new IngredientRecipe(ingredientById);
                    recipeIngredient.Add(ingredientRecipe);
                }
                    
                    recipe = new ProjetoPratico.Domain.Recipe(
                        name: name.Value,
                        cookingTime: cookingTime.Value,
                        execution: execution.Value,
                        ingredients: recipeIngredient,
                        recipeCategory: recipeCategory,
                        difficultyLevel: difficultyLevel);

                _recipeRepository.Modify(recipe);

                await _cookUnitOfWork.CommitAsync();
            }
        }

        // DELETE api/<Ingredient>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var recipe = await _recipeRepository.GetAsync(id);

            if (recipe != null)
            {
                _recipeRepository.Delete(recipe);

            }
        }
    }
}
