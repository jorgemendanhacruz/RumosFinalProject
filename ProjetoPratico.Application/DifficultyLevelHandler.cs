using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Application
{
    public class DifficultyLevelHandler
    {
        public DifficultyLevelHandler()
        {

        }

        public void AddDifficultyLevel(int value)
        {
            var level = DifficultyLevelCondition.Create(value);

            var difficultyLevel = new DifficultyLevel(level.Value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(difficultyLevel);
            dbContext.SaveChanges();
        }
    }
}
