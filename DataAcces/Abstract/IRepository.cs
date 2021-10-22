using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Abstract
{
   public  interface IRepository<Tentity>
    {
         public void Add(Tentity tentity);
          public void Delete(Tentity tentity);
          public void Update(Tentity tentity);

        public List<Tentity> getAll(Expression<Func<Tentity,bool>> filter=null);

    }
}
