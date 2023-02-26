namespace API.Contracts
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailsRepository InvoiceDetailsRepository { get; }
    }
}
