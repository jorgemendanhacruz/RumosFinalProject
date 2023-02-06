using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class IngredientRecipe : AggregateRoot
    {

        public IngredientRecipe()
        {
        }
        public IngredientRecipe(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
        public Ingredient Ingredient { get; }

        public int Quantity { get; }
    }
}
