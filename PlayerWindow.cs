using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class PlayerWindow : Form
  {
    private BindingSource markerBindingSource;
    private PlayData playData { get; } = new PlayData();
    private VideoCapture videoCaptureA;
    private VideoCapture videoCaptureB;

    public PlayerWindow()
    {
      InitializeComponent();
      pictureBoxVideo.AllowDrop = true;

      markerBindingSource = new BindingSource(Program.UserSettings.Deck.Markers, "");
      markers.ComboBox.DataSource = markerBindingSource;
      markers.ComboBox.DisplayMember = nameof(Marker.Display);
      markers.ComboBox.ValueMember = nameof(Marker.Display);

      currentFramePosA.TextBox.DataBindings.Add(nameof(currentFramePosA.TextBox.Text), playData, nameof(playData.CurrentFramePosA), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarA.DataBindings.Add(nameof(hScrollBarA.Value), playData, nameof(playData.CurrentFramePosA), true, DataSourceUpdateMode.OnPropertyChanged);
      currentFramePosB.TextBox.DataBindings.Add(nameof(currentFramePosB.TextBox.Text), playData, nameof(playData.CurrentFramePosB), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarB.DataBindings.Add(nameof(hScrollBarB.Value), playData, nameof(playData.CurrentFramePosB), true, DataSourceUpdateMode.OnPropertyChanged);

      LoadVideos();
    }

    private void SetVideoA(string videoPathA)
    {
      if (this.videoCaptureA != null)
      {
        this.videoCaptureA.Dispose();
        this.videoCaptureA = null;
      }

      if (videoPathA != null)
      {
        this.videoCaptureA = new VideoCapture(videoPathA);
        this.hScrollBarA.Maximum = this.videoCaptureA.FrameCount;
        this.hScrollBarA.Enabled = true;
        this.currentFramePosA.Enabled = true;
      }
      else
      {
        this.hScrollBarA.Maximum = 0;
        this.hScrollBarA.Enabled = false;
        this.currentFramePosA.Enabled = false;
      }
      Program.UserSettings.Deck.A.VideoPath = videoPathA;
    }

    private void SetVideoB(string videoPathB)
    {
      if (this.videoCaptureB != null)
      {
        this.videoCaptureB.Dispose();
        this.videoCaptureB = null;
      }
      if (videoPathB != null)
      {
        this.videoCaptureB = new VideoCapture(videoPathB);
        this.hScrollBarB.Maximum = this.videoCaptureB.FrameCount;
        this.currentFramePosB.Enabled = true;
        this.hScrollBarB.Enabled = true;
      }
      else
      {
        this.hScrollBarB.Maximum = 0;
        this.hScrollBarB.Enabled = false;
        this.currentFramePosB.Enabled = false;
      }
      Program.UserSettings.Deck.B.VideoPath = videoPathB;
    }

    private void LoadVideos()
    {
      SetVideoA(Program.UserSettings.Deck.A.VideoPath);
      SetVideoB(Program.UserSettings.Deck.B.VideoPath);
      markerBindingSource.ResetBindings(false);
      markers.Enabled = markerBindingSource.Count > 0;

      pictureBoxVideo.Invalidate();
    }

    public void RefreshVideo()
    {
      pictureBoxVideo.Invalidate();
    }

    private void hScrollBarA_ValueChanged(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
    }

    private void hScrollBarB_ValueChanged(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
    }

    private void PlayerWindow_Activated(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
    }

    private void PlayerWindow_Resize(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
    }

    private void pictureBoxVideo_Resize(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
    }

    private void MoveFrame(int offset)
    {
      playData.CurrentFramePosA += offset;
      playData.CurrentFramePosB += offset;
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
      var form = new ExportForm(videoCaptureA, videoCaptureB, playData);
      var dr = form.ShowDialog();



    }

    private SolidBrush dragBrush = new SolidBrush(Color.Red);
    private SolidBrush noneBrush = new SolidBrush(Color.DarkGray);
    private SolidBrush nullBrash = new SolidBrush(Color.Black);

    private RectangleF NewSrcRect(Bitmap bitmap, DeckItem deckItem, RectangleF dst)
    {
      var height = bitmap.Height * deckItem.ScalePercent / 100;
      var top = (bitmap.Height - height)/ 2 + bitmap.Height * deckItem.OffsetPercent / 100;

      if (deckItem.VideoScalingMethod == VideoScalingMethod.FitToScreen)
      {
        return new RectangleF(0, top, bitmap.Width, height);
      }

      var width = height * dst.Width / dst.Height;
      var left = (bitmap.Width - width) / 2;
      return new RectangleF(left, top, width, height);
    }

    private void pictureBoxVideo_Paint(object sender, PaintEventArgs e)
    {
      
      var rectA = new RectangleF(0, 0, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      var rectB = new RectangleF(0, pictureBoxVideo.Height / 2, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      
      if (drag == Drag.OnA)
      {
        e.Graphics.FillRectangle(dragBrush, rectA);
      }
      else
      {
        e.Graphics.FillRectangle(nullBrash, rectA);
        using (var matA = new Mat())
        {
          if (videoCaptureA != null)
          {
            videoCaptureA.Set(VideoCaptureProperties.PosFrames, playData.CurrentFramePosA);
            videoCaptureA.Read(matA);
          }

          if (matA.Empty())
          {
            e.Graphics.FillRectangle(noneBrush, rectA);
          }
          else
          {
            using (var imageA = BitmapConverter.ToBitmap(matA))
            {
              e.Graphics.DrawImage(imageA,
              rectA,
              NewSrcRect(imageA, Program.UserSettings.Deck.A, rectA),
              GraphicsUnit.Pixel);
            }
          }
        }
      }
      if (drag == Drag.OnB)
      {
        e.Graphics.FillRectangle(dragBrush, rectB);
      }
      else
      {
        e.Graphics.FillRectangle(nullBrash, rectB);
        using (var matB = new Mat())
        {
          if (videoCaptureB != null)
          {
            videoCaptureB.Set(VideoCaptureProperties.PosFrames, playData.CurrentFramePosB);
            videoCaptureB.Read(matB);
          }

          if (matB.Empty())
          {
            e.Graphics.FillRectangle(noneBrush, rectB);
          }
          else
          {
            using (var imageB = BitmapConverter.ToBitmap(matB))
            {
              e.Graphics.DrawImage(imageB,
                  rectB,
                  NewSrcRect(imageB, Program.UserSettings.Deck.B, rectB),
                  GraphicsUnit.Pixel);
            }
          }
        }
      }
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
      playData.CurrentFramePosA = m.frameA;
      playData.CurrentFramePosB = m.frameB;
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
          SetVideoA(filePath);
          this.playData.CurrentFramePosA = 0;
          break;
        case Drag.OnB:
          SetVideoB(filePath);
          this.playData.CurrentFramePosB = 0;
          break;
      }
      this.markerBindingSource.Clear();
      Program.UserSettings.Save();

      drag = Drag.None;
      Console.WriteLine($"DragDrop {drag} -> {filePath}");
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
      var f = new DeckEditForm(this, Program.UserSettings.Deck.A, videoCaptureA);
      f.ShowDialog();
    }

    private void deckB_Click(object sender, EventArgs e)
    {
      var f = new DeckEditForm(this, Program.UserSettings.Deck.B, videoCaptureB);
      f.ShowDialog();
    }
  }
}
