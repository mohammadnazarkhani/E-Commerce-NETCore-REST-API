using System;

namespace Application.Interfaces.Services;

public interface IFileService
{
    string CopyAndRenameFile(string sourceFilePath, string destinationPath, string newName);
}