using AutoMapper;
using eCommerce.Application.DTOs;
using eCommerce.Application.DTOs.Product;
using eCommerce.Application.Services.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Interfaces;

namespace eCommerce.Application.Services
{
    public class ProductService(IGeneric<Product> _product, IMapper _mapper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedData = _mapper.Map<Product>(product);
            int result = await _product.AddAsync(mappedData);
            return result > 0 ?
                new ServiceResponse(true, "Product Added") :
                new ServiceResponse(false, "Product can't be Added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await _product.DeleteAsync(id);
            return result > 0 ?
                new ServiceResponse(true, "Product Deleted") :
                new ServiceResponse(false, "Product can't be deleted");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var rawData = await _product.GetAllAsync();
            if (!rawData.Any()) return [];

            return _mapper.Map<IEnumerable<GetProduct>>(rawData);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var rawData = await _product.GetByIdAsync(id);
            if (rawData == null) return new GetProduct();

            return _mapper.Map<GetProduct>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = _mapper.Map<Product>(product);
            int result = await _product.UpdateAsync(mappedData);
            return result > 0 ?
                new ServiceResponse(true, "Product updated") :
                new ServiceResponse(false, "Product can't be updated");
        }
    }
}
