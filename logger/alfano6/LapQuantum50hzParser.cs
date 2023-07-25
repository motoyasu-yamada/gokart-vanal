using gokart_vanal.logger;
using System.Collections.Generic;

namespace gokart_vanal.alfano6
{
  public class LapQuantum50hzParser
  {
    public static LapQuantum50hz[] Parse(Dictionary<string, string> data)
    {
      var speed = decimal.Parse(data["Speed GPS"]) / 10;
      var temp = decimal.Parse(data["T2"]) / 10;
      var or = decimal.Parse(data["Orientation"]) / 100;
      var lat = uint.Parse(data["Lat."]);
      var lon = uint.Parse(data["Lon."]);
      var alt = uint.Parse(data["Altitude"]);
      return new LapQuantum50hz[]
      {
        new LapQuantum50hz{ RPM = uint.Parse(data["RPM 1 50Hz"]), Speed= speed,ExaustTemperature =temp,Orientation = or, Latitude =lat,Longtitude=lon,Altitude = alt },
        new LapQuantum50hz{ RPM = uint.Parse(data["RPM 2 50Hz"]), Speed= speed,ExaustTemperature =temp,Orientation = or, Latitude =lat,Longtitude=lon,Altitude = alt },
        new LapQuantum50hz{ RPM = uint.Parse(data["RPM 3 50Hz"]), Speed= speed,ExaustTemperature =temp,Orientation = or, Latitude =lat,Longtitude=lon,Altitude = alt },
        new LapQuantum50hz{ RPM = uint.Parse(data["RPM 4 50Hz"]), Speed= speed,ExaustTemperature =temp,Orientation = or, Latitude =lat,Longtitude=lon,Altitude = alt },
        new LapQuantum50hz{ RPM = uint.Parse(data["RPM 5 50Hz"]), Speed= speed,ExaustTemperature =temp,Orientation = or, Latitude =lat,Longtitude=lon,Altitude = alt }
      };
    }
  }
}