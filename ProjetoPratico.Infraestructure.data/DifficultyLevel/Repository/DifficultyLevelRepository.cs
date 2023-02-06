using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Domain.Core;
using ProjetoPratico.Infraestructure.data.Repository;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.Data.DifficultyLevel.Repository
{
    public class DifficultyLevelRepository
        : Repository<ProjetoPratico.Domain.DifficultyLevel>, IDifficultyLevelRepository
    {
        private readonly ICookUnitOfWork _unitOfWork;
        public DifficultyLevelRepository(ICookUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
