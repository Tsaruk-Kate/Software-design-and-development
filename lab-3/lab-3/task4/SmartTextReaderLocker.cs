using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReaderLocker : ITextReader
    {
        private readonly string _lockPattern;
        private readonly ITextReader _realReader;

        public SmartTextReaderLocker(string lockPattern)
        {
            _lockPattern = lockPattern;
            _realReader = new SmartTextReader();
        }

        public char[,] ReadText(string filePath)
        {
            string fileName = Path.GetFileName(filePath);

            if (Regex.IsMatch(fileName, _lockPattern))
            {
                Console.WriteLine("Access denied to file: " + fileName);
                return null;
            }

            return _realReader.ReadText(filePath);
        }
    }
}
