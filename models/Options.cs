using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gokart_vanal.models
{
  [Serializable()]
  public class Options
  {
    public GridType GridType { get; set; } = GridType.None;

    public ExportOptions Export { get; set; } = new ExportOptions();

    public DeckOptions Deck { get; set; } = new DeckOptions();

  }
}
