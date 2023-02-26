using API.Contracts;
using API.Models;
using API.RestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceWrapper _services;
        public InvoiceController(IUnitOfWork _unitOfWork, IServiceWrapper _services)
        {
            this._unitOfWork = _unitOfWork;
            this._services = _services;
        }





        [HttpPost(Name = "PostInvoice")]
        [Route("postInvoice")]
        public void PostInvoice(List<PostModel> model)
        {
            this._services.InvoiceService.AddInvoice(model);
        }
        [HttpPost(Name = "GetAllInvoice")]
        [Route("getAllInvoice")]
        public List<PostModel> GetAllInvoice()
        {
            return this._services.InvoiceService.GetAllInvoice();
        }

      
        
        [HttpGet(Name = "GetAllProduct")]
        [Route("getAllProduct")]
        public List<Product> GetAllProduct()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product { Id = 1,Name = "Shari"});
            list.Add(new Product { Id = 2, Name = "Tie" });
            list.Add(new Product { Id = 3, Name = "Shirt" });
            list.Add(new Product { Id = 4, Name = "T-Shirt" });
            list.Add(new Product { Id = 5, Name = "Jeans Pant" });
            list.Add(new Product { Id = 6, Name = "Polo Shirt" });

            list.Add(new Product { Id = 7, Name = "Lungi" });
            list.Add(new Product { Id = 8, Name = "Tupi" });
            list.Add(new Product { Id = 9, Name = "Gavardin Pant" });
            list.Add(new Product { Id = 10, Name = "Cap" });
            list.Add(new Product { Id = 11, Name = "Hat" });
            list.Add(new Product { Id = 12, Name = "Salwar kamiz" });
            return list;
        }


    }
}
