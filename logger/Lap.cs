
namespace gokart_vanal.logger
{

  public class Lap
  {
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
