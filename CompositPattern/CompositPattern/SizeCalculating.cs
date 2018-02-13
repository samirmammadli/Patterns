namespace CompositPattern
{
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
}
