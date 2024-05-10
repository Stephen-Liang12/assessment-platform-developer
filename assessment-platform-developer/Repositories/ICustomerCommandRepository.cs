using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerCommandRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
