using System;
namespace AOC_Day_7
{
	public class Directory
	{
		string dirName;
		string path;
		long dirSize;
		Directory parent;

		List<Directory> directories;
		List<File> files;

		public Directory(string name, Directory? p)
		{
			dirName = name;
			dirSize = 0;
			parent = p;
            directories = new List<Directory>();
            files = new List<File>();
        }

		public void AddDirectoryToCurrent(string directoryName, Directory par)
		{
            Directory temp = new Directory(directoryName, par);
			this.directories.Add(temp);
		}

        public void AddFileToCurrentDirectory(string fileName, long size, Directory par)
        {
            File temp = new File(fileName, size, par);
            this.files.Add(temp);
        }

		public string CurrentDirectoryName
		{
			get { return this.dirName; }
			set { this.dirName = value; }
		}

        public string CurrentDirectoryPath
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public long CurrentDirectorySize
        {
            get { return this.dirSize; }
            set { this.dirSize = value; }
        }

        public Directory ParentDirectory
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public List<Directory> ListDirectories
        {
            get { return this.directories; }
        }

        public List<File> ListFiles
        {
            get { return this.files; }
        }
    }
}

