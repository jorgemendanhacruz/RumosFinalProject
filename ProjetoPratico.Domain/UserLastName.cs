using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class UserLastName : ValueObject<UserLastName>
    {
        private UserLastName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<UserLastName> CreateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result
                    .Failure<UserLastName>("Invalid name");
            }
            return Result
                .Success<UserLastName>(new UserLastName(value));
        }
    }
}
