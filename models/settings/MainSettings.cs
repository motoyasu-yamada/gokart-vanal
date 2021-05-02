using System;

namespace gokart_vanal.models
{
  [Serializable()]
  public class MainSettings
  {
    public GridType GridType { get; set; } = GridType.None;

    public ExportSetting Export { get; set; } = new ExportSetting();

    public FrameSetting FrameSetting { get; set; } = new FrameSetting();

  }
}
