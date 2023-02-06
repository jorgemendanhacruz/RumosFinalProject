using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPratico.Domain
{
    public class ValueObject<TValueObject> 
        where TValueObject : ValueObject<TValueObject>
    {

    }
}

