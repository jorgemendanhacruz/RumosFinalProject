using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.UnitOfWork;

namespace ProjetoPratico.API.Controllers.Ingredient
{
    [Route("api/v1/ingredient/")]
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICookUnitOfWork _cookUnitOfWork;
        public IngredientController(IIngredientRepository repository, ICookUnitOfWork cookUnitOfWork)
        {
            _ingredientRepository = repository;
            _cookUnitOfWork = cookUnitOfWork;
        }
        // GET: api/<Ingredient>
        [HttpGet]
        public async Task<IList<GetIngredientModel>> Get()
        {
            var ingredient = _ingredientRepository
                .GetAll();

            if (ingredient == null)
            {
                return null;
            }

            return ingredient.Select(
                ingredient => new GetIngredientModel
                {
                    Id = ingredient.Id,
                    Ing = ingredient.Ing.Value
                }).ToList();
        }

        // GET api/<Ingredient>/5
        [HttpGet("{id}")]
        public async Task<GetIngredientByIdModel> Get(int id)
        {
            var ingredient = await _ingredientRepository
                .GetAsync(id);

            if (ingredient == null)
            {
                return null;
            }
            return new GetIngredientByIdModel
            {
                Id = ingredient.Id, 
                Ing = ingredient.Ing.Value
            };
        }

        // POST api/<Ingredient>
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var description = ProjetoPratico.Domain.IngredientDescription.Create(value);
            var ingredient = new ProjetoPratico.Domain.Ingredient(description.Value);
            _ingredientRepository.Add(ingredient);
            await _cookUnitOfWork.CommitAsync();
        }

        // PUT api/<Ingredient>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            var description = ProjetoPratico.Domain.IngredientDescription.Create(value);
            var newIngredient = new ProjetoPratico.Domain.Ingredient(description.Value);
            _ingredientRepository.Modify(newIngredient);
            await _cookUnitOfWork.CommitAsync();
        }

        // DELETE api/<Ingredient>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

            var ingredient = await _ingredientRepository.GetAsync(id);
            _ingredientRepository.Delete(ingredient);
            await _cookUnitOfWork.CommitAsync();
        }
    }
}

