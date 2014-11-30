using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelper.Commands
{
    public class Zip : Command
    {
        public Zip(Options options) : base(options) { }

        public override bool Ensure()
        {
            if (string.IsNullOrEmpty(Opts.ZipDirectory) || !Directory.Exists(Opts.ZipDirectory))
            {
                Console.WriteLine("The specified zip directory is not specified or does not exist.");
                return false;
            }

            if (File.Exists(Opts.ZipFile))
            {
                Console.WriteLine("The destination zip file already exists.");
                return false;
            }

            if (Opts.ZipFile.IndexOf(Opts.ZipDirectory, StringComparison.OrdinalIgnoreCase) != -1)
            {
                Console.WriteLine("A zip file cannot be created inside the directory you are trying to compress.");
                return false;
            }
            
            return FolderExists(Opts.ZipDirectory);
        }

        public override bool Execute()
        {
            Console.WriteLine(string.Format("Zipping folder '{0}'", Opts.ZipDirectory));
            ZipFile.CreateFromDirectory(Opts.ZipDirectory, Opts.ZipFile);
            return true;
        }
    }
}
