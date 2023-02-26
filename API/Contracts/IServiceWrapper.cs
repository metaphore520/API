namespace API.Contracts
{
    public interface IServiceWrapper
    {
        IInvoiceService InvoiceService { get; }
        IInvoiceDetailsService InvoiceDetailsService { get; }
        IProductService ProductService { get; }

    }
}
