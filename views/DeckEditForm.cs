using System;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class DeckEditForm : Form
  {
    private MainForm playerWindow;
    private Frame deck;

    public DeckEditForm(MainForm playerWindow, Frame deck)
    {
      this.playerWindow = playerWindow;
      this.deck = deck;

      InitializeComponent();
      this.markers.DataSource = deck.Components.MarkerBindingSource;
      this.markers.DisplayMember = nameof(Marker.Display);
      this.markers.ValueMember = nameof(Marker.Display);

      UpdateControls();
    }

    private void UpdateControls()
    {
      videoPath.Text = deck.VideoData.VideoPath;
      fps.Text = deck.PlaybackData.VideoCapture != null ? deck.PlaybackData.VideoCapture.Fps.ToString() : "-";
      frameCount.Text = deck.PlaybackData.VideoCapture != null ? deck.PlaybackData.VideoCapture.FrameCount.ToString() : "-";
      SelectScalingMethod(deck.VideoData.VideoScalingMethod);
      scalePercent.Text = deck.VideoData.ScalePercent.ToString();
      offsetPercent.Text = deck.VideoData.OffsetPercent.ToString();
      alfano6Path.Text = deck.VideoData.Alfano6Path;
      alfano6Offset.Text = deck.VideoData.Alfano6Offset.ToString();
    }

    private void SelectScalingMethod(VideoScalingMethod method)
    {
      scalingMethod.SelectedIndex = VideoScalingMethod.FitToScreen == method ? 0 : 1;
    }

    private void scalingMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.VideoData.VideoScalingMethod = scalingMethod.SelectedIndex == 0 ? VideoScalingMethod.FitToScreen : VideoScalingMethod.SameRatio;
      playerWindow.RefreshVideo();
    }

    private void scalePercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.VideoData.ScalePercent = int.Parse(scalePercent.Text);
      playerWindow.RefreshVideo();
    }

    private void offsetPercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.VideoData.OffsetPercent = int.Parse(offsetPercent.Text);
      playerWindow.RefreshVideo();
    }

    private void DeckEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.UserSettings.Save();
    }

    private void setAlfano6OffsetToCurrentFrame_Click(object sender, EventArgs e)
    {
      deck.VideoData.Alfano6Offset = deck.PlaybackData.CurrentFramePos;
      alfano6Offset.Text = deck.VideoData.Alfano6Offset.ToString();
      playerWindow.RefreshVideo();
    }

    private void alfano6Offset_TextChanged(object sender, EventArgs e)
    {
      deck.VideoData.Alfano6Offset = int.Parse(alfano6Offset.Text);
      playerWindow.RefreshVideo();
    }

    private void detachVideo_Click(object sender, EventArgs e)
    {
      deck.VideoData.VideoPath = null;
      deck.VideoData.Alfano6Path = null;
      deck.PlaybackData.VideoCapture = null;
      deck.PlaybackData.Session = null;
      playerWindow.RefreshVideo();
      UpdateControls();
    }

    private void detachAlfano6_Click(object sender, EventArgs e)
    {
      deck.VideoData.Alfano6Path = null;
      deck.PlaybackData.Session = null;
      playerWindow.RefreshVideo();
      UpdateControls();
    }

    private void deleteMarker_Click(object sender, EventArgs e)
    {
      deck.Components.MarkerBindingSource.RemoveCurrent();
    }

    private void upMarker_Click(object sender, EventArgs e)
    {
      var mbs = deck.Components.MarkerBindingSource;
      var i = markers.SelectedIndex;
      var item = mbs[i];
      mbs.RemoveAt(i);
      mbs.Insert(i - 1, item);
      markers.SelectedIndex = i - 1;
    }

    private void downMarker_Click(object sender, EventArgs e)
    {
      var mbs = deck.Components.MarkerBindingSource;
      var i = markers.SelectedIndex;
      var item = mbs[i];
      mbs.RemoveAt(i);
      mbs.Insert(i + 1, item);
      markers.SelectedIndex = i + 1;
    }

    private void markers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (markers.SelectedIndex == -1)
      {
        deleteMarker.Enabled = false;
        upMarker.Enabled = false;
        downMarker.Enabled = false;
        return;
      }
      deleteMarker.Enabled = true;
      upMarker.Enabled = 0 < markers.SelectedIndex;
      downMarker.Enabled = markers.SelectedIndex < markers.Items.Count - 1;
    }
  }
}
