using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Categories.Responses;

public record CategoryDto(
    int Id,
    string Name
);
