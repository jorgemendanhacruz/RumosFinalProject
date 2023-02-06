using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class CookingTime : ValueObject<CookingTime>
    {
   
        public CookingTime(int value)
        { 
           Value = value;
        }

        public int Value { get; }

        public static Result<CookingTime> Add(int value)
        {
            if (value < 0)
            {
                return Result
                    .Failure<CookingTime>("Invalid value");
            }
            if (value > 240)
            {
                return Result
                    .Failure<CookingTime>("Too long value");
            }
            return Result
                .Success<CookingTime>(new CookingTime(value));
        }





    }
}
