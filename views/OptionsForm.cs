using gokart_vanal.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gokart_vanal.views
{
  public partial class OptionsForm : Form
  {
    private MainForm playerWindow;
    private Options options;
    public OptionsForm(MainForm playerWindow, Options options)
    {
      this.playerWindow = playerWindow;
      this.options = options;
      InitializeComponent();
      UpdateControls();
    }

    private void UpdateControls()
    {
      var e = GridType.None;
      this.gridTypeList.SelectedIndex = options.GridType.ToIndex();
    }

    private void gridTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
      options.GridType = GridTypeStatic.FromIndex(this.gridTypeList.SelectedIndex);
      playerWindow.RefreshVideo();
    }
  }
}
