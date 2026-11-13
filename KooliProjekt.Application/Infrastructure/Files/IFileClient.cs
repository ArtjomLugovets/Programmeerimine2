using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public interface IFileClient
    {
        Task Save(string filename, string fileStore, int carId, Stream inputStream);
        Task Delete(string fileStore, int carId);
        Task<StoredFile> Get(string fileStore, int carId);
        Task<IReadOnlyList<StoredFileInfo>> List(string fileStore);
    }
}
