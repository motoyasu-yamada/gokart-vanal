using System.ComponentModel;

namespace gokart_vanal
{
  public class PlayData : INotifyPropertyChanged
  {
    private int currentFramePosA;
    private int currentFramePosB;
    public int CurrentFramePosA { get { return currentFramePosA; } set { currentFramePosA = value; NotifyPropertyChanged(nameof(CurrentFramePosA)); } }
    public int CurrentFramePosB { get { return currentFramePosB; } set { currentFramePosB = value; NotifyPropertyChanged(nameof(CurrentFramePosB)); } }

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
