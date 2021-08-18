namespace BinaryViewer
{
    public interface IByteReader
    {
        byte[] ReadFromFile(string filePath, long start, long bytesToRead);
    }
}
