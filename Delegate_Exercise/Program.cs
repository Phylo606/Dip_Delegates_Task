using System;
using System.Collections.Generic;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            CsvHandler ch = new CsvHandler();
            DataParser dp = new DataParser();

            Func<List<List<string>>, List<List<string>>> x = dp.StripQuotes;

            x += dp.StripWhiteSpace;
            x += dp.StripHashes;

            ch.ProcessCsv("data.csv", "processed_data.csv", x);
        }

        
    }
}
