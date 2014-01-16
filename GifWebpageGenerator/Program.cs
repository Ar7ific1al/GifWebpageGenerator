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
            string sourceDir = Environment.CurrentDirectory + "\\gifs\\";
            FileStream fs = File.Open(Environment.CurrentDirectory + "\\index.html", FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            var gifs = Directory.GetFiles(sourceDir, "*.gif");

            TextInfo textInfo = (Thread.CurrentThread.CurrentCulture).TextInfo;

            foreach (string gif in gifs)
            {
                string filename = gif.Substring(sourceDir.Length);
                string filenameNoExtension = ((gif.Substring(sourceDir.Length)).Split('.'))[0];

                writer.WriteLine("<img src=\"gifs/" + filename + "\" alt=\"" + textInfo.ToTitleCase(filenameNoExtension) + "\">");

                Console.WriteLine("File \"" + filename + "\" added to webpage.");
            }
            writer.Close();
            Console.WriteLine("DONE!! Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
