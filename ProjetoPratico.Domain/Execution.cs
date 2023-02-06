using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class Execution : ValueObject<Execution>
    {

        public Execution(string value)
        {
            Value = value;
        }

        public string Value { get;  }

        public static Result<Execution> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Result
                    .Failure<Execution>("Invalid Description");
            }
            if (value.Length > 200)
            {
                return Result
                    .Failure<Execution>("Too long description");
            }

            return Result
                .Success<Execution>(new Execution(value));
        }
    }
}
