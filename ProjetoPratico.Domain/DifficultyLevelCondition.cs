using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class DifficultyLevelCondition : ValueObject<DifficultyLevelCondition>
    {
        private DifficultyLevelCondition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Result<DifficultyLevelCondition> Create(int value)
        {
            if (value <= 0)
            {
                return Result
                   .Failure<DifficultyLevelCondition>("Invalid value");
            }
            if (value > 5)
            {
                return Result
                    .Failure<DifficultyLevelCondition>("Invalid value");
            }
            return Result
                .Success<DifficultyLevelCondition>(new DifficultyLevelCondition(value));
        }
    }
}
