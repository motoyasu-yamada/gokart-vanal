using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gokart_vanal.alfano6
{
  public class Reader
  {
    public Session Read(string zipPath)
    {
      if (zipPath == null)
      {
        return null;
      }
      Session session = null;
      var ql = new Dictionary<uint, LapQuantum50hz[]>();
      using (var zip = ZipFile.OpenRead(zipPath))
      {
        foreach (ZipArchiveEntry entry in zip.Entries)
        {
          var csv = LoadText(entry);
          if (entry.FullName.StartsWith("SN"))
          {
            session = ParseIndexFile(csv);
            continue;
          }
          Match match = Regex.Match(entry.FullName, "^LAP_([0-9]+)_");
          if (match.Success)
          {
            var lapNumber = uint.Parse(match.Groups[1].Value);
            var quantumns = ParseLapFile(csv);
            Console.WriteLine($"**** lapNumber:{lapNumber},quantumns:{quantumns.Count()}");
            ql[lapNumber] = quantumns.ToArray();
            continue;
          }
        }
      }
      if (session != null)
      {
        foreach (var kv in ql)
        {
          uint lapNo = kv.Key;
          if (session.Laps.Length < lapNo)
          {
            // PIT IN
            Console.WriteLine($"**** lapNumber:{lapNo}, PITIN");
            continue;
          }
          session.Laps[lapNo-1].Quantums = kv.Value.ToArray();
          Console.WriteLine($"**** lapNumber:{lapNo},quantumns:{session.Laps[lapNo - 1].Quantums.Count()}");
        }
      }
      return session;
    }

    public string LoadText(ZipArchiveEntry entry)
    {
      using (var reader = new StreamReader(entry.Open()))
      {
        return reader.ReadToEnd();
      }

    }

    public Session ParseIndexFile(string csv)
    {
      var (data, skipped) = CsvParser.Parse(csv, 1);
      var headerLine = skipped[0];
      var header = headerLine.Split(',');
      var dateTimeString = header[0] + " " + header[1];
      var startAt = DateTime.Parse(dateTimeString, new CultureInfo("fr-FR"));
      var numberOfLap = uint.Parse(header[2]);
      var loc = header[4];

      return new Session
      {
        Location = loc,
        NumberOfLaps = numberOfLap,
        StartAt = startAt,
        Laps = data.Select(d => Lap.Parse(d)).ToArray()
      };
    }

    public List<LapQuantum50hz> ParseLapFile(string csv)
    {
      var (data, skipped) = CsvParser.Parse(csv, 0);
      var list = new List<LapQuantum50hz>();
      foreach (var d in data)
      {
        var q5 = LapQuantum50hz.Parse(d);
        foreach (var q1 in q5)
        {
          list.Add(q1);
        }
      }
      return list;
    }

  }
}
