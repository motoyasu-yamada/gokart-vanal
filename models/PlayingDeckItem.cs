using OpenCvSharp;
using System.ComponentModel;

namespace gokart_vanal
{
  public class PlayingDeckItem : INotifyPropertyChanged
  {
    private VideoCapture videoCapture;

    public VideoCapture VideoCapture
    {
      get { return this.videoCapture; }
      set
      {
        if (videoCapture != null)
        {
          videoCapture.Dispose();
        }
        videoCapture = value;
      }
    }

    public alfano6.Session Session { get; set; }

    private int currentFramePos;
    public int CurrentFramePos
    {
      get { return currentFramePos; }
      set
      {
        currentFramePos = value;
        NotifyPropertyChanged(nameof(CurrentFramePos));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
