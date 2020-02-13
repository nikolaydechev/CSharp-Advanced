using System.IO;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            // WRITING THE TEXT FILE //
            //StreamWriter textFileWriter = new StreamWriter(@"..\..\text2.txt");
            //for (int i = 0; i < 40; i++)
            //{
            //    textFileWriter.WriteLine($"This is a line");
            //}
            //textFileWriter.Close();


            // WRITING A NEW TEXT FILE WITH LINE NUMBER IN FRONT OF EACH LINE //
            StreamReader fileReader = new StreamReader(@"..\..\text2.txt");
            StreamWriter fileWriter = new StreamWriter(@"..\..\text2-with-lineNumbers.txt");

            using (fileReader)
            {
                using (fileWriter)
                {
                    int lineNumber = 0;
                    string currentLine = fileReader.ReadLine();

                    while (currentLine != null)
                    {
                        fileWriter.WriteLine($"{lineNumber}. {currentLine}");
                        lineNumber++;
                        currentLine = fileReader.ReadLine();
                    }
                }
            }
        }
    }
}
