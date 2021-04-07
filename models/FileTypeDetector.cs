using System;

namespace gokart_vanal
{
  public enum FileType
  {
    Video,
    Alfano6,
    Unsupported
  }
  public class FileTypeDetector
  {
    public static FileType Detect(string path)
    {
      if (path.EndsWith(".zip") && path.Contains("\\ALFANO6_LAP_"))
      {
        return FileType.Alfano6;
      }
      if(path.EndsWith(".MP4", StringComparison.OrdinalIgnoreCase))
      {
        return FileType.Video;
      }
      return FileType.Unsupported;
    }
  }
}
