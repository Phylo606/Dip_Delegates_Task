using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParser;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            FileHandler filehandler = new FileHandler();

            List<string> fileContents = filehandler.ReadFile(readFile);

            List<List<string>> csv = filehandler.ParseCsv(fileContents);

            filehandler.WriteFile(writeFile, ',', dataHandler.Invoke(csv));
        }
        
    }
}