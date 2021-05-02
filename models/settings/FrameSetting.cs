using System;

namespace gokart_vanal
{
  [Serializable]
  public class FrameSetting
  {
    public FrameLayout FrameLayout { get; set; } = FrameLayout.Vertical;

    public VideoData A { get; set; } = new VideoData();

    public VideoData B { get; set; } = new VideoData();
  }

}
