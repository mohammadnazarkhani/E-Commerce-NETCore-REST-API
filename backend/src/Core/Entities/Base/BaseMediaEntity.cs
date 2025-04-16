using System;

namespace Core.Entities.Base;

public class BaseMediaEntity : BaseFileEntity
{
    /// <summary>
    /// Url path to the thumbnail version of the image
    /// </summary>
    public string? ThumbnailUrl { get; set; }
}
