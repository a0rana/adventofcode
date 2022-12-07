namespace AOC_Day_7;
class Program
{
    const long AT_MOST_SIZE = 100000;
    static List<Directory> res;
    static System.IO.StreamWriter fs;
    static List<Tuple<string, long>> tuples;
    static long FS_LIMIT = 70000000;
    static long FS_MIN_SPACE = 30000000;

    static void Main(string[] args)
    {
        Directory root = null;
        Directory currDir = null;
        Directory temp;
        File tempFile;
        res = new List<Directory>();
        tuples = new List<Tuple<string, long>>();

        fs = System.IO.File.CreateText("../../../sampleinput/test.txt");

        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-7-data.txt");

        //create tree structure
        foreach (string line in lines)
        {
            //could be a cd or ls command
            if (line.StartsWith("$"))
            {
                string cmd = line.Split(" ")[1];
                if (cmd == "cd")
                {
                    string dir = line.Split(" ")[2];

                    //case for cd /
                    if (root == null && dir == "/")
                    {
                        root = new Directory(dir, null);
                        root.ParentDirectory = root;
                        currDir = root;
                    }

                    //case for cd ..
                    if (dir == "..")
                    {
                        Directory parent = currDir.ParentDirectory;
                        currDir = parent;
                    }

                    //case for cd hello
                    if (dir != ".." && dir != "/")
                    {
                        foreach (Directory d in currDir.ListDirectories)
                        {
                            if (d.CurrentDirectoryName == dir)
                            {
                                currDir = d;
                                break;
                            }
                        }
                    }
                }
            }
            //not a command - contains "current" directory listing
            else
            {
                string cmd = line.Split(" ")[0];
                string name = line.Split(" ")[1];

                //case for a directory existing inside current directory
                if (cmd == "dir")
                {
                    currDir.AddDirectoryToCurrent(name, currDir);
                }
                else
                {
                    //is a file, cmd will refer to its size
                    currDir.AddFileToCurrentDirectory(name, long.Parse(cmd), currDir);
                }
            }
        }

        PrintStructure(root);

        fs.Flush();
        fs.Close();

        long s = 0;
        foreach (Directory d in res)
        {
            s += d.CurrentDirectorySize;
        }
        Console.WriteLine(s);

        //second problem

        tuples.Sort(delegate (Tuple<string, long> a, Tuple<string, long> b)
        {
            return a.Item2.CompareTo(b.Item2);
        });

        long remainingSpace = FS_LIMIT - tuples[tuples.Count - 1].Item2;
        long requiredSpace = FS_MIN_SPACE - remainingSpace;

        foreach (Tuple<string, long> t in tuples)
        {
            if (t.Item2 >= requiredSpace)
            {
                Console.WriteLine(t.Item1 + " : " + t.Item2);
                break;
            }
        }
    }

    static void PrintStructure(Directory root)
    {
        if (root == null)
            return;

        foreach (Directory d in root.ListDirectories)
        {
            PrintStructure(d);
        }

        long sum = 0;

        fs.WriteLine("Directory Name {0}", root.CurrentDirectoryName);
        foreach (File f in root.ListFiles)
        {
            fs.WriteLine("\t Contains file: {0}", f.FileName);
            fs.WriteLine("\t Contains file with size: {0}", f.Size);
            sum += f.Size;
        }

        root.CurrentDirectorySize = sum;

        foreach (Directory d in root.ListDirectories)
        {
            root.CurrentDirectorySize += d.CurrentDirectorySize;
            fs.WriteLine("\t Contains directory: {0}, size: {1}", d.CurrentDirectoryName, d.CurrentDirectorySize);
        }
        fs.WriteLine("\nDirectory Name {0}, size {1}\n", root.CurrentDirectoryName, root.CurrentDirectorySize);

        tuples.Add(new Tuple<string, long>(root.CurrentDirectoryName, root.CurrentDirectorySize));

        if (root.CurrentDirectorySize <= AT_MOST_SIZE)
        {
            res.Add(root);
        }
    }
}

