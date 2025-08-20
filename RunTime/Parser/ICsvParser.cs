using System.Collections.Generic;
using NUnit.Framework;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public interface ICsvParser
    {
        List<ParserOutputData> Parse(string csv);
    }
}