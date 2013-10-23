using System.Configuration;
using System.IO;
using SimpleBatch;

namespace SimpleBatchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageKey = ConfigurationManager.AppSettings["StorageKey"];

            var host = new Host(storageKey, storageKey);
            host.RunAndBlock();
        }

        public static void MakeUpperCase(
            [BlobInput(@"inputfiles\{name}.txt")] TextReader reader,
            [BlobOutput(@"outputfiles\{name}.txt")] TextWriter writer)
        {
            writer.WriteLine(reader.ReadToEnd().ToUpper());
        }
    }
}
