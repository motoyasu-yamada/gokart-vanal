using System;

namespace gokart_vanal
{
  [Serializable]
  public class DeckOptions
  {
    public ArrangeMode ArrangeMode { get; set; } = ArrangeMode.Vertical;

    public DeckItem A { get; set; } = new DeckItem();

    public DeckItem B { get; set; } = new DeckItem();
  }

}
