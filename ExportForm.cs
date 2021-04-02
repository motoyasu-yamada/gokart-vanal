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
    private VideoCapture videoCaptureA;
    private VideoCapture videoCaptureB;
    private PlayData playData;

    public ExportForm(VideoCapture videoCaptureA, VideoCapture videoCaptureB, PlayData playData)
    {
      this.videoCaptureA = videoCaptureA;
      this.videoCaptureB = videoCaptureB;
      this.playData = playData;

      InitializeComponent();

      var s = Program.userSettings;
      Select(intervalOfImages, s.ExportIntervalOfImages);
      Select(numberOfImages, s.ExportNumberOfImages);
      folder.Text = s.ExportFolder;
      filename.Text = s.ExportFileName;
      lengthOfVideo.SelectedIndex = 0;
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
      var s = Program.userSettings;
      s.ExportIntervalOfImages = int.Parse((string)intervalOfImages.SelectedItem);
      s.ExportNumberOfImages = int.Parse((string)numberOfImages.SelectedItem);
      s.ExportFolder = folder.Text;
      s.ExportFileName = filename.Text;
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
      var fileName = filename.Text;
      fileName = fileName.Replace("{videoa_name}", "videoa");
      fileName = fileName.Replace("{videob_name}", "videob");
      fileName = fileName.Replace("{marker_name}", "marker");

      workerToExportImages.RunWorkerAsync(new ExportImageSettings
      {
        IntervalOfImages = Int32.Parse(intervalOfImages.Text),
        NumberOfImages = Int32.Parse(numberOfImages.Text),
        Folder = folder.Text,
        FileName = fileName
      });
    }

    private void workerToExportImages_DoWork(object sender, DoWorkEventArgs e)
    {
      var a = (ExportImageSettings)e.Argument;
      var framesOfInterval = a.IntervalOfImages / 100 * 6;
      var frameA = playData.CurrentFramePosA;
      var frameB = playData.CurrentFramePosB;
      var matA = new Mat();
      var matB = new Mat();

      var bmp = new Bitmap(videoCaptureA.FrameWidth, videoCaptureA.FrameHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);


      using (Graphics gr = Graphics.FromImage(bmp))
      {
        Enumerable.Range(1, a.NumberOfImages).ToList().ForEach(i =>
        {
          workerToExportImages.ReportProgress(100 * (i - 1) / a.NumberOfImages);

          videoCaptureA.PosFrames = frameA;
          videoCaptureA.Read(matA);
          Image imageA = BitmapConverter.ToBitmap(matA);

          videoCaptureB.PosFrames = frameB;
          videoCaptureB.Read(matB);
          Image imageB = BitmapConverter.ToBitmap(matB);

          gr.DrawImage(imageA,
                  new RectangleF(0, 0, bmp.Width, bmp.Height / 2),
                  new RectangleF(0, imageA.Height * 2 / 5, imageA.Width, imageA.Height / 2),
                  GraphicsUnit.Pixel);
          gr.DrawImage(imageB,
                      new RectangleF(0, bmp.Height / 2, bmp.Width, bmp.Height / 2),
                      new RectangleF(0, imageB.Height * 2 / 5, imageB.Width, imageB.Height / 2),
                      GraphicsUnit.Pixel);

          var outName = $"{a.FileName}_{i:D6}.jpeg";
          var outPath = Path.Combine(a.Folder, outName);

          var dst = BitmapConverter.ToMat(bmp);
          Cv2.ImWrite(outPath, dst);
          dst.Dispose();

          frameA += framesOfInterval;
          frameB += framesOfInterval;
        });
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
    public int NumberOfImages { get; set; }
    public int IntervalOfImages { get; set; }
    public string Folder { get; set; }
    public string FileName { get; set; }
  }
}
