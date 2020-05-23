using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(eshopContext dbContext)
        {
            DbContext = dbContext;
        }

        public eshopContext DbContext { get; }

        public async Task Commit()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
