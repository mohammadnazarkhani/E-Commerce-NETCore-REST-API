using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.Category
{
    public record class CreateCategoryDto(
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        string Title);
}
