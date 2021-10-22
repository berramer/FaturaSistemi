using DataAcces.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete
{
    public class SystemUserDal:IRepositoryBase<SystemUser,WebContext>,IRepository<SystemUser>
    {
    }
}
