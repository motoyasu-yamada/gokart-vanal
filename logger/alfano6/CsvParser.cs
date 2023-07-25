using System.Collections.Generic;
using System.Linq;

namespace gokart_vanal.alfano6
{
  public class CsvParser
  {
    public static (List<Dictionary<string, string>>, string[] skipeed) Parse(string csv, int linesToSkip = 0)
    {
      string[] lines = csv.Split('\n');

      int numberOfLines = lines.Length;

      string fieldNames = lines[linesToSkip];
      string[] fields = fieldNames.Split(',');

      int numberOfData = numberOfLines - 1 - linesToSkip;
      var r = new List<Dictionary<string, string>>();
      for (int i = 0; i < numberOfData; i++)
      {
        string line = lines[i + 1 + linesToSkip];
        if (line.Length == 0)
        {
          continue;
        }
        string[] columns = line.Split(',');
        var d = new Dictionary<string, string>();
        foreach (var (column, index) in columns.Select((c, index) => (c, index)))
        {
          d[fields[index]] = column;
        }
        r.Add(d);
      }
      string[] skipped = lines.Take(linesToSkip).ToArray();
      return (r, skipped);

    }

  }
}
