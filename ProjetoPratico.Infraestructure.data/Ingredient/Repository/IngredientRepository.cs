using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPratico.Domain.Core;
using ProjetoPratico.Infraestructure.data.Repository;

namespace ProjetoPratico.Infraestructure.Data.Ingredient.Repository
{
    public class IngredientRepository
       : Repository<ProjetoPratico.Domain.Ingredient>, IIngredientRepository
    {
        private readonly ICookUnitOfWork _unitOfWork;
        public IngredientRepository(ICookUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }

}
