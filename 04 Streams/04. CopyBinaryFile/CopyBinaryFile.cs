using System.IO;

namespace _04.CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            FileStream getImage = new FileStream(@"..\..\image.gif", FileMode.Open);
            FileStream copyImage = new FileStream(@"..\..\image-copy.gif", FileMode.Create);

            using (getImage)
            {
                using (copyImage)
                {
                    byte[] buffer = new byte[8192];

                    while (true)
                    {
                        var readBytes = getImage.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        copyImage.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
