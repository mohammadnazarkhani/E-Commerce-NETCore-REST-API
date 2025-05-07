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

    [Fact]
    public async Task CopyAndRenameFile_WithValidPaths_CopiesFileSuccessfully()
    {
        // Arrange
        var sourceFileName = "test.txt";
        var sourcePath = Path.Combine(_testDirectory, sourceFileName);
        var destPath = Path.Combine(_testDirectory, "destination");
        var newFileName = "renamed.txt";

        // Create source file
        await File.WriteAllTextAsync(sourcePath, "test content");

        // Setup resolver mocks to return the actual paths
        _environmentResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _contentRootResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _configResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);

        // Act
        await _fileService.CopyAndRenameFile(sourcePath, destPath, newFileName);

        // Assert
        var destinationFilePath = Path.Combine(destPath, newFileName);
        Assert.True(File.Exists(destinationFilePath));
        Assert.Equal(
            await File.ReadAllTextAsync(sourcePath),
            await File.ReadAllTextAsync(destinationFilePath)
        );
    }
}
