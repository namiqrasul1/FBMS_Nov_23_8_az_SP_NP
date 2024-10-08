using System.Text;

namespace ServerSide.Example;

internal class FileStreamWriteAdapter : IDisposable
{
    private readonly FileStream _stream;

    public FileStreamWriteAdapter(FileStream fileStream)
    {
        if (fileStream is { } && fileStream.CanWrite)
            _stream = fileStream;
        else
            throw new ArgumentException();
    }

    public FileStreamWriteAdapter(string path, FileMode mode, FileAccess fileAccess)
    {
        _stream = new FileStream(path, mode, fileAccess);
    }

    public FileStreamWriteAdapter(string path)
    {
        _stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
    }

    public void Write(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        _stream.Write(bytes, 0, bytes.Length);
    }

    public void Write(int value)
    {
        var bytes = Encoding.UTF8.GetBytes(value.ToString());
        _stream.Write(bytes);
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
