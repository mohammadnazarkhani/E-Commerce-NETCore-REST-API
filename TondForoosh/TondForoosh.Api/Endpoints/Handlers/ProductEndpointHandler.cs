using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TondForoosh.Api.Endpoints.Handlers
{
    public class ProductEndpointHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductEndpointHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all products
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return new OkObjectResult(products.Select(p => p.ToDto()));
        }

        // Get a specific product by ID
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return new NotFoundResult();

            return new OkObjectResult(product.ToDetailDto());
        }

        // Create a new product
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto, int sellerId)
        {
            var product = createProductDto.ToEntity();

            product.SellerProducts.Add(new SellerProduct
            {
                UserId = sellerId,
                Product = product
            });

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new CreatedResult($"/products/{product.Id}", product.ToDetailDto());
        }

        // Update an existing product
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductDto updateProductDto, int sellerId)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return new NotFoundResult();

            var isSeller = await _unitOfWork.SellerProductRepository.IsProductAssociatedWithSellerAsync(sellerId, id);
            if (!isSeller)
                return new StatusCodeResult(403); // Forbidden

            product.UpdateEntity(updateProductDto);
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return new OkObjectResult(product.ToDetailDto());
        }

        // Delete an existing product
        public async Task<IActionResult> DeleteProductAsync(int id, int sellerId)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return new NotFoundResult();

            var isSeller = await _unitOfWork.SellerProductRepository.IsProductAssociatedWithSellerAsync(sellerId, id);
            if (!isSeller)
                return new StatusCodeResult(403); // Forbidden

            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
