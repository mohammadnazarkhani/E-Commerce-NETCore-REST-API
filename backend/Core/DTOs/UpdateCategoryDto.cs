using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UpdateCategoryDto
{
    [Required]
    public int Id { get; set; }
    public string? Name { get; set; }
}
