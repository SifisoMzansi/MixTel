using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixAssessment2
{
    public class Helper
    {
        static DateTime GetFormattedTime(ulong input)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(input);
        }
    }
}
