using API.Contracts;
using API.DbContextFile;
using API.Models;

namespace API.Repository
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        private readonly InvoiceDBContext _context;
        public ProductRepository(InvoiceDBContext context) : base(context)
        {
            this._context = context;
        }
    }
}
