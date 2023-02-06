using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPratico.API.Controllers.Ingredient;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.UnitOfWork;

namespace ProjetoPratico.API.Controllers.RecipeCategory
{
    [Route("api/v1/category/")]
    public class RecipeCategoryController : Controller
    {
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;
        private readonly ICookUnitOfWork _cookUnitOfWork;
        public RecipeCategoryController(IRecipeCategoryRepository repository, ICookUnitOfWork cookUnitOfWork)
        {
            _recipeCategoryRepository = repository;
            _cookUnitOfWork = cookUnitOfWork;
        }
        // GET: api/<RecipeCategory>
        [HttpGet()]
        public async Task<IList<GetRecipeCategoryModel>> Get()
        {
            var category = _recipeCategoryRepository
                .GetAll();

            if (category == null)
            {
                return null;
            }

            return category.Select(
                category => new GetRecipeCategoryModel
                {
                    Id = category.Id,
                    Category = category.Category.Value
                }).ToList();
        }

        // GET api/<RecipeCategory>/5
        [HttpGet("{id}")]
        public async Task<GetRecipeCategoryByIdModel> Get(int id)
        {
            var category = await _recipeCategoryRepository
                .GetAsync(id);

            if (category == null)
            {
                return null;
            }
            return new GetRecipeCategoryByIdModel
            {
                Id = category.Id,
                Category = category.Category.Value
            };
        }

        // POST api/<RecipeCategory>
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var description = ProjetoPratico.Domain.RecipeCategoryDescription.Create(value);
            var category = new ProjetoPratico.Domain.RecipeCategory(description.Value);
            _recipeCategoryRepository.Add(category);
            await _cookUnitOfWork.CommitAsync();
        }

        // PUT api/<RecipeCategory>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
            var category = await _recipeCategoryRepository.GetAsync(id);
            _recipeCategoryRepository.Modify(category);
            await _cookUnitOfWork.CommitAsync();
        }

        // DELETE api/<RecipeCategory>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {

            var category = await _recipeCategoryRepository.GetAsync(id);
            _recipeCategoryRepository.Delete(category);
            await _cookUnitOfWork.CommitAsync();
        }
    }
}
