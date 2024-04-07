using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReader : ITextReader
    {
        public char[,] ReadText(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                char[,] result = new char[lines.Length, lines.Max(l => l.Length)];

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        result[i, j] = lines[i][j];
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return null;
            }
        }
    }
}
