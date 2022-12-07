using System;
namespace AOC_Day_7
{
	public class File
	{
        private string fileName;
        private long size;
        private Directory dir;

        public string FileName { get => fileName; set => fileName = value; }
        public long Size { get => size; set => size = value; }
        public Directory Dir { get => dir; set => dir = value; }

        public File(string name, long s, Directory d)
		{
			fileName = name;
			Size = s;
			Dir = d;
		}
	}
}

