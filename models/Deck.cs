using System.Windows.Forms;

namespace gokart_vanal
{
  public class Deck
  {
    public DeckType DeckType { get; set; }
    public DeckItem DeckItem
    {
      get { return DeckType == DeckType.A ? Program.UserSettings.Deck.A : Program.UserSettings.Deck.B; }
      set { if (DeckType == DeckType.A) { Program.UserSettings.Deck.A = value; } else { Program.UserSettings.Deck.B = value; } }
    }
    public PlayingDeckItem PlayingDeckItem { get; set; } = new PlayingDeckItem();
    public DeckComponents Components { get; set; }
  }

  public enum DeckType { A, B };

  public class DeckComponents
  {
    public System.Drawing.Brush DragBrush { get; set; }
    public ToolStripButton Edit { get; set; }
    public ToolStripComboBox JumpToLap { get; set; }
    public ToolStripComboBox Markers { get; set; }
    public BindingSource MarkerBindingSource { get; set; }
    public ToolStripButton CreateMarker { get; set; }
    public ToolStripTextBox CurrentFramePos { get; set; }
    public HScrollBar VideoFrameBar { get; set; }
  }
}
