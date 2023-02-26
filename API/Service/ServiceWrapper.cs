using API.Contracts;

namespace API.Service
{
    public class ServiceWrapper : IServiceWrapper
    {

        private readonly IInvoiceService _InvoiceService;
        private readonly IInvoiceDetailsService _InvoiceDetailsService;
        private readonly IProductService _ProductService;
        private readonly IUnitOfWork _iUnitOfWork;

        public ServiceWrapper(IInvoiceService InvoiceService, IInvoiceDetailsService InvoiceDetailsService, IProductService ProductService, IUnitOfWork iUnitOfWork)
        {
            this._InvoiceService = InvoiceService;
            this._InvoiceDetailsService = InvoiceDetailsService;
            this._ProductService = ProductService;
            this._iUnitOfWork = iUnitOfWork;
        }




        public IInvoiceService InvoiceService { get { return _InvoiceService; } }
        public IInvoiceDetailsService InvoiceDetailsService
        {
            get
            {
                return _InvoiceDetailsService;
            }

        }
        public IProductService ProductService
        {

            get { return _ProductService; }

        }




    }
}
