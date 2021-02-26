using Business.Abstract;
using Core.Business;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CustomerManager : BusinessManagerBase<Customer>, ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal):base(customerDal)
        {
            _customerDal = customerDal;
        }
    }
}
