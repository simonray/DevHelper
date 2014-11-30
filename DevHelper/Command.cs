using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelper
{
    public abstract class Command
    {
        protected Options Opts { get; private set; }

        public Command(Options options)
        {
            Opts = options;
        }

        protected bool FolderExists(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Console.WriteLine(string.Format("The folder '{0}' does not exist", folder));
                return false;
            }
            return true;
        }

        protected bool FileExists(string file)
        {
            if (!File.Exists(Opts.Clean))
            {
                Console.WriteLine(string.Format("The file '{0}' does not exist", file));
                return false;
            }
            return true;
        }

        public virtual bool Ensure() { return true; }

        public abstract bool Execute();
    }
}
