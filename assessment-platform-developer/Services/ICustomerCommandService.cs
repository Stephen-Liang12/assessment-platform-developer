using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_platform_developer.Services
{
    internal interface ICustomerCommandService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }

    public class CustomerCommandService : ICustomerCommandService
    {
        private ICustomerCommandRepository customerCommandRepository;

        public CustomerCommandService(ICustomerCommandRepository customerCommandRepository)
        {
            this.customerCommandRepository = customerCommandRepository;
        }   

        public void AddCustomer(Customer customer)
        {
            customerCommandRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customerCommandRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            customerCommandRepository.Delete(id);
        }
    }
}
