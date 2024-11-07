using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos
{
    public record class UpdateCategoryDto(
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        string Title);
}
