using Microsoft.AspNetCore.Mvc;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using ProjetoPratico.Infraestructure.Data.DifficultyLevel.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoPratico.API.Controllers.DifficultyLevel
{
    [Route("api/v1/level/")]
    public class DifficultyLevelController : ControllerBase
    {
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly ICookUnitOfWork _cookUnitOfWork;
        public DifficultyLevelController(IDifficultyLevelRepository repository, ICookUnitOfWork cookUnitOfWork) 
        {
            _difficultyLevelRepository = repository;
            _cookUnitOfWork = cookUnitOfWork;
        }
        // GET: api/<DifficultyLevel>
        [HttpGet()]
        public async Task<IList<GetDifficultyModel>> Get()
        {
            var difficultyLevel = _difficultyLevelRepository
                .GetAll();

            if (difficultyLevel == null)
            {
                return null;
            }

            return difficultyLevel.Select(
                difficultyLevel => new GetDifficultyModel
                {
                    Id = difficultyLevel.Id,
                    Level = difficultyLevel.Level.Value
                }).ToList();
        }

        // GET api/<DifficultyLevel>/5
        [HttpGet("{id}")]
        public async Task <GetDifficultyByIdModel> Get(int id)
        {
            var difficultyLevel = await _difficultyLevelRepository
                .GetAsync(id);

            if (difficultyLevel == null)
            {
                return null;
            }
            return new GetDifficultyByIdModel
            {
                Id = difficultyLevel.Id,
                Level = difficultyLevel.Level.Value
            };
        }

        // POST api/<DifficultyLevel>
        [HttpPost()]
        public async Task Post([FromBody] int value)
        {
            var condition = ProjetoPratico.Domain.DifficultyLevelCondition.Create(value);
            var level = new ProjetoPratico.Domain.DifficultyLevel(condition.Value);
            _difficultyLevelRepository.Add(level);
            await _cookUnitOfWork.CommitAsync();
        }

        // PUT api/<DifficultyLevel>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] int value)
        {
            var level = await _difficultyLevelRepository.GetAsync(id);
            var condition = ProjetoPratico.Domain.DifficultyLevelCondition.Create(value);
            level.Edit(condition.Value);
            _difficultyLevelRepository.Modify(level);
            await _cookUnitOfWork.CommitAsync();
        }

        // DELETE api/<DifficultyLevel>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           
            var level = await _difficultyLevelRepository.GetAsync(id);
            _difficultyLevelRepository.Delete(level);
            await _cookUnitOfWork.CommitAsync();
        }
    }
}
