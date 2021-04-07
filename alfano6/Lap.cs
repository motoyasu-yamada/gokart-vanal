using System.Collections.Generic;

namespace gokart_vanal.alfano6
{

  public class Lap
  {
    public static Lap Parse(Dictionary<string, string> data)
    {
      return new Lap
      {
        LapNumber = uint.Parse(data["lap"]),
        LapTime = decimal.Parse(data["time lap"]) / 1000,
        MinRPM = uint.Parse(data["Min RPM"]),
        MaxRPM = uint.Parse(data["Max RPM"]),
        MinSpeed = decimal.Parse(data["Min Speed GPS"]) / 10,
        MaxSpeed = decimal.Parse(data["Max Speed GPS"]) / 10,
        MinExaustTemperature = decimal.Parse(data["Min T2"]) / 10,
        MaxExaustTemperature = decimal.Parse(data["Max T2"]) / 10,
      };
    }

    public uint LapNumber { get; set; }
    public decimal LapTime { get; set; }
    public uint MaxRPM { get; set; }
    public uint MinRPM { get; set; }
    public decimal MinSpeed { get; set; }
    public decimal MaxSpeed { get; set; }
    public decimal MinExaustTemperature { get; set; }
    public decimal MaxExaustTemperature { get; set; }

    public LapQuantum50hz[] Quantums { get; set; }
  }
}
