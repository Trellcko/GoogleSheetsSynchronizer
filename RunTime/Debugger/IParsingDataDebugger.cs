using System.Collections.Generic;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public interface IParsingDataDebugger
    {
        void Log(List<ParserOutputData> data);
    }
}