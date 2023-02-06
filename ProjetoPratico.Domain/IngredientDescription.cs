using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class IngredientDescription
    {
        private IngredientDescription()
        {

        }
        private IngredientDescription(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<IngredientDescription> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.
                    Failure<IngredientDescription>("Invalid ingredient");
            }
            if (value.Length > 12)
            {
                return Result.
                    Failure<IngredientDescription>("Too long text");
            }
            return Result
                .Success<IngredientDescription>(new IngredientDescription(value));
        }

    }

}
