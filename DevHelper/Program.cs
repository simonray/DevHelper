using DevHelper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.Test)
                    Console.WriteLine("*** TEST MODE ***");

                Queue<Command> Commands = new Queue<Command>();

                if (!string.IsNullOrEmpty(options.Clean))
                    Commands.Enqueue(new Clean(options));

                if (!string.IsNullOrEmpty(options.Touch))
                    Commands.Enqueue(new Touch(options));

                if (!string.IsNullOrEmpty(options.ZipFile))
                    Commands.Enqueue(new Zip(options));

                if (Commands.Count() > 0)
                {
                    if (Commands.All(command => command.Ensure()))
                        Commands.All(command => command.Execute());
                }
                else
                    System.Console.WriteLine("Nothing to do!");
            }
            else
            {
                options.GetUsage();
            }

            System.Console.WriteLine("Press <RETURN> to exit");
            System.Console.ReadKey();
        }
    }
}
