using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryUsageDemo
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Memory<byte> memory = new Memory<byte>(new byte[50]);
            int count = await ReadFromUrlAsync("https://www.microsoft.com", memory).ConfigureAwait(false);
            string buf = Encoding.Default.GetString(memory.Span);
            Console.WriteLine($"Bytes written: {count} {buf}");
        }

        private static async ValueTask<int> ReadFromUrlAsync(string url, Memory<byte> memory)
        {
            using (HttpClient client = new HttpClient())
            {
                using (Stream stream = await client.GetStreamAsync(new Uri(url)).ConfigureAwait(false))
                {
                    return await stream.ReadAsync(memory).ConfigureAwait(false);
                }
            }
        }
    }
}
