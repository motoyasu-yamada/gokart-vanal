using System.Windows.Forms;

namespace gokart_vanal
{
  public class FrameComponents
  {
    public System.Drawing.Brush DragBrush { get; set; }
    public ToolStripButton Edit { get; set; }
    public ToolStripComboBox JumpToLap { get; set; }
    public ToolStripComboBox Markers { get; set; }
    public BindingSource MarkerBindingSource { get; set; }
    public ToolStripButton CreateMarker { get; set; }
    public ToolStripTextBox CurrentFramePos { get; set; }
    public HScrollBar VideoFrameBar { get; set; }
    public ContextMenuStrip MoveMenu { get; set; }
    public Button MoveMenuButton { get; set; }
  }
}
