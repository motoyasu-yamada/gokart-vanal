using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace gokart_vanal
{
  public partial class PlayerWindow : Form
  {
    private BindingSource markerBindingSource;
    private PlayingDeck playingDeck { get; } = new PlayingDeck();

    public PlayerWindow()
    {
      InitializeComponent();
      pictureBoxVideo.AllowDrop = true;

      markerBindingSource = new BindingSource(Program.UserSettings.Deck.Markers, "");
      markers.ComboBox.DataSource = markerBindingSource;
      markers.ComboBox.DisplayMember = nameof(Marker.Display);
      markers.ComboBox.ValueMember = nameof(Marker.Display);

      currentFramePosA.TextBox.DataBindings.Add(nameof(currentFramePosA.TextBox.Text), playingDeck.A, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarA.DataBindings.Add(nameof(hScrollBarA.Value), playingDeck.A, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);
      currentFramePosB.TextBox.DataBindings.Add(nameof(currentFramePosB.TextBox.Text), playingDeck.B, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarB.DataBindings.Add(nameof(hScrollBarB.Value), playingDeck.B, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);

      ReloadVideoAndAlfano6();
    }

    private void SetVideoA(DeckItem deckItem, PlayingDeckItem playingDeckItem, string videoPath)
    {
      deckItem.VideoPath = videoPath;
      if (videoPath != null)
      {
        playingDeckItem.VideoCapture = new VideoCapture(videoPath);
      }
      UpdateControlAbilities();
      playingDeckItem.CurrentFramePos = 0;
    }

    private void SetVideoB(DeckItem deckItem, PlayingDeckItem playingDeckItem, string videoPath)
    {
      deckItem.VideoPath = videoPath;
      if (videoPath != null)
      {
        playingDeckItem.VideoCapture = new VideoCapture(videoPath);
      }
      UpdateControlAbilities();
      playingDeckItem.CurrentFramePos = 0;
    }

    private void ReloadVideoAndAlfano6()
    {
      SetVideoA(Program.UserSettings.Deck.A, playingDeck.A, Program.UserSettings.Deck.A.VideoPath);
      SetVideoB(Program.UserSettings.Deck.B, playingDeck.B, Program.UserSettings.Deck.B.VideoPath);
      markerBindingSource.ResetBindings(false);
      markers.Enabled = markerBindingSource.Count > 0;

      SetAlfano6(Program.UserSettings.Deck.A.Alfano6Path, Program.UserSettings.Deck.A, playingDeck.A, jumpToLapA.ComboBox);
      SetAlfano6(Program.UserSettings.Deck.B.Alfano6Path, Program.UserSettings.Deck.B, playingDeck.B, jumpToLapB.ComboBox);

      RefreshVideo();
    }

    public void RefreshVideo()
    {
      pictureBoxVideo.Invalidate();
    }

    private void hScrollBarA_ValueChanged(object sender, EventArgs e)
    {
      RefreshVideo();
    }

    private void hScrollBarB_ValueChanged(object sender, EventArgs e)
    {
      RefreshVideo();
    }

    private void PlayerWindow_Activated(object sender, EventArgs e)
    {
      RefreshVideo();
    }

    private void PlayerWindow_Resize(object sender, EventArgs e)
    {
      RefreshVideo();
    }

    private void pictureBoxVideo_Resize(object sender, EventArgs e)
    {
      RefreshVideo();
    }

    private void MoveFrame(int offset)
    {
      playingDeck.Move(offset);
      pictureBoxVideo.Invalidate();
    }

    private void next1frame_Click(object sender, EventArgs e)
    {
      MoveFrame(1);
    }

    private void next6frames_Click(object sender, EventArgs e)
    {
      MoveFrame(6);
    }

    private void prev1frame_Click(object sender, EventArgs e)
    {
      MoveFrame(-1);
    }

    private void prev6frames_Click(object sender, EventArgs e)
    {
      MoveFrame(-6);
    }

    private void export_Click(object sender, EventArgs e)
    {
      var form = new ExportForm(playingDeck);
      var dr = form.ShowDialog();



    }

    private SolidBrush dragBrush = new SolidBrush(Color.Red);
    private SolidBrush noneBrush = new SolidBrush(Color.DarkGray);
    private SolidBrush nullBrash = new SolidBrush(Color.Black);
    private SolidBrush textBrash = new SolidBrush(Color.White);
    private Font fontTitle = new Font("ＭＳ ゴシック", 32);
    private Font fontDetail = new Font("ＭＳ ゴシック", 16);

    private RectangleF NewSrcRect(Bitmap bitmap, DeckItem deckItem, RectangleF dst)
    {
      var height = bitmap.Height * deckItem.ScalePercent / 100;
      var top = (bitmap.Height - height) / 2 + bitmap.Height * deckItem.OffsetPercent / 100;

      if (deckItem.VideoScalingMethod == VideoScalingMethod.FitToScreen)
      {
        return new RectangleF(0, top, bitmap.Width, height);
      }

      var width = height * dst.Width / dst.Height;
      var left = (bitmap.Width - width) / 2;
      return new RectangleF(left, top, width, height);
    }

    private void PaintDeck(Graphics g, bool dragging, PlayingDeckItem playing, DeckItem deck, RectangleF dst)
    {
      if (dragging)
      {
        g.FillRectangle(dragBrush, dst);
      }
      else
      {
        g.FillRectangle(nullBrash, dst);
        using (var mat = new Mat())
        {
          if (playing.VideoCapture != null)
          {
            playing.VideoCapture.Set(VideoCaptureProperties.PosFrames, playing.CurrentFramePos);
            playing.VideoCapture.Read(mat);
          }

          if (mat.Empty())
          {
            g.FillRectangle(noneBrush, dst);
          }
          else
          {
            using (var image = BitmapConverter.ToBitmap(mat))
            {
              RectangleF src = NewSrcRect(image, deck, dst);
              g.DrawImage(image, dst, src, GraphicsUnit.Pixel);
            }
          }
        }
        if (playing.Session != null)
        {
          var (t, l, q) = playing.Session.GetInfo(playing.CurrentFramePos, playing.VideoCapture.Fps, deck.Alfano6Offset);
          var detail = "";
          if (l != null)
          {
            detail += $"#{l.LapNumber:00}";
          }
          else
          {
            detail += $"#--";
          }
          detail += $", E:{(double)t / 1000:000.00}";
          if (l != null)
          {
            detail += $", T:{l.LapTime:000.00}, RPM:{q.RPM:00000}, Speed:{q.Speed:000.0}, Exaust: {q.ExaustTemperature:000}";
          }
          g.DrawString(detail, fontDetail, textBrash, dst.Left + 10, dst.Top + 10);
        }
      }
    }

    private void pictureBoxVideo_Paint(object sender, PaintEventArgs e)
    {

      var rectA = new RectangleF(0, 0, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      var rectB = new RectangleF(0, pictureBoxVideo.Height / 2, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);

      PaintDeck(e.Graphics, drag == Drag.OnA, playingDeck.A, Program.UserSettings.Deck.A, rectA);
      PaintDeck(e.Graphics, drag == Drag.OnB, playingDeck.B, Program.UserSettings.Deck.B, rectB);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Up:
          MoveFrame(6);
          return true;
        case Keys.Down:
          MoveFrame(-6);
          return true;
        case Keys.Right:
          MoveFrame(1);
          return true;
        case Keys.Left:
          MoveFrame(-1);
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void createMarker_Click(object sender, EventArgs e)
    {
      var m = new MarkerNameModal();
      var dr = m.ShowDialog();
      if (dr == DialogResult.OK)
      {
        markerBindingSource.Add(new Marker(m.value, Int32.Parse(currentFramePosA.Text), Int32.Parse(currentFramePosB.Text)));
        Program.UserSettings.Save();
        markers.SelectedIndex = markers.Items.Count - 1;
        markers.Enabled = true;
        deleteMarker.Enabled = true;
      }
    }

    private void markers_SelectedIndexChanged(object sender, EventArgs e)
    {
      var i = markers.SelectedIndex;
      if (i == -1)
      {
        return;
      }
      var m = (Marker)markerBindingSource[i];
      playingDeck.SetCurrentFrame(new int[] { m.frameA, m.frameB });
      pictureBoxVideo.Invalidate();
    }

    private void deleteMarker_Click(object sender, EventArgs e)
    {
      var i = markers.SelectedIndex;
      markerBindingSource.RemoveAt(i);
      Program.UserSettings.Save();

      if (markerBindingSource.Count == 0)
      {
        markers.Enabled = false;
        deleteMarker.Enabled = false;
      }
    }

    enum Drag { None, OnA, OnB }
    private Drag drag = Drag.None;

    private void pictureBoxVideo_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      var filePath = files[0];
      switch (OnAOrB(e))
      {
        case Drag.OnA:
          if (FileTypeDetector.Detect(filePath) == FileType.Video)
          {
            SetVideoA(Program.UserSettings.Deck.A, playingDeck.A, filePath);

          }
          else
          {
            SetAlfano6(filePath, Program.UserSettings.Deck.A, playingDeck.A, jumpToLapA.ComboBox);
          }
          break;
        case Drag.OnB:
          if (FileTypeDetector.Detect(filePath) == FileType.Video)
          {
            SetVideoB(Program.UserSettings.Deck.B, playingDeck.B, filePath);

          }
          else
          {
            SetAlfano6(filePath, Program.UserSettings.Deck.B, playingDeck.B, jumpToLapB.ComboBox);
          }
          break;
      }
      this.markerBindingSource.Clear();
      Program.UserSettings.Save();

      drag = Drag.None;
      UpdateControlAbilities();

      pictureBoxVideo.Invalidate();
    }

    private void pictureBoxVideo_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        e.Effect = DragDropEffects.All;
      }
      else
      {
        e.Effect = DragDropEffects.None;
      }
      drag = Drag.None;

      Console.WriteLine($"DragEnter {drag}");
      pictureBoxVideo.Invalidate();
    }

    private void pictureBoxVideo_DragOver(object sender, DragEventArgs e)
    {
      drag = OnAOrB(e);
      Console.WriteLine($"DragOver {drag}");
      pictureBoxVideo.Invalidate();
    }

    private void pictureBoxVideo_DragLeave(object sender, EventArgs e)
    {
      drag = Drag.None;
      Console.WriteLine($"DragLeave {drag}");
      pictureBoxVideo.Invalidate();
    }

    private Drag OnAOrB(DragEventArgs e)
    {
      var localY = pictureBoxVideo.PointToClient(new System.Drawing.Point(e.X, e.Y)).Y;
      if (pictureBoxVideo.Height / 2 < localY)
      {
        return Drag.OnB;
      }
      else
      {
        return Drag.OnA;
      }
    }

    private void deckA_Click(object sender, EventArgs e)
    {
      var f = new DeckEditForm(this, Program.UserSettings.Deck.A, playingDeck.A);
      f.ShowDialog();
    }

    private void deckB_Click(object sender, EventArgs e)
    {
      var f = new DeckEditForm(this, Program.UserSettings.Deck.B, playingDeck.B);
      f.ShowDialog();
    }

    private void SetAlfano6(string filePath, DeckItem deck, PlayingDeckItem playing, ComboBox jumpToLap)
    {
      playing.Session = new alfano6.Reader().Read(filePath);
      var sessionIsValid = playing.Session != null;
      if (sessionIsValid)
      {
        deck.Alfano6Path = filePath;
        jumpToLap.Items.Clear();
        foreach (var l in playing.Session.Laps) {
          jumpToLap.Items.Add($"#{l.LapNumber} ({l.LapTime:000.00})");
        }
      }
      else
      {
        jumpToLap.Items.Clear();
      }
      UpdateControlAbilities();
    }

    private void JumpToLap(int lapNumber, DeckItem deck, PlayingDeckItem playing)
    {
      int framePos = playing.Session.GetFramePos(lapNumber, playing.VideoCapture.Fps, deck.Alfano6Offset);
      playing.CurrentFramePos = framePos;
      Console.WriteLine($"lapNumber:{lapNumber}, framePos: {framePos}");
    }

    private void UpdateControlAbilities()
    {
      if (playingDeck.A.VideoCapture != null)
      {
        this.hScrollBarA.Maximum = playingDeck.A.VideoCapture.FrameCount;
        this.hScrollBarA.Enabled = true;
        this.currentFramePosA.Enabled = true;
      }
      else
      {
        this.hScrollBarA.Maximum = 0;
        this.hScrollBarA.Enabled = false;
        this.currentFramePosA.Enabled = false;
      }
      jumpToLapA.Enabled = playingDeck.A.Session != null;

      if (playingDeck.B.VideoCapture != null)
      {
        this.hScrollBarB.Maximum = playingDeck.B.VideoCapture.FrameCount;
        this.hScrollBarB.Enabled = true;
        this.currentFramePosB.Enabled = true;
      }
      else
      {
        this.hScrollBarB.Maximum = 0;
        this.hScrollBarB.Enabled = false;
        this.currentFramePosB.Enabled = false;
      }
      jumpToLapB.Enabled = playingDeck.B.Session != null;
    }

    private void jumpToLapA_SelectedIndexChanged(object sender, EventArgs e)
    {
      JumpToLap(jumpToLapA.SelectedIndex + 1, Program.UserSettings.Deck.A, playingDeck.A);
      RefreshVideo();
    }

    private void jumpToLapB_SelectedIndexChanged(object sender, EventArgs e)
    {
      JumpToLap(jumpToLapB.SelectedIndex + 1, Program.UserSettings.Deck.B, playingDeck.B);
      RefreshVideo();
    }
  }
}
