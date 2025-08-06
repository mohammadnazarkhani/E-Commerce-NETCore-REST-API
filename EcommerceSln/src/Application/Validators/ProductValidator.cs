using Domain.DTOs;
using FluentValidation;
using Application.Interfaces;
using Application.Specifications.ProductSpecifications;
using Application.Specifications.CategorySpecifications;

namespace Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private const decimal MaxPrice = 1000000M;

    public CreateProductValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters")
            .Must(BeValidProductName).WithMessage("Product name contains invalid characters")
            .MustAsync(BeUniqueProductName).WithMessage("Product name already exists");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Product description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
            .Must(description => description != null && 
                description.Split(' ').Length >= 5)
            .WithMessage("Description must contain at least 5 words");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(MaxPrice).WithMessage($"Price cannot exceed {MaxPrice:C}")
            .PrecisionScale(10, 2, false).WithMessage("Price cannot have more than 2 decimal places");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative")
            .Must(BeValidStockQuantity).WithMessage("Stock quantity must match availability");

        RuleFor(p => p.SKU)
            .NotEmpty().WithMessage("SKU is required")
            .Length(5, 20).WithMessage("SKU must be between 5 and 20 characters")
            .Matches(@"^[A-Za-z0-9-]+$").WithMessage("SKU can only contain letters, numbers, and hyphens")
            .MustAsync(BeUniqueSKU).WithMessage("SKU already exists");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category is required")
            .MustAsync(CategoryExists).WithMessage("Selected category does not exist");

        // Cross-field validation
        RuleFor(p => p)
            .Must(p => !p.Name.Contains(p.SKU))
            .WithMessage("Product name cannot contain the SKU");
    }

    private bool BeValidProductName(string name)
    {
        return name != null && 
               !name.Contains("  ") && // No double spaces
               !name.Any(c => char.IsControl(c)) && // No control characters
               name.Trim() == name; // No leading/trailing spaces
    }

    private async Task<bool> BeUniqueProductName(string name, CancellationToken cancellationToken)
    {
        var spec = new ProductByNameSpecification(name);
        return !await _unitOfWork.Products.AnyAsync(spec, cancellationToken);
    }

    private bool BeValidStockQuantity(int quantity)
    {
        // Stock must be > 0 for valid products
        return quantity > 0;
    }

    private async Task<bool> BeUniqueSKU(string sku, CancellationToken cancellationToken)
    {
        return !await _unitOfWork.Products.IsSkuUniqueAsync(sku, cancellationToken);
    }

    private async Task<bool> CategoryExists(Guid categoryId, CancellationToken cancellationToken)
    {
        var spec = new CategoryByIdSpecification(categoryId);
        return await _unitOfWork.Categories.AnyAsync(spec, cancellationToken);
    }
}

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private const decimal MaxPrice = 1000000M;

    public UpdateProductValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters")
            .Must(BeValidProductName).WithMessage("Product name contains invalid characters")
            .MustAsync(BeUniqueProductName).WithMessage("Product name already exists");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Product description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
            .Must(description => description != null && 
                description.Split(' ').Length >= 5)
            .WithMessage("Description must contain at least 5 words");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(MaxPrice).WithMessage($"Price cannot exceed {MaxPrice:C}")
            .PrecisionScale(10, 2, false).WithMessage("Price cannot have more than 2 decimal places");

        RuleFor(p => p.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative")
            .Must(BeValidStockQuantity).WithMessage("Stock quantity must match availability");

        RuleFor(p => p.SKU)
            .NotEmpty().WithMessage("SKU is required")
            .Length(5, 20).WithMessage("SKU must be between 5 and 20 characters")
            .Matches(@"^[A-Za-z0-9-]+$").WithMessage("SKU can only contain letters, numbers, and hyphens")
            .MustAsync(BeUniqueSKU).WithMessage("SKU already exists");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category is required")
            .MustAsync(CategoryExists).WithMessage("Selected category does not exist");

        // Cross-field validation
        RuleFor(p => p)
            .Must(p => !p.Name.Contains(p.SKU))
            .WithMessage("Product name cannot contain the SKU")
            .MustAsync(async (request, _, cancellationToken) => 
                await BeValidPriceChange(request.Price, cancellationToken))
            .WithMessage("Price cannot be reduced by more than 50% from the current price");
    }

    private bool BeValidProductName(string name)
    {
        return name != null && 
               !name.Contains("  ") && // No double spaces
               !name.Any(c => char.IsControl(c)) && // No control characters
               name.Trim() == name; // No leading/trailing spaces
    }

    private async Task<bool> BeUniqueProductName(string name, CancellationToken cancellationToken)
    {
        var spec = new ProductByNameSpecification(name);
        return !await _unitOfWork.Products.AnyAsync(spec, cancellationToken);
    }

    private bool BeValidStockQuantity(UpdateProductRequest request, int quantity)
    {
        // If product is available, stock must be > 0
        return !request.IsAvailable || quantity > 0;
    }

    private async Task<bool> BeUniqueSKU(string sku, CancellationToken cancellationToken)
    {
        return !await _unitOfWork.Products.IsSkuUniqueAsync(sku, cancellationToken);
    }

    private async Task<bool> CategoryExists(Guid categoryId, CancellationToken cancellationToken)
    {
        var spec = new CategoryByIdSpecification(categoryId);
        return await _unitOfWork.Categories.AnyAsync(spec, cancellationToken);
    }

    private decimal? _originalPrice;

    public void SetOriginalPrice(decimal price)
    {
        _originalPrice = price;
    }

    private Task<bool> BeValidPriceChange(decimal newPrice, CancellationToken cancellationToken)
    {
        if (!_originalPrice.HasValue) 
            return Task.FromResult(true);

        var priceReduction = (_originalPrice.Value - newPrice) / _originalPrice.Value;
        return Task.FromResult(priceReduction <= 0.5m); // Max 50% reduction
    }
}
