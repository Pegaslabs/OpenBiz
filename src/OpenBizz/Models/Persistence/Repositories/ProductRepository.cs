using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Query;
using Microsoft.Extensions.Logging;
using OpenBiz.Models.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models.Persistence.Repositories
{
    public class ProductRepository:DBRepository<Product>,IProductRepository
    {

        public ProductRepository(SCMSContext context, ILogger<DBRepository<Product>> logger)
            :base(context, logger)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            var products = _context.Products.
                Include(p => p.Category).ToList();

            return products;
        }
    }
}
