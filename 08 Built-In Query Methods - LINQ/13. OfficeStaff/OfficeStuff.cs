namespace _13.OfficeStaff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            var companiesData = new SortedDictionary<string, Dictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                string[] inputParams = input.Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
                var company = inputParams[0];
                var amount = int.Parse(inputParams[1]);
                var product = inputParams[2];

                if (companiesData.ContainsKey(company))
                {
                    if (!companiesData[company].ContainsKey(product))
                    {
                        companiesData[company].Add(product, amount);
                    }
                    else
                    {
                        companiesData[company][product] += amount;
                    }
                }

                if (!companiesData.ContainsKey(company))
                {
                    companiesData[company] = new Dictionary<string, int>();
                    companiesData[company].Add(product, amount);
                }
            }

            foreach (var company in companiesData)
            {
                Console.Write($"{company.Key}: ");

                string data = string.Join(", ", company.Value.Select(x => x.Key + "-" + x.Value)); //.ToList()

                Console.WriteLine(data);
            }
        }
    }
}
