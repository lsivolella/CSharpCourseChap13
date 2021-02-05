using Cap13.Entities;
using System;
using System.Globalization;
using System.IO;

namespace Cap13
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise01();
        }

        static void Exercise01()
        {
            Console.WriteLine("Enter the source file full path: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                string sourceDirectoryPath = Path.GetDirectoryName(sourcePath);
                string targetDirectoryPath = Path.GetDirectoryName(sourcePath) + @"\out";
                string targetFilePath = targetDirectoryPath + @"\summary.csv";

                Directory.CreateDirectory(targetDirectoryPath);

                using (StreamWriter streamWriter = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int units = int.Parse(fields[2]);

                        Product product = new Product(name, price, units);

                        Console.WriteLine(product.Name + ", R$ " + product.Total().ToString("f2", CultureInfo.InvariantCulture));
                    }
                }
            }

            catch (IOException message)
            {
                Console.WriteLine("An error ocurred: " + message);
            }
        }
    }
}
