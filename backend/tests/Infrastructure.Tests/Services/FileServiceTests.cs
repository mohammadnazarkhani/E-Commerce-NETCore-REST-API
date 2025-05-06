using System;
using Application.Interfaces.Services;
using Application.Interfaces.Utility;
using Infrastructure.Services;
using Moq;

namespace Infrastructure.Tests.Services;

public class FileServiceTests
{
    private readonly string _testDirectory;
    private readonly Mock<IPathResolver> _environmentResolver;
    private readonly Mock<IPathResolver> _configResolver;
    private readonly Mock<IPathResolver> _contentRootResolver;
    private readonly IFileService _fileService;

    public FileServiceTests()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), "FileServiceTests", Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDirectory);

        // Setup mocks
        _environmentResolver = new Mock<IPathResolver>();
        _configResolver = new Mock<IPathResolver>();
        _contentRootResolver = new Mock<IPathResolver>();

        // Create file service with mocked resolvers
        var resolvers = new List<IPathResolver>
            {
                _environmentResolver.Object,
                _configResolver.Object,
                _contentRootResolver.Object
            };

        _fileService = new FileService(resolvers);
    }

}
