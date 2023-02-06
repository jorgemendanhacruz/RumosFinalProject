using ProjetoPratico.Domain;
using ProjetoPratico.Domain.Agregates;
using ProjetoPratico.Infraestructure.data.Repository;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Infraestructure.Data.RecipeCategory.Repository
{
    public class RecipeCategoryRepository
        : Repository<ProjetoPratico.Domain.RecipeCategory>, IRecipeCategoryRepository
    {
        private readonly ICookUnitOfWork _unitOfWork;
        public RecipeCategoryRepository(ICookUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
