using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.File
{
    public class FileRepositoryFactory : RepositoryFactory
    {
        private FileRepositoryFactory() { }

        public static FileRepositoryFactory Instance { get; } = new FileRepositoryFactory();

        public override FileRepository GetFileRepository(string type) => FileRepository.GetInstance(type);
    }
}
