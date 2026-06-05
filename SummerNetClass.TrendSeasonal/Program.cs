// Albert Tulo IV
// 5/26/2026
// CPSC 23000, Programming Assignment 2

using System.Globalization;

namespace TrendSeasonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[12];
            int[,] dataValues = new int[12, 5];

            string title = "TREND-SEASONAL-NOISE ANALYSIS";

            double[] monthlyAverages = new double[12];
            double[] monthlyDeviations = new double[12];
            double[] quarterlyDeviations = new double[4];

            double[] yearlyAverages = new double[5];
            double[] yearlyDeviations = new double[5];

            string[] years = { "2020", "2021", "2022", "2023", "2024" };
            
            LoadFile(months, dataValues);

            MonthlyAverages(dataValues, monthlyAverages);
            MonthlyDeviations(monthlyAverages, monthlyDeviations);

            QuarterlyDeviations(monthlyAverages, quarterlyDeviations);

            YearlyAverages(dataValues, yearlyAverages);
            YearlyDeviations(yearlyAverages, yearlyDeviations);

            Console.WriteLine(title.PadLeft((Console.WindowWidth + title.Length) / 2));
            Console.WriteLine();

            Console.WriteLine("".PadRight(10));

            Console.Write("".PadLeft(10));

            for (int i = 0; i < years.Length; i++)
            {
                Console.Write(years[i].PadLeft(8));
            }

            Console.Write("Monthly".PadLeft(12));
            Console.Write("Monthly".PadLeft(14));
            Console.Write("Quarterly".PadLeft(14));
            Console.WriteLine();
            
            Console.Write("".PadRight(10));

            for (int i = 0; i < years.Length; i++)
            {
                Console.Write("".PadLeft(8));
            }

            Console.Write("Average".PadLeft(12));
            Console.Write("Deviation".PadLeft(14));
            Console.Write("Deviation".PadLeft(14));
            Console.WriteLine();

            for (int row = 0; row < months.Length; row++)
            {
                Console.Write(months[row].PadRight(10));

                for (int col = 0; col < dataValues.GetLength(1); col++)
                {
                    Console.Write(dataValues[row,col].ToString().PadLeft(8));
                }

                Console.Write(monthlyAverages[row].ToString("F1").PadLeft(12));
                Console.Write(monthlyDeviations[row].ToString("F2").PadLeft(14));

                if (row == 2)
                {
                    Console.Write(quarterlyDeviations[0].ToString("F2").PadLeft(14));
                }
                else if (row == 5)
                {
                    Console.Write(quarterlyDeviations[1].ToString("F2").PadLeft(14));
                }
                else if (row == 8)
                {
                    Console.Write(quarterlyDeviations[2].ToString("F2").PadLeft(14));
                }
                else if (row == 11)
                {
                    Console.Write(quarterlyDeviations[3].ToString("F2").PadLeft(14));
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 95));

            Console.WriteLine("Yearly");
            Console.Write("Average".PadRight(10));

            for (int i = 0; i < yearlyAverages.Length; i++)
            {
                Console.Write(yearlyAverages[i].ToString("F2").PadLeft(8));
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Yearly");
            Console.Write("Deviation".PadRight(10));

            for (int i = 0; i < yearlyDeviations.Length; i++)
            {
                Console.Write(yearlyDeviations[i].ToString("F2").PadLeft(8));
            }

            Console.WriteLine();
        }

        static void LoadFile(string[] months, int[,] dataValues)
        {
            string[] lines = File.ReadAllLines("../../../trend.txt");

            for (int row = 0; row < lines.Length; row++)
            {
                string[] parts = lines[row].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                months[row] = parts[0];

                for (int col = 0; col < dataValues.GetLength(1); col++)
                {
                    dataValues[row, col] = int.Parse(parts[col + 1]);
                }
            }
        }

        static void MonthlyAverages(int[,] dataValues, double[] monthlyAverages)
        {
            for (int row = 0; row < dataValues.GetLength(0); row++)
            {
                int total = 0;

                for (int col = 0; col < dataValues.GetLength(1); col++)
                {
                    total += dataValues[row, col];
                }

                monthlyAverages[row] = total / 5.0;
            }
        }

        static void MonthlyDeviations(double[] monthlyAverages, double[] monthlyDeviations)
        {
            double grandMean = 57.3;

            for (int i = 0; i < monthlyAverages.Length; i++)
            {
                monthlyDeviations[i] = Math.Pow(grandMean - monthlyAverages[i], 2);
            }
        }

        static void QuarterlyDeviations(double[] monthlyAverages, double[] quarterlyDeviations)
        {
            double grandMean = 57.3;

            for (int quarter = 0; quarter < 4; quarter++)
            {
                int startMonth = quarter * 3;

                double quarterlyAverage = (monthlyAverages[startMonth] + monthlyAverages[startMonth + 1] +
                                           monthlyAverages[startMonth + 2]) / 3.0;

                quarterlyDeviations[quarter] = Math.Pow(grandMean - quarterlyAverage, 2);
            }
        }

        static void YearlyAverages(int[,] dataValues, double[] yearlyAverages)
        {
            for (int col = 0; col < dataValues.GetLength(1); col++)
            {
                int total = 0;

                for (int row = 0; row < dataValues.GetLength(0); row++)
                {
                    total += dataValues[row, col];
                }

                yearlyAverages[col] = total / 12.0;
            }
        }

        static void YearlyDeviations(double[] yearlyAverages, double[] yearlyDeviations)
        {
            double grandMean = 57.3;

            for (int i = 0; i < yearlyAverages.Length; i++)
            {
                yearlyDeviations[i] = Math.Pow(grandMean - yearlyAverages[i], 2);
            }
        }
    }
}