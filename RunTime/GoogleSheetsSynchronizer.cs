using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trellcko.GoogleSheetsSynchronizer
{
    public class GoogleSheetsSynchronizer : IGoogleSheetsSynchronizer
    {
        private readonly IParsingDataDebugger _parsingDataDebugger = new ParsingDataDebugger();
        private readonly ICsvDownloader _csvDownloader = new CsvDownloader();
        private readonly ICsvParser _csvParser = new CsvParser();
        private readonly IDataWriter _dataWriter = new DataWriter();
        
        private readonly bool _debug;

        public GoogleSheetsSynchronizer(bool debug = true)
        {
            _debug = debug;
        }
        
        public async void Synchronize(SynchronizedData syncData)
        {
            try
            {
                string csv = await _csvDownloader.DownloadCsv(syncData.key);
            
                List<ParserOutputData> parserOutputData = _csvParser.Parse(csv);

                if (_debug)
                {
                    _parsingDataDebugger.Log(parserOutputData);
                }
                foreach (ParserOutputData data in parserOutputData)
                {
                    _dataWriter.Write(syncData, data);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while synchronizing Google Sheets {e.Message} \n {e.StackTrace}");
            }
        }
        }
    }
