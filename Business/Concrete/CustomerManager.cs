using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager<Dal> : BusinessManagerBase<Customer, Dal>, ICustomerService
        where Dal : class, IEntityRepository<Customer>, new()
    {
    }
}
