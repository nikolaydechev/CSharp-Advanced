using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    public class SlicingFile
    {
        public static void Main()
        {
            var parts = int.Parse(Console.ReadLine());

            Slice(@"..\..\video.mp4", @"..\..\sliced-parts", parts);

            var files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add(@"..\..\sliced-parts" + (i + 1) + ".mp4");
            }

            Assemble(files, @"..\..\assembled.mp4", parts);
        }
        
        static void Assemble(List<string> files, string destinationDirectory, int parts)
        {
            using (FileStream destination = new FileStream(destinationDirectory, FileMode.Create))
            {
                for (int i = 0; i < parts; i++)
                {
                    using (FileStream inputStream = new FileStream(files[i], FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = inputStream.Read(buffer, 0, buffer.Length);

                        while (readBytes != 0)
                        {
                            destination.Write(buffer, 0, readBytes);
                            readBytes = inputStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
        
        private static void Slice(string videoMp4, string destinationDir, int parts)
        {
            using (FileStream source = new FileStream(videoMp4, FileMode.Open))
            {
                var destination = new List<FileStream>();

                for (int i = 0; i < parts; i++)
                {
                    destination.Add(new FileStream(destinationDir + (i + 1) + ".mp4", FileMode.Create));

                    using (destination[i])
                    {
                        byte[] buffer = new byte[source.Length / parts];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        destination[i].Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
