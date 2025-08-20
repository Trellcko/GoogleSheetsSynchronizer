namespace Trellcko.GoogleSheetsSynchronizer
{
    public class ParserOutputData
    {
        public string Header { get; private set; }
        public string[] Values { get; private set; }

        public ParserOutputData(string header, string[] values)
        {
            Header = header;
            Values = values;
        }
    }
}