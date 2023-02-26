using API.Models;
using API.RestModel;

namespace API.Contracts
{
    public interface IInvoiceRepository : IRepositoryBase<Invoice>
    {
        int GetNextId();
        List<PostModel> GetAll();
    }
}
