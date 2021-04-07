using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class MainForm : Form
  {
    enum Drag { None, OnA, OnB }


    private Deck A = new Deck { DeckType = DeckType.A, Components = new DeckComponents { DragBrush = new SolidBrush(Color.Red) } };
    private Deck B = new Deck { DeckType = DeckType.B, Components = new DeckComponents { DragBrush = new SolidBrush(Color.Blue) } };

    private SolidBrush noneBrush = new SolidBrush(Color.DarkGray);
    private SolidBrush nullBrash = new SolidBrush(Color.Black);
    private SolidBrush textBrash = new SolidBrush(Color.White);
    private Font fontDetail = new Font("ＭＳ ゴシック", 16);
    private Drag drag = Drag.None;

    public MainForm()
    {
      InitializeComponent();
      pictureBoxVideo.AllowDrop = true;

      InitializeDeckComponent(A);
      InitializeDeckComponent(B);

      ReloadVideoAndAlfano6();
    }

    private static T GetToolStripItem<T>(DeckType deckType, T toolStripItemA) where T : ToolStripItem
{
      Debug.Assert(toolStripItemA.Name.EndsWith("A"));
      if (deckType == DeckType.A)
      {
        return toolStripItemA;
      }
      var nameB = toolStripItemA.Name.Substring(0, toolStripItemA.Name.Length - 1) + "B";
      return (T)toolStripItemA.GetCurrentParent().Items.Find(nameB, false)[0];
    }

    private static T GetControl<T>(DeckType deckType, T controlA) where T : Control
    {
      Debug.Assert(controlA.Name.EndsWith("A"));
      if (deckType == DeckType.A)
      {
        return controlA;
      }
      var nameB = controlA.Name.Substring(0, controlA.Name.Length - 1) + "B";
      return (T)controlA.Parent.Controls.Find(nameB, false)[0];
    }

    private void InitializeDeckComponent(Deck deck)
    {
      var deckType = deck.DeckType;
      deck.Components.Edit = GetToolStripItem(deckType, deckA);
      deck.Components.JumpToLap = GetToolStripItem(deckType, jumpToLapA);

      var markers = deck.Components.Markers = GetToolStripItem(deckType, markersA);
      markers.ComboBox.DataSource = deck.Components.MarkerBindingSource = new BindingSource(deck.DeckItem.Markers, "");
      markers.ComboBox.DisplayMember = nameof(Marker.Display);
      markers.ComboBox.ValueMember = nameof(Marker.Display);
      deck.Components.CreateMarker = GetToolStripItem(deckType, createMarkerA);

      deck.Components.CurrentFramePos = GetToolStripItem(deckType, currentFramePosA);
      deck.Components.CurrentFramePos.TextBox.DataBindings.Add(nameof(TextBox.Text), deck.PlayingDeckItem, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);

      deck.Components.VideoFrameBar = GetControl(deckType, hScrollBarA);
      deck.Components.VideoFrameBar.DataBindings.Add(nameof(HScrollBar.Value), deck.PlayingDeckItem, nameof(PlayingDeckItem.CurrentFramePos), true, DataSourceUpdateMode.OnPropertyChanged);

    }

    private void UpdateControlAbilities(Deck deck)
    {
      var c = deck.Components;
      var playingDeckItem = deck.PlayingDeckItem;
      if (playingDeckItem.VideoCapture != null)
      {
        c.Edit.Enabled = true;
        c.JumpToLap.Enabled = playingDeckItem.Session != null;
        c.Markers.Enabled = c.MarkerBindingSource.Count > 0;
        c.CreateMarker.Enabled = true;
        c.CurrentFramePos.Enabled = true;
        c.VideoFrameBar.Maximum = playingDeckItem.VideoCapture.FrameCount;
        c.VideoFrameBar.Enabled = true;
      }
      else
      {
        c.Edit.Enabled = false;
        c.JumpToLap.Enabled = false;
        c.Markers.Enabled = false;
        c.CreateMarker.Enabled = false;
        c.CurrentFramePos.Enabled = false;
        c.VideoFrameBar.Maximum = 0;
        c.VideoFrameBar.Enabled = false;
      }
    }

    private void UpdateControlAbilities()
    {
      UpdateControlAbilities(A);
      UpdateControlAbilities(B);
    }

    private void SetVideo(Deck deck, string videoPath)
    {
      deck.DeckItem.VideoPath = videoPath;
      if (videoPath != null)
      {
        deck.PlayingDeckItem.VideoCapture = new VideoCapture(videoPath);
      }
      deck.PlayingDeckItem.CurrentFramePos = 0;
      deck.Components.MarkerBindingSource.ResetBindings(false);
      UpdateControlAbilities();
    }

    private void SetAlfano6(Deck deck, string filePath)
    {
      deck.PlayingDeckItem.Session = new alfano6.Reader().Read(filePath);
      var sessionIsValid = deck.PlayingDeckItem.Session != null;
      if (sessionIsValid)
      {
        deck.DeckItem.Alfano6Path = filePath;
        deck.Components.JumpToLap.Items.Clear();
        foreach (var l in deck.PlayingDeckItem.Session.Laps)
        {
          deck.Components.JumpToLap.Items.Add($"#{l.LapNumber} ({l.LapTime:000.00})");
        }
      }
      else
      {
        deck.Components.JumpToLap.Items.Clear();
      }
      UpdateControlAbilities();
    }


    private void ReloadVideoAndAlfano6()
    {
      SetVideo(A, Program.UserSettings.Deck.A.VideoPath);
      SetVideo(B, Program.UserSettings.Deck.B.VideoPath);

      SetAlfano6(A, Program.UserSettings.Deck.A.Alfano6Path);
      SetAlfano6(B, Program.UserSettings.Deck.B.Alfano6Path);

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
      A.PlayingDeckItem.CurrentFramePos += offset;
      B.PlayingDeckItem.CurrentFramePos += offset;
      RefreshVideo();
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
      var form = new ExportForm(A.PlayingDeckItem, B.PlayingDeckItem);
      var dr = form.ShowDialog();
    }


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

    private void PaintDeck(Graphics g, bool dragging, Deck deck, RectangleF dst)
    {
      if (dragging)
      {
        g.FillRectangle(deck.Components.DragBrush, dst);
      }
      else
      {
        g.FillRectangle(nullBrash, dst);
        using (var mat = new Mat())
        {
          if (deck.PlayingDeckItem.VideoCapture != null)
          {
            deck.PlayingDeckItem.VideoCapture.Set(VideoCaptureProperties.PosFrames, deck.PlayingDeckItem.CurrentFramePos);
            deck.PlayingDeckItem.VideoCapture.Read(mat);
          }

          if (mat.Empty())
          {
            g.FillRectangle(noneBrush, dst);
          }
          else
          {
            using (var image = BitmapConverter.ToBitmap(mat))
            {
              RectangleF src = NewSrcRect(image, deck.DeckItem, dst);
              g.DrawImage(image, dst, src, GraphicsUnit.Pixel);
            }
          }
        }
        if (deck.PlayingDeckItem.Session != null)
        {
          var (t, l, q) = deck.PlayingDeckItem.Session.GetInfo(deck.PlayingDeckItem.CurrentFramePos, deck.PlayingDeckItem.VideoCapture.Fps, deck.DeckItem.Alfano6Offset);
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

      PaintDeck(e.Graphics, drag == Drag.OnA, A, rectA);
      PaintDeck(e.Graphics, drag == Drag.OnB, B, rectB);
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

    private void CreateMarker(Deck deck)
    {
      var c = deck.Components;
      var m = new MarkerNameModal();
      var dr = m.ShowDialog();
      if (dr == DialogResult.OK)
      {
        c.MarkerBindingSource.Add(new Marker { Name = m.value, Frame = deck.PlayingDeckItem.CurrentFramePos });
        c.Markers.SelectedIndex = c.Markers.Items.Count - 1;
        UpdateControlAbilities();
        Program.UserSettings.Save();
      }
    }

    private void SelectMarker(Deck deck)
    {
      var i = deck.Components.Markers.SelectedIndex;
      if (i == -1)
      {
        return;
      }
      var m = (Marker)deck.Components.MarkerBindingSource[i];
      deck.PlayingDeckItem.CurrentFramePos = m.Frame;
      pictureBoxVideo.Invalidate();
    }

    private void createMarkerA_Click(object sender, EventArgs e)
    {
      CreateMarker(A);
    }

    private void markersA_SelectedIndexChanged(object sender, EventArgs e)
    {
      SelectMarker(A);
    }
    private void createMarkerB_Click(object sender, EventArgs e)
    {
      CreateMarker(B);
    }

    private void markersB_SelectedIndexChanged(object sender, EventArgs e)
    {
      SelectMarker(B);
    }

    private void pictureBoxVideo_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      var filePath = files[0];
      switch (OnAOrB(e))
      {
        case Drag.OnA:
          if (FileTypeDetector.Detect(filePath) == FileType.Video)
          {
            SetVideo(A, filePath);

          }
          else
          {
            SetAlfano6(A, filePath);
          }
          break;
        case Drag.OnB:
          if (FileTypeDetector.Detect(filePath) == FileType.Video)
          {
            SetVideo(B, filePath);

          }
          else
          {
            SetAlfano6(B, filePath);
          }
          break;
      }
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
      var f = new DeckEditForm(this, A);
      f.ShowDialog();
      UpdateControlAbilities();
    }

    private void deckB_Click(object sender, EventArgs e)
    {
      var f = new DeckEditForm(this, B);
      f.ShowDialog();
      UpdateControlAbilities();
    }

    private void JumpToLap(Deck deck)
    {
      var lapNumber = deck.Components.JumpToLap.SelectedIndex + 1;
      var framePos = deck.PlayingDeckItem.Session.GetFramePos(lapNumber, deck.PlayingDeckItem.VideoCapture.Fps, deck.DeckItem.Alfano6Offset);
      deck.PlayingDeckItem.CurrentFramePos = framePos;
      RefreshVideo();
    }

    private void jumpToLapA_SelectedIndexChanged(object sender, EventArgs e)
    {
      JumpToLap(A);
    }

    private void jumpToLapB_SelectedIndexChanged(object sender, EventArgs e)
    {
      JumpToLap(B);
    }

  }
}
