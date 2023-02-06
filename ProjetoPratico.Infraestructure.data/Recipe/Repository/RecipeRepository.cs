using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Domain.Core;
using ProjetoPratico.Infraestructure.data.Repository;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.Data.Recipe.Repository
{
    public class RecipeRepository
        : Repository<ProjetoPratico.Domain.Recipe>, IRecipeRepository
    {
        private readonly ICookUnitOfWork _unitOfWork;
        public RecipeRepository(ICookUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
