using System;
using System.Linq;
using System.IO;

namespace DevHelper.Commands
{
    public class Clean : Command
    {
        static string[] Folders = new string[] { "bin", "obj", "packages" };

        public Clean(Options options) : base(options) { }

        public override bool Ensure()
        {
            return base.FolderExists(Opts.Clean);
        }

        public override bool Execute()
        {
            CleanFolder(Opts.Clean);
            return true;
        }

        private int CleanFolder(string parent)
        {
            int count = 0;
            foreach (string directory in Directory.GetDirectories(parent))
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                if (Folders.Contains(info.Name))
                {
                    ++count;
                    if (!Opts.Test)
                        Directory.Delete(info.FullName, true);
                    System.Console.WriteLine("Deleting: {0}", directory);
                }
                else
                    count += CleanFolder(directory);
            }
            return count;
        }
    }
}
