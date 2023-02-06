using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class UserPass : ValueObject<UserPass>
    {
        private UserPass(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }


        public static Result<UserPass> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result
                    .Failure<UserPass>("Invalid password type");
            }
            if (value.Length < 8)
            {
                return Result
                    .Failure<UserPass>("Too short password");
            }
            return Result
                .Success<UserPass>(new UserPass(value));
        }



    }
}
