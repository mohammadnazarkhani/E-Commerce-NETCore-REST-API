using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Application.Interfaces.Utility;

namespace Infrastructure.Utility.PathResolvers;

public class ContentRootPathResolver : IPathResolver
{
    private readonly IHostEnvironment _environment;

    public ContentRootPathResolver(IHostEnvironment environment)
    {
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    public string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path))
            return path;

        return Path.Combine(_environment.ContentRootPath, path);
    }
}
