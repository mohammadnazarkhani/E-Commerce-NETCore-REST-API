using System;

namespace Application.Interfaces.Services;

/// <summary>
/// Provides file oprations with path resolution capabilities.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Copies a file to a new location with a new name, resolving both source and destination paths.
    /// </summary>
    /// <param name="sourcePath">The path to the source file.</param>
    /// <param name="destPath">The destination directory path.</param>
    /// <param name="newName">The new name for the copied file.</param>
    /// <returns>A task representing the asynchronous copy operation.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the source file does not exist.</exception>
    Task CopyAndRenameFile(string sourceFilePath, string destPath, string newName);
}