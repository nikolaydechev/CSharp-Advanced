using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string directory = Console.ReadLine();
            string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            var report = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo information = new FileInfo(file);

                if (!report.ContainsKey(information.Extension))
                {
                    report.Add(information.Extension, new Dictionary<string, double>());
                }
                report[information.Extension][information.Name] = information.Length;
            }

            var output = report.OrderByDescending(x => x.Value.Keys.Count).ThenBy(x => x.Key).ThenBy(x => x.Value.Values);

            foreach (var extension in output)
            {
                Console.WriteLine(extension.Key);

                foreach (var file in extension.Value)
                {
                    Console.WriteLine($"--{file.Key} - {file.Value / 1000}kb");
                }
            }
        }
    }
}
