using System;
using Core.Entities.Base;

namespace Core.Entities;

/// <summary>
/// Represents an Image entity in the system, extending the base file entity with image-specific properties
/// </summary>
public class ProductImage : BaseFileEntity
{
    /// <summary>
    /// Url path to the thumbnail version of the image
    /// </summary>
    public string? ThumbnailUrl { get; set; }
}
