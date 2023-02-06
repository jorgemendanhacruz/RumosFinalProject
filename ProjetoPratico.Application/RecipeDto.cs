using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Application
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public int CookingTime { get; set; }

        public int DifficultyLevelId { get; set; }

        public string Execution { get; set; }

        public int RecipeCategoryId { get; set; }

        public int UserId { get; set; }
    }
}
