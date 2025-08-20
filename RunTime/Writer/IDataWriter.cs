namespace Trellcko.GoogleSheetsSynchronizer
{
    public interface IDataWriter
    {
        void Write(SynchronizedData target, ParserOutputData data);
    }
}