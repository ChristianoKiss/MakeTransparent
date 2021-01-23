using System;
using System.Drawing;
using System.IO;

namespace MakeTransparent
{
    class Program
    {
        const string CONVERTED_FILE_SUFFIX = "-converted";

        static void Main(string[] args)
        {
            if (args.Length == 0)
                ExitApplication($"A filename has not been specified.", ExitCodeEnum.FileNotSpecified);

            if (IsHelpArgument(args[0]))
                ExitApplication("This application takes an image file as argument and applies transparency where colour is magenta (Red=255, Green=0, Blue=255).", ExitCodeEnum.Ok);

            var filename = args[0];

            if (!File.Exists(filename))
                ExitApplication($"Could not find file '{filename}'.", ExitCodeEnum.FileNotFound);

            try
            {
                var file = new Bitmap(filename);
                file.MakeTransparent(Color.Magenta);

                var filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var filenameExtension = Path.GetExtension(filename);
                var convertedFilename = $"{filenameWithoutExtension}{CONVERTED_FILE_SUFFIX}{filenameExtension}";

                file.Save(convertedFilename);

                ExitApplication($"Conversion finished sucessfully into file {convertedFilename}.", ExitCodeEnum.Ok);
            }
            catch (ArgumentException)
            {
                ExitApplication($"Sorry, could not convert the file because of unsupported type.", ExitCodeEnum.FileNotSupported);
            }
        }

        private static bool IsHelpArgument(string argument) =>
            argument == "--help"
            || argument == "-h"
            || argument == "/?";

        private static void ExitApplication(string message, ExitCodeEnum exitCode)
        {
            Console.WriteLine(message);
            Console.Write("Press any key to close this window...");
            Console.ReadKey(true);
            Environment.Exit((int)exitCode);
        }
    }
}
