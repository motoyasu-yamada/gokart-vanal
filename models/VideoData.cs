using System;
using System.Collections.Generic;

namespace gokart_vanal
{
  [Serializable()]
  public class VideoData
  {
    public string VideoPath { get; set; }
    public string Alfano6Path { get; set; }
    public int Alfano6Offset { get; set; } = 0;
    public int OffsetPercent { get; set; } = 15;
    public int ScalePercent { get; set; } = 50;
    public VideoScalingMethod VideoScalingMethod { get; set; } = VideoScalingMethod.FitToScreen;
    public List<Marker> Markers { get; set; } = new List<Marker>();
    public void CopyFrom(VideoData from)
    {
      this.VideoPath = from.VideoPath;
      this.Alfano6Path = from.Alfano6Path;
      this.Alfano6Offset = from.Alfano6Offset;
      this.OffsetPercent = from.OffsetPercent;
      this.ScalePercent = from.ScalePercent;
      this.VideoScalingMethod = from.VideoScalingMethod;
      this.Markers = new List<Marker>();
      foreach (var m in from.Markers)
      {
        this.Markers.Add(m.Clone());
      }
    }
  }

}
