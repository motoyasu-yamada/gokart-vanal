using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class DeckEditForm : Form
  {
    private PlayerWindow playerWindow;
    private DeckItem deckItem;
    private VideoCapture videoCapture;

    public DeckEditForm(PlayerWindow playerWindow, DeckItem deckItem, VideoCapture videoCapture)
    {
      this.playerWindow = playerWindow;
      this.deckItem = deckItem;
      this.videoCapture = videoCapture;
      InitializeComponent();

      videoPath.Text = deckItem.VideoPath;
      fps.Text = videoCapture.Fps.ToString();
      frameCount.Text = videoCapture.FrameCount.ToString();
      SelectScalingMethod(deckItem.VideoScalingMethod);
      scalePercent.Text = deckItem.ScalePercent.ToString();
      offsetPercent.Text = deckItem.OffsetPercent.ToString();
    }

    private void SelectScalingMethod(VideoScalingMethod method)
    {
      scalingMethod.SelectedIndex = VideoScalingMethod.FitToScreen == method ? 0 : 1;
    }

    private void scalingMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      deckItem.VideoScalingMethod = scalingMethod.SelectedIndex == 0 ? VideoScalingMethod.FitToScreen : VideoScalingMethod.SameRatio;
      playerWindow.RefreshVideo();
    }

    private void scalePercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deckItem.ScalePercent = int.Parse(scalePercent.Text);
      playerWindow.RefreshVideo();
    }

    private void offsetPercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deckItem.OffsetPercent = int.Parse(offsetPercent.Text);
      playerWindow.RefreshVideo();
    }

    private void DeckEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.UserSettings.Save();
    }
  }
}
