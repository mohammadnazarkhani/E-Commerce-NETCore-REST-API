using System;

namespace Infrastructure.Services.Interfaces;

public interface IFileService
{
    string CopyAndRenameFile(string sourceFilePath, string destinationPath, string newName);
}
