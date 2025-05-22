using System;
using System.IO;
using System.Security;
using Application.Interfaces.Utility;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utility.PathResolvers;

/// <summary>
/// Resolves paths by combining them with a base path from configuration if available.
/// </summary>
public class ConfigurationPathResolver : IPathResolver
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationPathResolver"/> class.
    /// </summary>
    /// <param name="configuration">The configuration used to get the base file path.</param>
    public ConfigurationPathResolver(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Resolves a path by combining it with the configured base path if available.
    /// </summary>
    /// <param name="path">The path to resolve.</param>
    /// <returns>
    /// The absolute path if already rooted; otherwise, the path combined with the configured base path
    /// or the original path if no base path is configured.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when path is null.</exception>
    /// <exception cref="ArgumentException">Thrown when path is empty or contains invalid characters.</exception>
    public string ResolvePath(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be empty or whitespace.", nameof(path));

        // Remove any directory traversal attempts
        path = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        if (Path.IsPathRooted(path))
            return path;

        string? baseFilePath = _configuration["FileService:BasePath"];
        if (string.IsNullOrEmpty(baseFilePath))
            return path;

        // Ensure base path is also fully qualified and clean
        baseFilePath = Path.GetFullPath(baseFilePath);
        string resolvedPath = Path.GetFullPath(Path.Combine(baseFilePath, path));

        // Verify the resolved path is still under the base path
        if (!resolvedPath.StartsWith(baseFilePath, StringComparison.OrdinalIgnoreCase))
            throw new SecurityException("Access to path outside of base directory is not allowed.");

        return resolvedPath;
    }
}
