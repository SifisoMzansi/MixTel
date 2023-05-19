using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixAssessment2
{
    public class FileProcessor
    {
       const string FILE_NAME = "VehiclePositions.dat";
       static string FilePath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/{FILE_NAME}";

        public static byte[] ReadFile()
        {
            return ReadAllBytesAsync(FilePath).Result;
        }

       static async Task<byte[]> ReadAllBytesAsync(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                byte[] buffer = new byte[fileStream.Length];

                await fileStream.ReadAsync(buffer, 0, buffer.Length);

                return buffer;
            }
        }
    }
}
