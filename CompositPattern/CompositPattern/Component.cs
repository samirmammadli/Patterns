using System;
using System.Collections.Generic;
using System.IO;

namespace CompositPattern
{
    abstract class Component
    {
        public virtual void Add(string path) { Console.WriteLine("Cannot add to the file!"); }
        public abstract void Display(int depth);
    }

    class MyFolder : Component
    {
        private List<Component> Child { get; set; } = new List<Component>();
        private DirectoryInfo Directory { get; set; }
        private long FolderSize { get; set; } = 0;

        public MyFolder(string path)
        {
            Directory = new DirectoryInfo(path);
            Scan(path);
        }

        private void Scan(string path)
        {
            var directories = Directory.GetDirectories();
            if (directories != null)
            {
                foreach (var item in directories)
                {
                    Child.Add(new MyFolder(item.FullName));
                }
            }
            var files = Directory.GetFiles();
            if (files != null)
                foreach (var file in files)
                {
                    Child.Add(new MyFile(file.FullName));
                    FolderSize += file.Length;
                }
        }
        public override void Add(string path)
        {
            Child = new List<Component>();
            Directory = new DirectoryInfo(path);
            FolderSize = 0;
            Scan(path);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('.', depth) + $"<{Directory.Name}>   Total size: {SizeCalculating.Calculate(FolderSize)}");
            foreach (var item in Child)
            {
                item.Display(depth + 1);
            }
            Console.WriteLine(new String('.', depth) + $@"</{Directory.Name}>");
        }
    }

    class MyFile : Component
    {
        private FileInfo File { get; set; }
        public MyFile(string path)
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
}
