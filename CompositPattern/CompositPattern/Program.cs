using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositPattern
{
    class GetFiles
    {
        public List<string> FileTree { get; private set; }
        public List<string> ErrorLogs { get; private set; }

        public void Get(string path)
        {
            ErrorLogs = new List<string>();
            FileTree = new List<string>();
            FileTree.Add(path);
            Scan(path, 1);
        }

        private void Scan(string path, int depth)
        {
            try
            {
                var dirInfo = new DirectoryInfo(path);
                var directories = dirInfo.GetDirectories();
                if (directories != null)
                {
                    foreach (var item in directories)
                    {
                        FileTree.Add(new String('.', depth) + item.Name);
                        Scan(item.FullName, depth + 1);
                    }
                }
                var files = dirInfo.GetFiles();
                if (files != null)
                    foreach (var file in files)
                    {
                        FileTree.Add(new String('-', depth) + file.Name);
                    }
            }
            catch (Exception e)
            {
                ErrorLogs.Add(e.Message);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var Files = new GetFiles();

            Files.Get(@"C:\CMS");
            foreach (var item in Files.FileTree)
            {
                Console.WriteLine(item);
            }
        }
    }
}
