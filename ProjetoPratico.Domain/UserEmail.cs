using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class UserEmail : ValueObject<UserEmail>
    {
        private UserEmail(string email)
        {
            Value = email;
        }

        public string Value { get; }

        public static Result<UserEmail> Add(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result
                    .Failure<UserEmail>("Invalid email");
            }
            if (!email.Contains("@"))
            {
                return Result
                    .Failure<UserEmail>("Invalid email");
            }
            if (!email.Contains("."))
            {
                return Result
                    .Failure<UserEmail>("Invalid email");
            }
            return Result
                .Success<UserEmail>(new UserEmail(email));
        }
    }
}
