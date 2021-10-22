using DataAcces.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete
{
   public  class CustomerDal:IRepositoryBase<Customer,WebContext>,IRepository<Customer>
    {
    }
}
