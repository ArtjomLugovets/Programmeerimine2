using System.IO;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class StoredFile
    {
        public string FileName { get; set; }
        public Stream Content { get; set; }
    }
}
