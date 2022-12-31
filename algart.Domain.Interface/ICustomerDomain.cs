using algart.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace algart.Domain.Interface
{
    public interface ICustomerDomain
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
