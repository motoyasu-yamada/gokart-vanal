using System;

namespace gokart_vanal
{
  [Serializable()]
  public class Marker
  {
    public string name { get; set; }
    public int frameA { get; set; }
    public int frameB { get; set; }

    public Marker()
    {
      this.name = "";
    }

    public Marker(string name, int frameA, int frameB)
    {
      this.name = name;
      this.frameA = frameA;
      this.frameB = frameB;
    }

    public string Display
    {
      get
      {
        return $"{this.name} ({this.frameA}/{this.frameB})";
      }
    }

  }
}
