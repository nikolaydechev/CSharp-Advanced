using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            var result = new Dictionary<string, int>();

            StreamReader wordsReader = new StreamReader(@"..\..\words.txt");
            StreamReader textReader = new StreamReader(@"..\..\text.txt");
            StreamWriter resultWriter = new StreamWriter(@"..\..\result.txt");

            using (wordsReader)
            {
                using (textReader)
                {
                    using (resultWriter)
                    {
                        string currentWord = wordsReader.ReadLine();

                        while (currentWord != null)
                        {
                            string currentLine = textReader.ReadLine();

                            while (currentLine != null)
                            {
                                int currentWordCount = Regex.Matches(Regex.Escape(currentLine), $@"[\s|\-]{currentWord}", RegexOptions.IgnoreCase).Count;

                                if (!result.ContainsKey(currentWord))
                                {
                                    result.Add(currentWord, 0);
                                }
                                result[currentWord] += currentWordCount;

                                currentLine = textReader.ReadLine();
                            }

                            // START READING FROM BEGINNING OF THE 'text.txt' // (code from stackoverflow.com) //
                            textReader.DiscardBufferedData();
                            textReader.BaseStream.Seek(0, SeekOrigin.Begin);
                            textReader.BaseStream.Position = 0;

                            currentWord = wordsReader.ReadLine();
                        }

                        foreach (var word in result.OrderByDescending(x => x.Value))
                        {
                            resultWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
