using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class DifficultyLevel : AggregateRoot
    {
        private DifficultyLevel() 
        {
        }
        public DifficultyLevel(DifficultyLevelCondition value)
        {
            Level = value;
        }

        public DifficultyLevelCondition Level { get; private set; }

        public void Edit(DifficultyLevelCondition value)
        {
            Level = value;
        }

    }
}
