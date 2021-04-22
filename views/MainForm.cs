using gokart_vanal.models;
using gokart_vanal.views;
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
      foreach (var i in MoveMenu)
      {
        moveMenu.DropDownItems.Add(i.Display);
      }
      InitializeDeckComponent(A);
      InitializeDeckComponent(B);

      ResetDeck(A);
      ResetDeck(B);

      RefreshVideo();
      UpdateControlAbilities();
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

      deck.Components.MoveMenuButton = GetControl(deckType, moveMenuButtonA);
      deck.Components.MoveMenu = deckType == DeckType.A ? moveMenuA : moveMenuB;
      foreach (var i in MoveMenu)
      {
        deck.Components.MoveMenu.Items.Add(i.Display);
      }
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
        c.MoveMenu.Enabled = true;
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
        c.MoveMenu.Enabled = false;
      }
    }

    private void UpdateControlAbilities()
    {
      UpdateControlAbilities(A);
      UpdateControlAbilities(B);
      if (A.PlayingDeckItem.VideoCapture != null && B.PlayingDeckItem.VideoCapture != null)
      {
        moveMenu.Enabled = true;
        moveNext1Frame.Enabled = true;
        moveNext100ms.Enabled = true;
        movePrev1Frame.Enabled = true;
        movePrev100ms.Enabled = true;
        export.Enabled = true;
      }
      else
      {
        moveMenu.Enabled = false;
        moveNext1Frame.Enabled = false;
        moveNext100ms.Enabled = false;
        movePrev1Frame.Enabled = false;
        movePrev100ms.Enabled = false;
        export.Enabled = false;
      }
    }

    private void ResetDeck(Deck deck)
    {
      if (deck.DeckItem.VideoPath != null)
      {
        deck.PlayingDeckItem.VideoCapture = new VideoCapture(deck.DeckItem.VideoPath);
      }

      deck.Components.MarkerBindingSource.ResetBindings(false);

      deck.PlayingDeckItem.Session = null;
      if (deck.DeckItem.Alfano6Path != null)
      {
        deck.PlayingDeckItem.Session = new alfano6.Reader().Read(deck.DeckItem.Alfano6Path);
      }

      var sessionIsValid = deck.PlayingDeckItem.Session != null;
      if (sessionIsValid)
      {
        deck.PlayingDeckItem.CurrentFramePos = deck.DeckItem.Alfano6Offset;
      }
      else
      {
        deck.DeckItem.Alfano6Path = null;
        deck.PlayingDeckItem.CurrentFramePos = 0;
      }

      if (sessionIsValid)
      {
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
    public class MoveMenuItem
    {
      public string Display { get; set; }
      public int OffsetSecond { get; set; }
    }

    public MoveMenuItem[] MoveMenu { get; private set; } = new MoveMenuItem[] {

      new MoveMenuItem { Display = "3秒進む", OffsetSecond = 3 },
      new MoveMenuItem { Display = "10秒進む", OffsetSecond = 10 },
      new MoveMenuItem { Display = "30秒進む", OffsetSecond = 30 },
      new MoveMenuItem { Display = "60秒進む", OffsetSecond = 60 },
      new MoveMenuItem { Display = "180秒進む", OffsetSecond = 180 },
      new MoveMenuItem { Display = "-", OffsetSecond = 0 },
      new MoveMenuItem { Display = "3秒戻る", OffsetSecond = -3 },
      new MoveMenuItem { Display = "10秒戻る", OffsetSecond = -10 },
      new MoveMenuItem { Display = "30秒戻る", OffsetSecond = -30 },
    };

    private void SelectMoveMenu(Deck deck, ToolStripItemClickedEventArgs e)
    {
      var i = deck.Components.MoveMenu.Items.IndexOf(e.ClickedItem);
      if (i == -1 || deck.PlayingDeckItem.VideoCapture == null)
      {
        return;
      }
      int offset = MoveMenu[i].OffsetSecond;
      int newPos = deck.PlayingDeckItem.CurrentFramePos + (int)deck.PlayingDeckItem.VideoCapture.Fps * offset;
      if (newPos < 0)
      {
        newPos = 0;
      }
      if (deck.PlayingDeckItem.VideoCapture.FrameCount <= newPos)
      {
        newPos = deck.PlayingDeckItem.VideoCapture.FrameCount - 1;
      }
      deck.PlayingDeckItem.CurrentFramePos = newPos;
    }

    private void moveMenuA_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      SelectMoveMenu(A, e);
    }

    private void moveMenuButtonA_Click(object sender, EventArgs e)
    {
      moveMenuA.Show(moveMenuButtonA, 0, 0);
    }

    private void moveMenuButtonB_Click(object sender, EventArgs e)
    {
      moveMenuB.Show(moveMenuButtonB, 0, 0);
    }

    private void moveMenuB_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      SelectMoveMenu(B, e);
    }
    private void moveMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      var i = moveMenu.DropDownItems.IndexOf(e.ClickedItem);
      if (i == -1 || A.PlayingDeckItem.VideoCapture == null)
      {
        return;
      }
      int offset = MoveMenu[i].OffsetSecond;
      MoveABMillis(offset * 1000);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Up:
          MoveABFrames(6);
          return true;
        case Keys.Down:
          MoveABFrames(-6);
          return true;
        case Keys.Right:
          MoveABFrames(1);
          return true;
        case Keys.Left:
          MoveABFrames(-1);
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void MoveABFrames(int offset)
    {
      int offsetA2B = B.PlayingDeckItem.CurrentFramePos - A.PlayingDeckItem.CurrentFramePos;
      int newFramePos = A.PlayingDeckItem.CurrentFramePos + offset;
      if (newFramePos < 0)
      {
        newFramePos = 0;
      }
      if (A.PlayingDeckItem.VideoCapture.FrameCount - 1 < newFramePos)
      {
        newFramePos = A.PlayingDeckItem.VideoCapture.FrameCount;
      }
      A.PlayingDeckItem.CurrentFramePos = newFramePos;
      B.PlayingDeckItem.CurrentFramePos = newFramePos + offsetA2B;
      RefreshVideo();
    }

    private void MoveABMillis(int offsetMillis)
    {
      int offsetFrames = (int)Math.Round(A.PlayingDeckItem.VideoCapture.Fps * offsetMillis / 1000, MidpointRounding.AwayFromZero);
      MoveABFrames(offsetFrames);
    }

    private void moveNext1Frame_Click(object sender, EventArgs e)
    {
      MoveABFrames(1);
    }

    private void moveNext100ms_Click(object sender, EventArgs e)
    {
      MoveABMillis(100);
    }

    private void movePrev1Frame_Click(object sender, EventArgs e)
    {
      MoveABFrames(-1);
    }

    private void movePrev100ms_Click(object sender, EventArgs e)
    {
      MoveABMillis(-100);
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

    private void PaintDeck(Graphics g, bool dragging, Deck deck, RectangleF dst, Options options)
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
        if (options.GridType != GridType.None)
        {
          using (var pen = new Pen(Color.FromArgb(100, 255, 255, 255)))
          {
            var (splitX,splitY) = options.GridType.NumberOfGrids();
            for (int i = 0; i <= splitX; i++)
            {
              float x = dst.Left + dst.Width * i / splitX;
              g.DrawLine(pen, x, dst.Top, x, dst.Bottom);
            }
            for (int i = 0; i <= splitY; i++)
            {
              float y = dst.Top + dst.Height * i / splitY;
              g.DrawLine(pen, dst.Left, y, dst.Right, y);
            }
          }
        }
      }
    }

    private void pictureBoxVideo_Paint(object sender, PaintEventArgs e)
    {

      var rectA = new RectangleF(0, 0, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      var rectB = new RectangleF(0, pictureBoxVideo.Height / 2, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);

      PaintDeck(e.Graphics, drag == Drag.OnA, A, rectA, Program.UserSettings.Options);
      PaintDeck(e.Graphics, drag == Drag.OnB, B, rectB, Program.UserSettings.Options);
    }

    private void CreateMakerWithName(Deck deck, string name)
    {
      var c = deck.Components;
      var frame = deck.PlayingDeckItem.CurrentFramePos;
      c.MarkerBindingSource.Add(new Marker { Name = name, Frame = frame });
      c.Markers.SelectedIndex = c.Markers.Items.Count - 1;
    }

    private void CreateMarker(Deck deck)
    {
      var m = new MarkerNameModal();
      var dr = m.ShowDialog();
      if (dr == DialogResult.OK)
      {
        var name = Name = m.MarkerName;
        if (m.CreateOtherMaker)
        {
          CreateMakerWithName(A, name);
          CreateMakerWithName(B, name);
        }
        else
        {
          CreateMakerWithName(deck, name);
        }

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

    private void ProcessDragDrop(Deck deck, string filePath)
    {
      if (FileTypeDetector.Detect(filePath) == FileType.Video)
      {
        Program.UserSettings.RestoreFromHistory(deck.DeckItem, filePath);
      }
      else
      {
        deck.DeckItem.Alfano6Path = filePath;
        deck.DeckItem.Alfano6Offset = 0;
      }
      ResetDeck(deck);
      Program.UserSettings.Save();
    }

    private void pictureBoxVideo_DragDrop(object sender, DragEventArgs e)
    {
      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
      var filePath = files[0];
      switch (OnAOrB(e))
      {
        case Drag.OnA:
          ProcessDragDrop(A, filePath);
          break;
        case Drag.OnB:
          ProcessDragDrop(B, filePath);
          break;
      }

      drag = Drag.None;
      UpdateControlAbilities();
      RefreshVideo();
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

    private void options_Click(object sender, EventArgs e)
    {
      var f = new OptionsForm(this, Program.UserSettings.Options);
      f.ShowDialog();
      Program.UserSettings.Save();
      UpdateControlAbilities();
    }
  }
}
