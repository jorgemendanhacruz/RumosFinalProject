using CSharpFunctionalExtensions;
using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class Ingredient : AggregateRoot
    {
        public Ingredient() 
        { 
        }
        public Ingredient(IngredientDescription ingredient)
        {
            Ing = ingredient;
        }

        public IngredientDescription Ing { get; private set; }

        public void Edit(IngredientDescription ingredient)
        {
            Ing = ingredient;
        }

        
    }
}
