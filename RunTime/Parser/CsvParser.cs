using System;
using System.Collections.Generic;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public class CsvParser : ICsvParser
    {
        public List<ParserOutputData> Parse(string csv)
        {
            string[] lines = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string[] headers = lines[0].Split(',');

            string[][] rows = new string[lines.Length - 1][];
            for (int i = 1; i < lines.Length; i++)
                rows[i - 1] = lines[i].Split(',');

            return GenerateOutputData(headers, rows);
        }
        
        private static List<ParserOutputData> GenerateOutputData(string[] headers, string[][] rows)
        {
            List<ParserOutputData> outputData = new();    
            for (int i = 0; i < headers.Length; i++)
            {
                List<string> values = new();
                
                for (int j = 0; j < rows.Length; j++)
                {
                    if (string.IsNullOrEmpty(rows[j][i]) || string.IsNullOrWhiteSpace(rows[j][i]))
                        continue;
                    values.Add(rows[j][i]);
                }
                
                outputData.Add(new(headers[i], values.ToArray()));
            }

            return outputData;
        }
    }
}