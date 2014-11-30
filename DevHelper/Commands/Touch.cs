using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelper.Commands
{
    public class Touch : Command
    {
        private DateTime Date { get; set; }

        public Touch(Options options) : base(options) { }

        public override bool Ensure()
        {
            return base.FolderExists(Opts.Touch);
        }

        public override bool Execute()
        {
            Date = DateTime.Now;
            int count = TouchFolder(Opts.Touch);
            return true;
        }

        private int TouchFolder(string parent)
        {
            int count = 0;

            if (Opts.Touch.ToLower().Equals(parent.ToLower()) == false)
                count += SetDirectoryDate(parent);

            foreach (string directory in Directory.GetDirectories(parent))
                count += SetDirectoryDate(directory) + TouchFolder(directory);

            foreach (string filename in Directory.GetFiles(parent))
                count += SetFileDate(filename);

            return count;
        }

        private int SetDirectoryDate(string directory)
        {
            try
            {
                Console.WriteLine("Date: {0}", directory, File.GetLastWriteTime(directory));
                if (!Opts.Test)
                {
                    Directory.SetLastWriteTime(directory, Date);
                    Directory.SetCreationTime(directory, Date);
                    Directory.SetLastAccessTime(directory, Date);
                }
                return 1;
            }
            catch (Exception ex) { Console.WriteLine("*** ERROR ***\n{0}", ex.Message); return 0; }
        }

        private int SetFileDate(string filename)
        {
            try
            {
                Console.WriteLine("Date: {0}", filename, File.GetLastWriteTime(filename));
                if (!Opts.Test)
                {
                    File.SetLastWriteTime(filename, Date);
                    File.SetCreationTime(filename, Date);
                    File.SetLastAccessTime(filename, Date);
                }
                return 1;
            }
            catch (Exception ex) { Console.WriteLine("*** ERROR ***\n{0}", ex.Message); return 0; }
        }
    }
}
