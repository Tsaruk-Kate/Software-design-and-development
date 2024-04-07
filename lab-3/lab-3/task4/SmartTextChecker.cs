using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextChecker : ITextReader
    {
        private readonly ITextReader _realReader;

        public SmartTextChecker()
        {
            _realReader = new SmartTextReader();
        }

        public char[,] ReadText(string filePath)
        {
            Log("Opened file: " + filePath);

            char[,] result = _realReader.ReadText(filePath);

            Log("Read file: " + filePath);
            Log("Closed file: " + filePath);

            return result;
        }

        private void Log(string message)
        {
            Console.WriteLine("Proxy: " + message);
        }
    }
}
