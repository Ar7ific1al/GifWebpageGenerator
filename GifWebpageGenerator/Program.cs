using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GifWebpageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string extension = "";
            bool accepted = false;
            object[] results;
            do
            {
                results = selectExtension();
                if (results[1].ToString().ToLower() == "yes")
                {
                    accepted = true;
                }
            } while (!accepted);
            extension = results[0].ToString().ToLower();
            Console.WriteLine("Please enter the name of the output html file, minus the extension.");
            string pageName = Console.ReadLine();
            string sourceDir = Environment.CurrentDirectory + "\\" + extension + "\\";
            Console.WriteLine("Source Directory: " + extension);
            FileStream fs = File.Open(Environment.CurrentDirectory + "\\" + pageName + ".html", FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            var gifs = Directory.GetFiles(sourceDir, "*." + extension);

            TextInfo textInfo = (Thread.CurrentThread.CurrentCulture).TextInfo;

            foreach (string gif in gifs)
            {
                string filename = gif.Substring(sourceDir.Length);
                string filenameNoExtension = ((gif.Substring(sourceDir.Length)).Split('.'))[0];

                writer.WriteLine("<img src=\"" + extension + "/" + filename + "\" alt=\"" + textInfo.ToTitleCase(filenameNoExtension) + "\">");

                Console.WriteLine("File \"" + filename + "\" added to webpage.");
            }
            writer.Close();
            Console.WriteLine("DONE!! Press Enter to exit.");
            Console.ReadLine();
        }

        static object[] selectExtension()
        {
            Console.WriteLine("Please enter the extension you want to use, without the \".\"");
            string fileExtention = Console.ReadLine();
            Console.WriteLine("Files with a *." + fileExtention + " extension will be used. Is that okay? (Yes/No)");
            string accept = Console.ReadLine();
            object[] result = { fileExtention, accept };
            return result;
        }
    }
}
