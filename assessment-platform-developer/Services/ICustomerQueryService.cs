using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_platform_developer.Services
{
    internal interface ICustomerQueryService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
    }

    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerQueryRepository customerQueryRepository;

        public CustomerQueryService(ICustomerQueryRepository customerRepository)
        {
            this.customerQueryRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerQueryRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return customerQueryRepository.Get(id);
        }
    }
}
