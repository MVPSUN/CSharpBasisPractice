using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASync
{
    public class AsyncFileStream
    {
        public async static void t()
        {
            using (var stream = new FileStream("test2.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.None, 10, FileOptions.Asynchronous))
            {
                Console.WriteLine("2. Uses I/O Threads: {0}", stream.IsAsync);
                byte[] buffer = Encoding.UTF8.GetBytes(CreateFileContent());
                var writeTask = Task.Factory.FromAsync(stream.BeginWrite, stream.EndWrite, buffer, 0, buffer.Length, null);
                await writeTask;
            }
        }
        static string CreateFileContent()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                sb.AppendFormat("{0}", new Random(i).Next(0, 99999));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        async static Task<long> SumFileContent(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None, 10, FileOptions.Asynchronous))
            using (var sr = new StreamReader(stream))
            {
                long sum = 0;
                while (sr.Peek() > -1)
                {
                    string line = await sr.ReadLineAsync();
                    sum += long.Parse(line);
                }

                return sum;
            }
        }

        static Task SimulateAsynchronousDelete(string fileName)
        {
            return Task.Run(() => File.Delete(fileName));
        }

    }
}
