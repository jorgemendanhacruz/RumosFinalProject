using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class RecipeCategory : AggregateRoot
    {
        public RecipeCategory(RecipeCategoryDescription category)
        {
            Category = category;
        }

        public RecipeCategoryDescription Category { get; private set; }

        public void Edit(RecipeCategoryDescription category)
        {
            Category = category;
        }
    }
}
