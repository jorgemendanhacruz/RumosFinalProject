using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class RecipeCategoryDescription : ValueObject<RecipeCategoryDescription>
    {
        private RecipeCategoryDescription(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<RecipeCategoryDescription>Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.
                    Failure<RecipeCategoryDescription>("Invalid category");
            }
            if (value.Length > 12)
            {
                return Result.
                    Failure<RecipeCategoryDescription>("Too long text");
            }
            return Result
                .Success<RecipeCategoryDescription>(new RecipeCategoryDescription(value));
        }
    }
}
