using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class PlayerWindow : Form
  {
    private BindingSource markerBindingSource = new BindingSource(new List<Marker>(), "");
    private PlayData playData { get; } = new PlayData();
    private VideoCapture videoCaptureA;
    private VideoCapture videoCaptureB;

    public PlayerWindow()
    {
      InitializeComponent();
      pictureBoxVideo.AllowDrop = true;

      markers.ComboBox.DataSource = markerBindingSource;
      markers.ComboBox.DisplayMember = "Display";
      markers.ComboBox.ValueMember = "Display";

      currentFramePosA.TextBox.DataBindings.Add(nameof(currentFramePosA.TextBox.Text), playData, nameof(playData.CurrentFramePosA), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarA.DataBindings.Add(nameof(hScrollBarA.Value), playData, nameof(playData.CurrentFramePosA), true, DataSourceUpdateMode.OnPropertyChanged);
      currentFramePosB.TextBox.DataBindings.Add(nameof(currentFramePosB.TextBox.Text), playData, nameof(playData.CurrentFramePosB), true, DataSourceUpdateMode.OnPropertyChanged);
      hScrollBarB.DataBindings.Add(nameof(hScrollBarB.Value), playData, nameof(playData.CurrentFramePosB), true, DataSourceUpdateMode.OnPropertyChanged);

      LoadVideos();
    }


    private void LoadVideos()
    {
      this.videoCaptureA = new VideoCapture(Program.userSettings.VideoAPath);
      this.videoCaptureB = new VideoCapture(Program.userSettings.VideoBPath);

      this.hScrollBarA.Maximum = this.videoCaptureA.FrameCount;
      this.hScrollBarB.Maximum = this.videoCaptureB.FrameCount;
      pictureBoxVideo.Invalidate();
    }

    private void hScrollBarA_ValueChanged(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
      // currentFramePosA.Text = "" + hScrollBarA.Value;
    }

    private void hScrollBarB_ValueChanged(object sender, EventArgs e)
    {
      pictureBoxVideo.Invalidate();
      // currentFramePosB.Text = "" + hScrollBarB.Value;
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

    private void pictureBoxVideo_Paint(object sender, PaintEventArgs e)
    {
      var dragBrush = new SolidBrush(System.Drawing.Color.Red);
      var noneBrush = new SolidBrush(Color.DarkGray);
      var rectA = new RectangleF(0, 0, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      var rectB = new RectangleF(0, pictureBoxVideo.Height / 2, pictureBoxVideo.Width, pictureBoxVideo.Height / 2);
      if (drag == Drag.OnA)
      {
        e.Graphics.FillRectangle(dragBrush, rectA);
      }
      else
      {
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
              new RectangleF(0, imageA.Height * 2 / 5, imageA.Width, imageA.Height / 2),
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
                  new RectangleF(0, imageB.Height * 2 / 5, imageB.Width, imageB.Height / 2),
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
        markerBindingSource.ResetBindings(false);
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
          if (this.videoCaptureA != null)
          {
            this.videoCaptureA.Dispose();
          }
          this.videoCaptureA = new VideoCapture(filePath);
          this.playData.CurrentFramePosA = 0;
          this.hScrollBarA.Maximum = this.videoCaptureA.FrameCount;
          this.markerBindingSource.Clear();
          Program.userSettings.VideoAPath = filePath;
          Program.userSettings.Save();
          break;
        case Drag.OnB:
          if (this.videoCaptureB != null)
          {
            this.videoCaptureB.Dispose();
          }
          this.videoCaptureB = new VideoCapture(filePath);
          this.playData.CurrentFramePosB = 0;
          this.hScrollBarB.Maximum = this.videoCaptureB.FrameCount;
          this.markerBindingSource.Clear();
          Program.userSettings.VideoBPath = filePath;
          Program.userSettings.Save();
          break;
      }
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
  }
}
