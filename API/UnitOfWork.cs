using API.Contracts;
using API.DbContextFile;

namespace API
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProductRepository _productRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;

        private readonly InvoiceDBContext _context;
        public UnitOfWork(IProductRepository _productRepository, IInvoiceRepository _invoiceRepository, IInvoiceDetailsRepository _invoiceDetailsRepository, InvoiceDBContext context)
        {
            this._invoiceRepository = _invoiceRepository;
            this._productRepository = _productRepository;
            this._invoiceDetailsRepository = _invoiceDetailsRepository;
            this._context = context;
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                return _invoiceRepository;
            }
        }
        public IInvoiceDetailsRepository InvoiceDetailsRepository
        {
            get
            {
                return _invoiceDetailsRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }






    }
}
