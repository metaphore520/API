using API.RestModel;

namespace API.Contracts
{
    public interface IInvoiceService
    {
        void AddInvoice(List<PostModel> models);
        List<PostModel> GetAllInvoice();
    }
}
