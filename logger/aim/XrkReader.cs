using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gokart_vanal.logger.aim
{
  internal class XrkReader
  {
    public static Session Read(string xrkPath)
    {
      if (xrkPath == null)
      {
        return null;
      }
      var file = MatLabXrk.OpenFile(xrkPath);
      if (file < 0)
      {
        throw new ArgumentException($"ファイルを読み込めませんでした: {xrkPath}");
      }
      if (file == 0)
      {
        throw new ArgumentException($"ファイルは壊れています: {xrkPath}");
      }
      try
      {
        var numberOfLaps = (uint)MatLabXrk.GetLapsCount(file);
        var channelNameToIndex = new Dictionary<string, int>();
        var cannels = MatLabXrk.GetChannelsCount(file);
        for (int i = 0;i < cannels; i++)
        {
          var name = MatLabXrk.GetChannelName(file, i);
          channelNameToIndex[name] = i;
        }
        var laps = new Lap[numberOfLaps];
        for (var l = 0; l < numberOfLaps; l++)
        {
          double start, duration;
          MatLabXrk.GetLapInfo(file, l, out start, out duration);
          int rpmIndex = channelNameToIndex["RPM"];
          double[] rpmValues = new double[MatLabXrk.GetLapChannelSamplesCount(file,l,rpmIndex)];
          double[] rpmTime = new double[rpmValues.Length];
          MatLabXrk.GetLapChannelSamples(file, l, rpmIndex, rpmTime, rpmValues, rpmValues.Length);
          var lap = new Lap {
            LapNumber = (uint)l + 1,

          };
          laps[l] = lap;
          // Exhaust Temp, Water Temp, RPM
        }
        var session = new Session { 
          Location = MatLabXrk.GetTrackName(file),
          NumberOfLaps = numberOfLaps,
          // StartAt = 0,
          Laps = laps,
          // HzOfQuantums = 50
        }
            
        ;


        return session;
      } 
      finally
      {
        MatLabXrk.CloseFileWithIndex(file);
      }
    }
  }
}
