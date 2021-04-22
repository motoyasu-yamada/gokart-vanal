using System;
using System.Collections.Generic;

namespace gokart_vanal
{
  [Serializable()]
  public class HistorySettings
  {
    public List<DeckItem> Decks { get; set; } = new List<DeckItem>();
  }

}
