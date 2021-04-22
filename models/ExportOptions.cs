using System;

namespace gokart_vanal
{
  [Serializable()]
  public class ExportOptions
  {
    public string Folder { get; set; }
    public string FileNameTemplate { get; set; }
    public int LengthMillis { get; set; } = 3000;
    public int ImageDecompositionIntervalMillis { get; set; } = 200;
  }

}
