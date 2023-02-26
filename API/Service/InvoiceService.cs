using API.Contracts;
using API.Models;
using API.RestModel;

namespace API.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public void AddInvoice(List<PostModel> models)
        {
            for (int i = 0; i < models.Count(); i++)
            {
                SaveInvoice(models[i]);
            }
        }
        public List<PostModel> GetAllInvoice()
        {
            List<PostModel> models = this._unitOfWork.InvoiceRepository.GetAll();
            var query = from row in models
                        group row by row.ProductName into intermid_data
                        select new PostModel
                       {
                            ProductName = intermid_data.Key,
                            Quantity = intermid_data.Sum(x => x.Quantity),
                            Color = intermid_data.FirstOrDefault().Color,
                            Size = intermid_data.First().Size
                        };
            return query.ToList();
        }
        private void SaveInvoice(PostModel model)
        {

            Invoice invoice = GetInvoice(model);
            this._unitOfWork.InvoiceRepository.Add(invoice);
            
            int invoiceId = this._unitOfWork.InvoiceRepository.GetNextId();
            InvoiceDetails invoiceDetails = GetInvoiceDetails(model);
            invoiceDetails.ProductId = invoiceId;
            this._unitOfWork.InvoiceDetailsRepository.Add(invoiceDetails);

        }

        private Invoice GetInvoice(PostModel model)
        {
            return new Invoice
            {
                Detail = model.Detail,
                ProductName = model.ProductName
            };
        }
        private InvoiceDetails GetInvoiceDetails(PostModel model)
        {
            return new InvoiceDetails
            {
                Color = model.Color,
                Quantity = model.Quantity,
                Size = model.Size
            };
        }

    }
}
