using System;

namespace gokart_vanal.alfano6
{
  public class Session
  {
    public string Location { get; set; }
    public uint NumberOfLaps { get; set; }
    public DateTime StartAt { get; set; }
    public Lap[] Laps { get; set; }
    public uint HzOfQuantums { get; } = 50;

    public (int, Lap, LapQuantum50hz) GetInfo(int videoFrame, double videoFps, int offsetFrame)
    {
      var sessionMillis = (int)((videoFrame - offsetFrame) * 1000 / videoFps);
      if (sessionMillis < 0)
      {
        return (sessionMillis, null, null);
      }
      var elapsed = 0;
      foreach (var lap in Laps)
      {
        var lapTimeMillis = (int)(lap.LapTime * 1000);
        if (!(elapsed <= sessionMillis && sessionMillis <= elapsed + lapTimeMillis))
        {
          elapsed += lapTimeMillis;
          continue;
        }
        var lapMillis = sessionMillis - elapsed;
        var lapFrames = lapMillis * HzOfQuantums / 1000;
        var q = lap.Quantums[lapFrames];
        return (lapMillis, lap, q);
      }
      return (sessionMillis - elapsed, null, null);
    }

  }
}
