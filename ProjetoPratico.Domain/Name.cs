using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class Name : ValueObject<Name>
    {
        private Name(string value)
        {
            
            Value = value;
        }

        public string Value { get; }

        public static Result<Name>CreateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result
                    .Failure<Name>("Invalid name");
            }
            return Result
                .Success<Name>(new Name(value));
        }
    }
}
