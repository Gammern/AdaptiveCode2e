using MyTradeApp.Contracts;
using System.Collections.Generic;
using System.IO;

namespace MyTradeApp
{
    internal class StreamTradeDataProvider : ITradeDataProvider
    {
        private readonly Stream stream;

        public StreamTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public IEnumerable<string> GetTradeData()
        {
            // read rows
            var tradeData = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
    }
}