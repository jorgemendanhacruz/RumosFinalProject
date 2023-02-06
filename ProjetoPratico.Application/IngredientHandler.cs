using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Application
{
    public class IngredientHandler
    {
        public IngredientHandler()
        {

        }

        public void AddIngredient(string ingredientDescription)
        {
            //instanciar construtor IngredientDescription para verificar validade da informação
            var description = IngredientDescription.Create(ingredientDescription);

            //instanciar construtor Ingredient para adicionar informação válida
            var ingredient = new Ingredient(description.Value);

            //guadar no banco de dados
            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(ingredient);
            dbContext.SaveChanges();

        }
    }
}
