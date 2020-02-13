using System;
using System.IO;

namespace _01.OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            // WRITING THE TEXT FILE FIRST //
            //StreamWriter textFileWriter = new StreamWriter(@"..\..\text1.txt");
            //for (int i = 0; i < 40; i++)
            //{
            //    textFileWriter.WriteLine($"This is line: {i}");
            //}
            //textFileWriter.Close();


            // READING THE LINES OF THE TEXT FILE AND PRINTING THE ODD LINES ON THE CONSOLE//
            StreamReader fileStream = new StreamReader(@"..\..\text1.txt");

            using (fileStream)
            {
                int currentLine = 0;
                string line = fileStream.ReadLine();

                while (line != null)
                {
                    if (currentLine % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    line = fileStream.ReadLine();
                    currentLine++;
                }
            }
        }
    }
}
