using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
