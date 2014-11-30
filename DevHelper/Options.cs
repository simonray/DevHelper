using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelper
{
    public class Options
    {
        [Option('c', "clean", HelpText = "Delete the output folders [bin], [obj] and [packages].")]
        public string Clean { get; set; }

        [Option('t', "touch", HelpText = "Touch and set all files/folders to the current date/time recursively.")]
        public string Touch { get; set; }
        
        [Option("zf", HelpText = "Output zip filename.")]
        public string ZipFile { get; set; }
        
        [Option("zd", HelpText = "Zip a directory recursively.")]
        public string ZipDirectory { get; set; }

        [Option("test", DefaultValue = false, HelpText = "Test mode (no actions are performed).")]
        public bool Test { get; set; }

        [CommandLine.HelpOption]
        public string GetUsage()
        {
            return CommandLine.Text.HelpText.AutoBuild(this,
              (CommandLine.Text.HelpText current) => CommandLine.Text.HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
