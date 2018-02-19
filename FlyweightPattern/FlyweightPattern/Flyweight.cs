using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace FlyweightPattern
{
    enum Pictures
    {
        Forest,
        City,
        Sea
    }

    static class ImageLoader
    {
        static public Bitmap DownloadImage(string url)
        {
            var client = new WebClient();
            using (MemoryStream stream = new MemoryStream(client.DownloadData(url)))
            {
                client.Dispose();
                return new Bitmap(stream);
            }
        }
    }


    class Flyweight
    {
        private Dictionary<Pictures, Bitmap> Images;
        public Flyweight()
        {
            Images = new Dictionary<Pictures, Bitmap>();
            LoadImages();
        }

        public Bitmap GetImage(Pictures picture)
        {
            if (!Images.ContainsKey(picture))
                throw new ArgumentException("Image not found!");
            return Images[picture];
        }

        private void LoadImages()
        {
            Images.Add(Pictures.Sea, ImageLoader.DownloadImage("https://images.pexels.com/photos/37403/bora-bora-french-polynesia-sunset-ocean.jpg?h=350&auto=compress&cs=tinysrgb"));
            Images.Add(Pictures.Forest, ImageLoader.DownloadImage("https://images.pexels.com/photos/240040/pexels-photo-240040.jpeg?h=350&auto=compress&cs=tinysrgb"));
            Images.Add(Pictures.City, ImageLoader.DownloadImage("https://images.pexels.com/photos/373912/pexels-photo-373912.jpeg?h=350&auto=compress&cs=tinysrgb"));
        }
    }
}
