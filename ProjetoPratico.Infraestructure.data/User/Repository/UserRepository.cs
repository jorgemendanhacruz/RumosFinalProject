using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.Repository;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.Data.User.Repository
{
    public class UserRepository
       : Repository<ProjetoPratico.Domain.User>, IUserRepository
    {
        private readonly ICookUnitOfWork _unitOfWork;
        public UserRepository(ICookUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
