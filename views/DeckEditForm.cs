using System;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class DeckEditForm : Form
  {
    private MainForm playerWindow;
    private Deck deck;

    public DeckEditForm(MainForm playerWindow, Deck deck)
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
      videoPath.Text = deck.DeckItem.VideoPath;
      fps.Text = deck.PlayingDeckItem.VideoCapture != null ? deck.PlayingDeckItem.VideoCapture.Fps.ToString() : "-";
      frameCount.Text = deck.PlayingDeckItem.VideoCapture != null ? deck.PlayingDeckItem.VideoCapture.FrameCount.ToString() : "-";
      SelectScalingMethod(deck.DeckItem.VideoScalingMethod);
      scalePercent.Text = deck.DeckItem.ScalePercent.ToString();
      offsetPercent.Text = deck.DeckItem.OffsetPercent.ToString();
      alfano6Path.Text = deck.DeckItem.Alfano6Path;
      alfano6Offset.Text = deck.DeckItem.Alfano6Offset.ToString();
    }

    private void SelectScalingMethod(VideoScalingMethod method)
    {
      scalingMethod.SelectedIndex = VideoScalingMethod.FitToScreen == method ? 0 : 1;
    }

    private void scalingMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.DeckItem.VideoScalingMethod = scalingMethod.SelectedIndex == 0 ? VideoScalingMethod.FitToScreen : VideoScalingMethod.SameRatio;
      playerWindow.RefreshVideo();
    }

    private void scalePercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.DeckItem.ScalePercent = int.Parse(scalePercent.Text);
      playerWindow.RefreshVideo();
    }

    private void offsetPercent_SelectedIndexChanged(object sender, EventArgs e)
    {
      deck.DeckItem.OffsetPercent = int.Parse(offsetPercent.Text);
      playerWindow.RefreshVideo();
    }

    private void DeckEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.UserSettings.Save();
    }

    private void setAlfano6OffsetToCurrentFrame_Click(object sender, EventArgs e)
    {
      deck.DeckItem.Alfano6Offset = deck.PlayingDeckItem.CurrentFramePos;
      alfano6Offset.Text = deck.DeckItem.Alfano6Offset.ToString();
      playerWindow.RefreshVideo();
    }

    private void alfano6Offset_TextChanged(object sender, EventArgs e)
    {
      deck.DeckItem.Alfano6Offset = int.Parse(alfano6Offset.Text);
      playerWindow.RefreshVideo();
    }

    private void detachVideo_Click(object sender, EventArgs e)
    {
      deck.DeckItem.VideoPath = null;
      deck.DeckItem.Alfano6Path = null;
      deck.PlayingDeckItem.VideoCapture = null;
      deck.PlayingDeckItem.Session = null;
      playerWindow.RefreshVideo();
      UpdateControls();
    }

    private void detachAlfano6_Click(object sender, EventArgs e)
    {
      deck.DeckItem.Alfano6Path = null;
      deck.PlayingDeckItem.Session = null;
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
