using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositPattern
{
    abstract class Component
    {
        protected string Path;

        // Constructor
        public Component(string path)
        {
            Path = path;
        }
        public virtual void Add(string path) { Console.WriteLine("Cannot add to the file!"); }
        public virtual void Add(Component c) { Console.WriteLine("Cannot add to the file!"); }
        public virtual void Remove(Component c) { Console.WriteLine("Cannot delete from the file!"); }
        public abstract void Display(int depth);
    }

    class MyFolder : Component
    {
        private List<Component> Child { get; set; } = new List<Component>();
        private DirectoryInfo Directory { get; set; }

        public MyFolder(string path) : base(path)
        {
            Scan(path);
            Directory = new DirectoryInfo(path);
        }

        private void Scan(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            var directories = dirInfo.GetDirectories();
            if (directories != null)
            {
                foreach (var item in directories)
                {
                    Child.Add(new MyFolder(item.FullName));
                }
            }
            var files = dirInfo.GetFiles();
            if (files != null)
                foreach (var file in files)
                {
                    Child.Add(new MyFile(file.FullName));
                }
        }

        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Add(string path)
        {
            base.Add(path);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + $"<{Directory.Name}>");
            foreach (var item in Child)
            {
                item.Display(depth + 1);
            }
            Console.WriteLine(new String(' ', depth) + $@"</{Directory.Name}>");
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }
    }

    class MyFile : Component
    {
        private FileInfo File { get; set; }
        public MyFile(string path) : base(path)
        {
            if (!System.IO.File.Exists(path))
                throw new ArgumentException("File not found!");
            File = new FileInfo(path);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + File.Name + $"  {SizeCalculating.Calculate(File.Length)}");
        }
    }

    static class SizeCalculating
    {
        static public string Calculate(long size)
        {
            string output = $"{size} Bytes";
            if (size > 1000)
                output = $"{size /= 1000} KB";
            if (size > 1000)
                output = $"{size /= 1000} MB";
            if (size > 1000)
                output = $"{size /= 1000} GB";
            return output;
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Component folder = new MyFolder(@"C:\CMS");
            folder.Display(0);
        }
    }
}
