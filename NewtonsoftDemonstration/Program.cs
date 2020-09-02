using System;
using System.Text;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
namespace StreamsAndAsync
{
    public class Program
    {
        static void Main(string[] args)
        {
            ComplexModel testModel = new ComplexModel();
            string testMessage = JsonConvert.SerializeObject(testModel);
            byte[] messageBytes = Encoding.UTF8.GetBytes(testMessage);
            using (Stream ioStream = new
           FileStream(@"../stream_demo_file.txt", FileMode.OpenOrCreate))
            {
                if (ioStream.CanWrite)
                {
                    ioStream.Write(messageBytes, 0, messageBytes.Length);
                }
                else
                {
                    Console.WriteLine("Couldn't write to our data stream.");
              }
            }
            Console.WriteLine("Done!");
            Thread.Sleep(10000);
        }
    }
}
