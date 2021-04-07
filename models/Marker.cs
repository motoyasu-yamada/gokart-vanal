using System;
using System.Xml.Serialization;

namespace gokart_vanal
{
  [Serializable()]
  public class Marker
  {
    public string Name { get; set; }
    public int Frame { get; set; }

    [XmlIgnore]
    public string Display
    {
      get
      {
        return $"{Name} ({Frame})";
      }
    }

    public Marker Clone()
    {
      return new Marker { Name = this.Name, Frame = this.Frame };
    }
  }
}
