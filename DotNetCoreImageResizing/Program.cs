using ByteSizeLib;
using ImageMagick;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Diagnostics;
using System.IO;

namespace DotNetCoreImageResizing
{
    class Program
    {
        static void Main(string[] args)
        {
            double seconds;
            string size;
            int width = 1200;

            Console.WriteLine("Resizing JPG ...\n");

            string jpgInput = "../../../img/autum.jpg";
            string jpgOutputMagick = "../../../img/autum-magick.jpg";
            string jpgOutputSharp = "../../../img/autum-sharp.jpg";

            var watch = Stopwatch.StartNew();
            MagickResize(jpgInput, jpgOutputMagick, width);
            seconds = Math.Round(watch.Elapsed.TotalSeconds, 2);
            size = ByteSize.FromBytes((double)(new FileInfo(jpgOutputMagick).Length)).ToString();
            Console.WriteLine($"ImageMagick:\t{seconds}s\t{size}");

            watch = Stopwatch.StartNew();
            SharpResize(jpgInput, jpgOutputSharp, width);
            seconds = Math.Round(watch.Elapsed.TotalSeconds, 2);
            size = ByteSize.FromBytes((double)(new FileInfo(jpgOutputSharp).Length)).ToString();
            Console.WriteLine($"ImageSharp:\t{seconds}s\t{size}");

            Console.WriteLine("\nResizing PNG ...\n");

            string pngInput = "../../../img/fall.png";
            string pngOutputMagick = "../../../img/fall-magick.png";
            string pngOutputSharp = "../../../img/fall-sharp.png";

            watch = Stopwatch.StartNew();
            MagickResize(pngInput, pngOutputMagick, width);
            seconds = Math.Round(watch.Elapsed.TotalSeconds, 2);
            size = ByteSize.FromBytes((double)(new FileInfo(pngOutputMagick).Length)).ToString();
            Console.WriteLine($"ImageMagick:\t{seconds}s\t{size}");

            watch = Stopwatch.StartNew();
            SharpResize(pngInput, pngOutputSharp, width);
            seconds = Math.Round(watch.Elapsed.TotalSeconds, 2);
            size = ByteSize.FromBytes((double)(new FileInfo(pngOutputSharp).Length)).ToString();
            Console.WriteLine($"ImageSharp:\t{seconds}s\t{size}");
        }

        /// <summary>
        /// Resize using Magick.NET.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="width"></param>
        static void MagickResize(string input, string output, int width)
        {
            using (var image = new MagickImage(input))
            {
                image.Resize(width, 0);
                image.Write(output);
            }
        }

        /// <summary>
        /// Resize using ImageSharp.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="width"></param>
        static void SharpResize(string input, string output, int width)
        {
            using (var image = Image.Load(input))
            {
                image.Mutate(x => x.Resize(width, 0));
                image.Save(output);
            }
        }
    }
}
