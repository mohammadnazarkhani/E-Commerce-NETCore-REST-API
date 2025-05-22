using System;

namespace Application.Interfaces.Utility;

/// <summary>
/// Defines a contract for resolving file paths based on different strategies.
/// </summary>
public interface IPathResolver
{
    /// <summary>
    /// Resolves the given path according to the implementation's strategy.
    /// </summary>
    /// <param name="path">The path to resolve.</param>
    /// <returns>The resolved path.</returns>
    string ResolvePath(string path);
}
