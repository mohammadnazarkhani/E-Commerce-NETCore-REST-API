using System;
using Application.Interfaces.Services;
using Application.Interfaces.Utility;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IEnumerable<IPathResolver> _pathResolvers;

    public FileService(IEnumerable<IPathResolver> pathResolvers)
    {
        _pathResolvers = pathResolvers;
    }

    private string ResolvePath(string path)
    {
        string resolvedPath = path;
        foreach (var resolver in _pathResolvers)
        {
            resolvedPath = resolver.ResolvePath(resolvedPath);
        }
        return resolvedPath;
    }

    public async Task CopyAndRenameFile(string sourceFilePath, string destPath, string newName)
    {
        // Resolve both paths using configured resolvers
        sourceFilePath = ResolvePath(sourceFilePath);
        destPath = ResolvePath(destPath);

        // Ensure source file exists
        if (!File.Exists(sourceFilePath))
            throw new FileNotFoundException("Source file not found", sourceFilePath);

        // Create destindation directory if it doesn't exist
        Directory.CreateDirectory(destPath);

        // combine destination path with new filename
        string newFilePath = Path.Combine(destPath, newName);

        // Copy file asynchronously
        using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var destinationStream = new FileStream(newFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            await sourceStream.CopyToAsync(destinationStream);
        }
    }
}
