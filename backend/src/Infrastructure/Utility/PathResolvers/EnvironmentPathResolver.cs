using System;
using Application.Interfaces.Utility;

namespace Infrastructure.Utility.PathResolvers;

public class EnvironmentPathResolver : IPathResolver
{
    public string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path) && !path.StartsWith("%"))
            return path;

        return Environment.ExpandEnvironmentVariables(path);
    }
}
