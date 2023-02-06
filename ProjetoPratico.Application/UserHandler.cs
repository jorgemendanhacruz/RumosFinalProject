using ProjetoPratico.Domain;
using ProjetoPratico.Infraestructure.data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Application
{
    public class UserHandler
    {
        private UserHandler()
        {
        }

        public void AddName(string value)
        {
            var name = Name.CreateName(value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(name);
            dbContext.SaveChanges();
        }

        public void AddLastName(string value)
        {
            var lastName = UserLastName.CreateName(value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(lastName);
            dbContext.SaveChanges();
        }

        public void AddEmail(string value)
        {
            var email = UserEmail.Add(value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(email);
            dbContext.SaveChanges();
        }

        public void AddPass(string value)
        {
            var pass = UserPass.Create(value);

            var dbContext = new CookUnitOfWork();
            dbContext.AddAsync(pass);
            dbContext.SaveChanges();
        }




    }
}
