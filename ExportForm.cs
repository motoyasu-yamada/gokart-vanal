using Microsoft.Toolkit.Uwp.Notifications;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gokart_vanal
{
  public partial class ExportForm : Form
  {
    private PlayingDeck playingDeck;

    public ExportForm(PlayingDeck playingDeck)
    {
      this.playingDeck = playingDeck;

      InitializeComponent();

      var s = Program.UserSettings;
      Select(imageDecompositionIntervalMillis, s.Export.ImageDecompositionIntervalMillis);
      Select(lengthMillis, s.Export.LengthMillis);
      folder.Text = s.Export.Folder;
      fileNameTemplate.Text = s.Export.FileNameTemplate;
    }

    private void Select(ComboBox comboBox, int value)
    {
      int i = 0;
      foreach (object item in comboBox.Items)
      {
        if (int.Parse((string)item) == value)
        {
          comboBox.SelectedIndex = i;
          return;
        }
        i++;
      }
      comboBox.SelectedIndex = 0;
    }

    private void Save()
    {
      var s = Program.UserSettings;
      s.Export.ImageDecompositionIntervalMillis = int.Parse((string)imageDecompositionIntervalMillis.SelectedItem);
      s.Export.LengthMillis = int.Parse((string)lengthMillis.SelectedItem);
      s.Export.Folder = folder.Text;
      s.Export.FileNameTemplate = fileNameTemplate.Text;
      s.Save();
    }

    private void chooseFolder_Click(object sender, EventArgs e)
    {
      var folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.Description = "フォルダを選択してください。";
      folderBrowserDialog.SelectedPath = folder.Text;
      folderBrowserDialog.ShowNewFolderButton = true;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        folder.Text = folderBrowserDialog.SelectedPath;
      }
    }

    private void exportImages_Click(object sender, EventArgs e)
    {
      Save();
      var fileName = fileNameTemplate.Text;
      fileName = fileName.Replace("{videoa_name}", "videoa");
      fileName = fileName.Replace("{videob_name}", "videob");
      fileName = fileName.Replace("{marker_name}", "marker");

      workerToExportImages.RunWorkerAsync(new ExportImageSettings
      {
        ImageDecompositionIntervalMillis = Int32.Parse(imageDecompositionIntervalMillis.Text),
        LengthMillis = Int32.Parse(lengthMillis.Text),
        Folder = folder.Text,
        FileName = fileName
      });
    }

    private void workerToExportImages_DoWork(object sender, DoWorkEventArgs e)
    {
      var a = (ExportImageSettings)e.Argument;
      var framesOfInterval = a.ImageDecompositionIntervalMillis / 100 * 6;
      var startFrameA = playingDeck.A.CurrentFramePos;
      var startFrameB = playingDeck.B.CurrentFramePos;
      var matA = new Mat();
      var matB = new Mat();
      var videoCaptureA = playingDeck.A.VideoCapture;
      var videoCaptureB = playingDeck.B.VideoCapture;
      var bmp = new Bitmap(videoCaptureA.FrameWidth, videoCaptureA.FrameHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);


      using (Graphics gr = Graphics.FromImage(bmp))
      {
        var millisPerFrameA = 1000 / videoCaptureA.Fps;
        var millisPerFrameB = 1000 / videoCaptureB.Fps;

        var i = 0;
        while (i <= a.LengthMillis)
        {
          workerToExportImages.ReportProgress(100 * i / a.LengthMillis);
          var frameA = startFrameA + (int)(i * videoCaptureA.Fps / 1000);
          videoCaptureA.PosFrames = frameA;
          videoCaptureA.Read(matA);
          Image imageA = BitmapConverter.ToBitmap(matA);
          gr.DrawImage(imageA,
          new RectangleF(0, 0, bmp.Width, bmp.Height / 2),
          new RectangleF(0, imageA.Height * 2 / 5, imageA.Width, imageA.Height / 2),
          GraphicsUnit.Pixel);

          var frameB = startFrameB + (int)(i * videoCaptureA.Fps / 1000);
          videoCaptureB.PosFrames = frameB;
          videoCaptureB.Read(matB);
          Image imageB = BitmapConverter.ToBitmap(matB);
          gr.DrawImage(imageB,
          new RectangleF(0, bmp.Height / 2, bmp.Width, bmp.Height / 2),
          new RectangleF(0, imageB.Height * 2 / 5, imageB.Width, imageB.Height / 2),
          GraphicsUnit.Pixel);

          var outName = $"{a.FileName}_{i:D6}.jpeg";
          var outPath = Path.Combine(a.Folder, outName);
          using (var dst = BitmapConverter.ToMat(bmp))
          {
            Cv2.ImWrite(outPath, dst);
          }

          i += a.ImageDecompositionIntervalMillis;
        }
        workerToExportImages.ReportProgress(100);
      }

    }

    private void workerToExportImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      progressOfExportImages.Value = e.ProgressPercentage;
    }

    private void workerToExportImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      new ToastContentBuilder().AddText("書き出し完了しました").Show();
    }
  }

  class ExportImageSettings
  {
    public int LengthMillis { get; set; }
    public int ImageDecompositionIntervalMillis { get; set; }
    public string Folder { get; set; }
    public string FileName { get; set; }
  }
}
