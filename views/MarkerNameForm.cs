using System;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class MarkerNameModal : Form
  {
    public string MarkerName { get; private set; }
    public bool CreateOtherMaker { get; private set; }

    public MarkerNameModal()
    {
      InitializeComponent();
    }

    private void create_Click(object sender, EventArgs e)
    {
      this.MarkerName = markerName.Text;
      this.CreateOtherMaker = createOtherMarker.Checked;
    }
  }
}
