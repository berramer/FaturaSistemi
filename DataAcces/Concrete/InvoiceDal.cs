using DataAcces.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete
{
  public   class InvoiceDal:IRepositoryBase<Invoice,WebContext>,IRepository<Invoice>
    {
    }
}
