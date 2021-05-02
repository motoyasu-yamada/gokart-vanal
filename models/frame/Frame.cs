namespace gokart_vanal
{

  public class Frame
  {
    public FrameId Id { get; set; }
    public VideoData VideoData
    {
      get { return Id == FrameId.A ? Program.UserSettings.MainSetting.FrameSetting.A : Program.UserSettings.MainSetting.FrameSetting.B; }
      set { if (Id == FrameId.A) { Program.UserSettings.MainSetting.FrameSetting.A = value; } else { Program.UserSettings.MainSetting.FrameSetting.B = value; } }
    }
    public FramePlaybackData PlaybackData { get; set; } = new FramePlaybackData();
    public FrameComponents Components { get; set; }
  }
}
