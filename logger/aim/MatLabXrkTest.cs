using System.Diagnostics;

namespace gokart_vanal
{
  internal static class MatLabXrkTest
  {

    internal static void Test()
    {
      Debug.WriteLine($"GetLibraryDate: {MatLabXrk.GetLibraryDate()}");
      Debug.WriteLine($"GetLibraryTime: {MatLabXrk.GetLibraryTime()}");

      var path = "C:\\workspace\\gokart-vanal\\bin\\Debug\\test.xrk";
      var file = MatLabXrk.OpenFile(path);
      if (file < 0)
      {
        Debug.WriteLine($"****** エラー: ファイル '{path}'をエラー理由[{file}]により読み込みませんでした");
      }
      if (file == 0)
      {
        Debug.WriteLine($"****** エラー: ファイル '{path}'を読み込みましたが、解析できませんでした");
      }
      if (0 < file)
      {
        Debug.WriteLine($"****** file: {file} 読み込めました");

        Debug.WriteLine($"GetVehicleName: {MatLabXrk.GetVehicleName(file)}");
        Debug.WriteLine($"GetTrackName: {MatLabXrk.GetTrackName(file)}");
        var channels = MatLabXrk.GetChannelsCount(file);
        Debug.WriteLine($"+++ {channels} channels");
        for (var i = 0; i < channels; i++)
        {
          Debug.WriteLine($"[{i}] {MatLabXrk.GetChannelName(file, i)}, {MatLabXrk.GetChannelUnits(file, i)}");
        }

        var laps = MatLabXrk.GetLapsCount(file);
        Debug.WriteLine($"+++ {laps} laps");
        for (var i = 0; i < laps; i++)
        {
          double start, duration;
          MatLabXrk.GetLapInfo(file, i, out start, out duration);
          Debug.WriteLine($"Lap: {i}: {start},{duration}");
          for (var c = 0; c < channels; c++)
          {
            int count = MatLabXrk.GetLapChannelSamplesCount(file, i, c);
            double[] times = new double[count];
            double[] values = new double[count];
            MatLabXrk.GetLapChannelSamples(file, i, c, times, values, count);
            Debug.WriteLine($"Lap: {i}[{c}]: {times[0]},{values[0]}-{times[count - 1]},{values[count - 2]} ");

          }
        }
        var r = MatLabXrk.CloseFileWithIndex(file);
        Debug.WriteLine($"***** close_file_i: {r}");
      }

    }
  }
}