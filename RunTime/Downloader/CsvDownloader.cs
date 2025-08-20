using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public class CsvDownloader : ICsvDownloader
    {
        private const string HTTP = "https://docs.google.com/spreadsheets/d/";
        private const string ExportFormat = "/export?format=csv";
        
        public async UniTask<string> DownloadCsv(string key)
        {
            try
            {
                using UnityWebRequest www =
                    UnityWebRequest.Get(GetLink(key));

                UnityWebRequestAsyncOperation operation = www.SendWebRequest();

                await operation.ToUniTask();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Download error: {www.error}");
                    return null;
                }

                return www.downloadHandler.text;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while trying download CSV: {e.Message} \n {e.StackTrace}");
                return null;
            }
        }

        private static string GetLink(string key) => 
            $"{HTTP}{key}{ExportFormat}";
    }
}