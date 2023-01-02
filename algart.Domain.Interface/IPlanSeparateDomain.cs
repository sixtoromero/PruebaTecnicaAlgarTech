using algart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.Domain.Interface
{
    public interface IPlanSeparateDomain
    {
        Task<IEnumerable<PlanSeparate>> GetAllAsync();
    }
}
