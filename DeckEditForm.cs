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
    private PlayingDeckItem playingDeckItem;

    public DeckEditForm(PlayerWindow playerWindow, DeckItem deckItem, PlayingDeckItem playingDeckItem)
    {
      this.playerWindow = playerWindow;
      this.deckItem = deckItem;
      this.playingDeckItem = playingDeckItem;
      InitializeComponent();

      videoPath.Text = deckItem.VideoPath;
      fps.Text = playingDeckItem.VideoCapture.Fps.ToString();
      frameCount.Text = playingDeckItem.VideoCapture.FrameCount.ToString();
      SelectScalingMethod(deckItem.VideoScalingMethod);
      scalePercent.Text = deckItem.ScalePercent.ToString();
      offsetPercent.Text = deckItem.OffsetPercent.ToString();
      alfano6Path.Text = deckItem.Alfano6Path;
      alfano6Offset.Text = deckItem.Alfano6Offset.ToString();
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

    private void setAlfano6OffsetToCurrentFrame_Click(object sender, EventArgs e)
    {
      deckItem.Alfano6Offset = playingDeckItem.CurrentFramePos;
      alfano6Offset.Text = deckItem.Alfano6Offset.ToString();
      playerWindow.RefreshVideo();
    }

    private void alfano6Offset_TextChanged(object sender, EventArgs e)
    {
      deckItem.Alfano6Offset = int.Parse(alfano6Offset.Text);
      playerWindow.RefreshVideo();
    }
  }
}
