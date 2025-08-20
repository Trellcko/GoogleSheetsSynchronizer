using System;
using System.Collections;
using Cysharp.Threading.Tasks;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public interface ICsvDownloader
    {
        UniTask<string> DownloadCsv(string key);
    }
}