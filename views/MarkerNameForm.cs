using System;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class MarkerNameModal : Form
  {
    public string value { get; private set; }

    public MarkerNameModal()
    {
      InitializeComponent();
    }

    private void create_Click(object sender, EventArgs e)
    {
      this.value = markerName.Text;
    }
  }
}
