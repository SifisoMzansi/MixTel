using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixAssessment2
{
    public class Logger
    {
        public static void WriteMessage(string msg)
        {
            Console.WriteLine(msg); 
        }
        public static void WriteMessage(string msg, int count)
        {
            Console.Title = count.ToString();
            Console.WriteLine(msg);
        }
    }
}
