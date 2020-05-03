using System.Collections.Generic;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            for (int i = 0; i < data.Count; i++)
            {
                for(int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Trim(' ');
                }
            }
            return data; //-- return result here
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            for(int i = 0; i < data.Count; i++)
            {
                for(int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].TrimStart('"');
                    data[i][j] = data[i][j].TrimEnd('"');
                }
            }
            return data; //-- return result here
        }
        public  List<List<string>> StripHashes(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var index = 0; index < row.Count; index++)
                {
                    if (row[index][0] == '#')
                        row[index] = row[index].Remove(0, 1);

                }
            }
            return data;

        }
        public List<List<string>> ConvertToCapital(List<List<string>> data)
        {
            foreach (List<string> row in data)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].ToUpper();
                }
            }
            return data;
        }
    }
}