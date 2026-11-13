using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;

        public LocalFileClient(string filesRoot)
        {
            _filesRoot = filesRoot;
            Directory.CreateDirectory(_filesRoot);
        }

        public async Task Save(string filename, string fileStore, int carId, Stream inputStream)
        {
            var folderPath = Path.Combine(_filesRoot, fileStore, carId.ToString());
            var filePath = Path.Combine(folderPath, filename);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await inputStream.CopyToAsync(fileStream);
                    }

        public Task Delete(string fileStore, int carId)
        {
            var folderPath = Path.Combine(_filesRoot, fileStore, carId.ToString());
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, recursive: true);
            }

            return Task.CompletedTask;
        }

        public Task<StoredFile> Get(string fileStore, int carId)
        {
            var folderPath = Path.Combine(_filesRoot, fileStore, carId.ToString());
            var filePath = Directory.Exists(folderPath)
                ? Directory.GetFiles(folderPath).FirstOrDefault()
                : null;
            StoredFile storedFile = filePath == null
                ? null
                : new StoredFile
                {
                    FileName = Path.GetFileName(filePath),
                    Content = File.OpenRead(filePath)
                };

            return Task.FromResult(storedFile);
        }

        public Task<IReadOnlyList<StoredFileInfo>> List(string fileStore)
        {
            var storePath = Path.Combine(_filesRoot, fileStore);
            var files = new List<StoredFileInfo>();

            if (Directory.Exists(storePath))
            {
                foreach (var carFolder in Directory.GetDirectories(storePath))
                {
                    if (!int.TryParse(Path.GetFileName(carFolder), out var carId))
                    {
                        continue;
                    }

                    foreach (var filePath in Directory.GetFiles(carFolder))
                    {
                        files.Add(new StoredFileInfo
                        {
                            CarId = carId,
                            FileName = Path.GetFileName(filePath)
                        });
                    }
                }
            }

            return Task.FromResult<IReadOnlyList<StoredFileInfo>>(files);
        }
    }
}
