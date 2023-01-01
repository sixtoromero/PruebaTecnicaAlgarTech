﻿using algart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algart.InfraStructure.Interface
{
    public interface ISalesDepartmentRepository
    {
        Task<IEnumerable<SalesDepartment>> GetAllAsync();
    }
}
