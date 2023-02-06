using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;

namespace ProjetoPratico.Application
{
    public class RecipeCategoryHandler
    {
        public RecipeCategoryHandler()
        {

        }

        public void AddCategory(string categoryDescription)
        {

            var description = RecipeCategoryDescription.Create(categoryDescription);

            var category = new RecipeCategory(description.Value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(category);
            dbContext.SaveChanges();
        }
    }
}