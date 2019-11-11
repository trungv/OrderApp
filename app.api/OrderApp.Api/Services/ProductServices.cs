using System.Collections.Generic;
using AutoMapper;
using OrderApp.Api.ViewModel;
using OrderApp.Core.Entities;
using OrderApp.Core.Repositories;

namespace OrderApp.Api.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IBaseRepository<Product> productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

            var productList = _productRepository.GetAll;
            productViewModelList = _mapper.Map<List<ProductViewModel>>(productList);

            return productViewModelList;
        }
    }
}
