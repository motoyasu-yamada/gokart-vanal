using gokart_vanal.models;
using System;
using System.Windows.Forms;

namespace gokart_vanal.views
{
  public partial class OptionsForm : Form
  {
    private MainForm playerWindow;
    private MainSettings options;
    public OptionsForm(MainForm playerWindow, MainSettings options)
    {
      this.playerWindow = playerWindow;
      this.options = options;
      InitializeComponent();
      UpdateControls();
    }

    private void UpdateControls()
    {
      this.gridTypeList.SelectedIndex = options.GridType.ToIndex();
    }

    private void gridTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
      options.GridType = GridTypeStatic.FromIndex(this.gridTypeList.SelectedIndex);
      playerWindow.RefreshVideo();
    }
  }
}
