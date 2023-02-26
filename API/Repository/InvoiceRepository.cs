using API.Contracts;
using API.DbContextFile;
using API.Models;
using API.RestModel;

namespace API.Repository
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        private readonly InvoiceDBContext _context;
        public InvoiceRepository(InvoiceDBContext context) : base(context)
        {
            this._context = context;
        }

        public int GetNextId()
        {
            return this._context.Invoice.Max(x => x.Id);
        }

        public List<PostModel> GetAll()
        {
            var query = from invoice in this._context.Invoice
                        join invoiceDetails in this._context.InvoiceDetails
                        on invoice.Id equals invoiceDetails.ProductId
                        select new PostModel
                        {
                            Color = invoiceDetails.Color,
                            Detail = invoice.Detail,
                            ProductName = invoice.ProductName,
                            Quantity = invoiceDetails.Quantity,
                            Size = invoiceDetails.Size
                        };
            return query.ToList();
        }
    }
}
