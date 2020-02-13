using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06.ZippingSlicedFiles
{
    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            int parts = int.Parse(Console.ReadLine());

            Slice("../../video.mp4", "../../sliced-parts", parts);

            List<string> files = new List<string>();
            for (int i = 0; i < parts; i++)
            {
                files.Add("../../sliced-parts" + (i + 1) + ".gz");
            }

            Assemble(files, "../../assembled.mp4", parts);
        }

        private static void Assemble(List<string> files, string destinationDir, int parts)
        {
            using (FileStream destination = new FileStream(destinationDir, FileMode.Create))
            {
                for (int i = 0; i < parts; i++)
                {
                    using (FileStream inputStream = new FileStream(files[i], FileMode.Open))
                    {
                        using (GZipStream compressionStream =
                            new GZipStream(inputStream, CompressionMode.Decompress, false))
                        {
                            byte[] buffer = new byte[4096];
                            int readBytes = compressionStream.Read(buffer, 0, buffer.Length);

                            while (readBytes != 0)
                            {
                                destination.Write(buffer, 0, readBytes);
                                readBytes = compressionStream.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }

        private static void Slice(string videoMp4, string destinationDir, int parts)
        {
            using (FileStream source = new FileStream(videoMp4, FileMode.Open))
            {
                List<FileStream> destination = new List<FileStream>();

                for (int i = 0; i < parts; i++)
                {
                    destination.Add(new FileStream(destinationDir + (i + 1) + ".gz", FileMode.Create));

                    using (destination[i])
                    {
                        using (GZipStream compressionStream =
                            new GZipStream(destination[i], CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[source.Length / parts];
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            compressionStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
