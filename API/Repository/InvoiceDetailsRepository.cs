using API.Contracts;
using API.DbContextFile;
using API.Models;

namespace API.Repository
{
    public class InvoiceDetailsRepository : RepositoryBase<InvoiceDetails>, IInvoiceDetailsRepository
    {
        private readonly InvoiceDBContext _context;
        public InvoiceDetailsRepository(InvoiceDBContext context) : base(context)
        {
            this._context = context;
        }
    }
}
