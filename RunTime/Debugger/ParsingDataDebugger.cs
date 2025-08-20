using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public class ParsingDataDebugger : IParsingDataDebugger
    {
        public void Log(List<ParserOutputData> data)
        {
            StringBuilder result = new();
            result.Append("{\n");
            for (int i = 0; i < data.Count; i++)
            {
                result.Append("\t Name: " + data[i].Header+ "\n");
                result.Append("\t\t Values:\n");
                for (int j = 0; j < data[i].Values.Length; j++)
                {
                    result.Append($"\t\t\t {j + 1}.: " + data[i].Values[j] + "\n");
                }
            }
            result.Append("}");
            Debug.Log(result.ToString());
        }
    }
}