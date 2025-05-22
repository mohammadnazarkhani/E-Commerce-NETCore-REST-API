using System;
using Application.Interfaces.Services;
using Application.Interfaces.Utility;
using Infrastructure.Services;
using Infrastructure.Utility.PathResolvers;
using Moq;

namespace Infrastructure.Tests.Services;

public class FileServiceTests : IDisposable
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

    [Fact]
    public async Task CopyAndRenameFile_WithNonExistentSourceFile_ThrowsFileNotFoundException()
    {
        // Arrange
        var nonExistentPath = Path.Combine(_testDirectory, "nonexistent.txt");
        var destPath = Path.Combine(_testDirectory, "destination");

        // Setup resolver mocks
        _environmentResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _contentRootResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _configResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);

        // Act & Assert
        await Assert.ThrowsAsync<FileNotFoundException>(() =>
            _fileService.CopyAndRenameFile(nonExistentPath, destPath, "newfile.txt")
        );
    }

    [Fact]
    public async Task CopyAndRenameFile_PathResolutionUsesAllResolvers()
    {
        // Ararnge 
        var sourceFileName = "test.txt";
        var sourcePath = Path.Combine(_testDirectory, sourceFileName);
        var destPath = Path.Combine(_testDirectory, "destination");
        var newFileName = "renamed.txt";

        // Create source file
        await File.WriteAllTextAsync(sourcePath, "test content");

        // Setup resolvers to modify paths in sequence
        _environmentResolver.Setup(r => r.ResolvePath(It.IsAny<string>()))
            .Returns<string>(p => p + "_env");
        _configResolver.Setup(r => r.ResolvePath(It.IsAny<string>()))
            .Returns<string>(p => p.Replace("_env", "_config"));
        _contentRootResolver.Setup(r => r.ResolvePath(It.IsAny<string>()))
            .Returns<string>(p => p.Replace("_config", ""));

        // Act
        await _fileService.CopyAndRenameFile(sourcePath, destPath, newFileName);

        // Assert
        _environmentResolver.Verify(r => r.ResolvePath(It.IsAny<string>()), Times.Exactly(2));
        _configResolver.Verify(r => r.ResolvePath(It.IsAny<string>()), Times.Exactly(2));
        _contentRootResolver.Verify(r => r.ResolvePath(It.IsAny<string>()), Times.Exactly(2));
    }

    [Fact]
    public async Task CopyAndRenameFile_CreatesDestinationDirectory_WhenNotExists()
    {
        // Arrange
        var sourceFileName = "test.txt";
        var sourcePath = Path.Combine(_testDirectory, sourceFileName);
        var destPath = Path.Combine(_testDirectory, "nested", "destination");
        var newFileName = "renamed.txt";

        // Create source file
        await File.WriteAllTextAsync(sourcePath, "test contnet");

        // Setup resolver mocks

        _environmentResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _configResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);
        _contentRootResolver.Setup(r => r.ResolvePath(It.IsAny<string>())).Returns<string>(p => p);

        // Act
        await _fileService.CopyAndRenameFile(sourcePath, destPath, newFileName);

        // Assert
        Assert.True(Directory.Exists(destPath));
        Assert.True(File.Exists(Path.Combine(destPath, newFileName)));
    }

    public void Dispose()
    {
        // Cleanup test directory
        if (Directory.Exists(_testDirectory))
            Directory.Delete(_testDirectory, true);
    }
}
