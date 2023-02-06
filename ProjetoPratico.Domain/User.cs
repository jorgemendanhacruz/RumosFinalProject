using ProjetoPratico.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class User : AggregateRoot
    {
        private User()//método criado devido ao bug SQL
        { 
        }
        
        public Name Name { get; }
        
        public UserLastName LastName { get; }

        public UserPass Pass { get; }

        public UserEmail Email { get; }

        public Recipe Recipes { get; }

        public User(Name name, UserLastName lastName, UserPass pass, UserEmail email)
        {
            Name = name;
            LastName = lastName;
            Pass = pass;
            Email = email;
        }
    }
}
