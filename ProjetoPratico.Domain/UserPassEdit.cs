using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class UserPassEdit
    {
        private UserPassEdit()
        {
     
        }
        
        public UserPass Value { get; private set; }

        public void Edit(UserPass pass)
        {
            Value = pass;
        }

        
    }

}
