using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.UnitOfWork;

namespace ProjetoPratico.API.Controllers.User
{

    [Route("api/v1/user/")]

    public class UserController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICookUnitOfWork _cookUnitOfWork;

        public UserController(
           IRecipeRepository recipeRepository,
           IUserRepository userRepository,
           ICookUnitOfWork cookUnitOfWork)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _cookUnitOfWork = cookUnitOfWork;
        }
        // GET: UserController
        [HttpGet()]
        public async Task<IList<GetUserModel>> Get()
        {
            var user = _userRepository
                .GetAll();

            return user.Select(
                user => new GetUserModel
                {
                    Id = user.Id,
                    UserName = user.Name.Value,
                    LastName = user.LastName.Value,
                    Email = user.Email.Value,
                    Pass = user.Pass.Value,

                }).ToList();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public async Task<GetUserByIdModel> Get(int id)
        {
            var user = await _userRepository
                .GetAsync(id);

            return new GetUserByIdModel
            {
                Id = user.Id,
                UserName = user.Name.Value,
                LastName = user.LastName.Value,
                Email = user.Email.Value,
                Pass = user.Pass.Value,
            };
        }

        // POST api/<User>
        [HttpPost]
        public async Task Post([FromBody] PostUserModel post)
        {

            

            var userName = ProjetoPratico.Domain.Name.CreateName(post.UserName);

            var lastName = ProjetoPratico.Domain.UserLastName.CreateName(post.LastName);

            var email = ProjetoPratico.Domain.UserEmail.Add(post.Email);

            var pass = ProjetoPratico.Domain.UserPass.Create(post.Pass);

            var user = new ProjetoPratico.Domain.User(
                name: userName.Value,
                lastName: lastName.Value,
                pass: pass.Value,
                email: email.Value
                );

            _userRepository.Modify(user);

            await _cookUnitOfWork.CommitAsync();

        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PostUserModel post)
        {
            var user = await _userRepository.GetAsync(id);

            if (user != null)
            {

                var userName = ProjetoPratico.Domain.Name.CreateName(post.UserName);

                var lastName = ProjetoPratico.Domain.UserLastName.CreateName(post.LastName);

                var email = ProjetoPratico.Domain.UserEmail.Add(post.Email);

                var pass = ProjetoPratico.Domain.UserPass.Create(post.Pass);


                user = new ProjetoPratico.Domain.User(
                name: userName.Value,
                lastName: lastName.Value,
                pass: pass.Value,
                email: email.Value
                );

                _userRepository.Modify(user);

                await _cookUnitOfWork.CommitAsync();
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var user = await _userRepository.GetAsync(id);

            if (user != null)
            {
                _userRepository.Delete(user);

            }
        }
    }
}
