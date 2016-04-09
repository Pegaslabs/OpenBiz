using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        new IEnumerable<Product> GetAll();
    }
}
