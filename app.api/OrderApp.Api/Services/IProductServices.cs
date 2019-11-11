using OrderApp.Api.ViewModel;
using System.Collections.Generic;

namespace OrderApp.Api.Services
{
    public interface IProductServices
    {
        List<ProductViewModel> GetProducts();
    }
}
