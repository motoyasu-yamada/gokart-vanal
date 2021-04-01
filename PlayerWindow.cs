using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace gokart_vanal
{
    public partial class PlayerWindow : Form
    {
        private VideoCapture videoCaptureA;
        private VideoCapture videoCaptureB;
        private Mat matA = new Mat();
        private Mat matB = new Mat();

        public PlayerWindow()
        {
            InitializeComponent();
            intervalFramesToExport.SelectedIndex = 0;
            numberOfImagesToExport.SelectedIndex = 0;
            LoadVideos();
        }


        private void LoadVideos()
        {
            this.videoCaptureA = new VideoCapture("M:\\DCIM\\100GOPRO\\GH010104.MP4");
            this.hScrollBarA.Maximum = this.videoCaptureA.FrameCount;
            this.videoCaptureB = new VideoCapture("C:\\Users\\dell\\iCloudDrive\\KART\\MOTEGI-BEST\\KGO-20210328-SS-TT-BEST-GH015958.mp4");
            this.hScrollBarB.Maximum = this.videoCaptureB.FrameCount;
            pictureBoxVideo.Invalidate();
        }

        private void hScrollBarA_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxVideo.Invalidate();
            frameA.Text = "" + hScrollBarA.Value;
        }

        private void hScrollBarB_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxVideo.Invalidate();
            frameB.Text = "" + hScrollBarB.Value;
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
            hScrollBarA.Value += offset;
            hScrollBarB.Value += offset;
            frameA.Text = "" + hScrollBarA.Value;
            frameB.Text = "" + hScrollBarB.Value;
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
            var interval = Int32.Parse(intervalFramesToExport.Text);
            var images = Int32.Parse(numberOfImagesToExport.Text);

            new ToastContentBuilder().AddText("書き出しを初めます").Show();
            Console.WriteLine($"export_Click interval:{interval}, images:{images}");

            var frameA = hScrollBarA.Value;
            var frameB = hScrollBarB.Value;
            var matA = new Mat();
            var matB = new Mat();

            var bmp = new Bitmap(videoCaptureA.FrameWidth, videoCaptureA.FrameHeight,  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var outDirectoryPath = "c:\\temp";
            var fileName = "kartdiff";
            var ext = ".jpeg";
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                Enumerable.Range(1, images).ToList().ForEach(i =>
                {
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

                    var outName = $"{fileName}_{i:D6}{ext}";
                    var outPath = Path.Combine(outDirectoryPath, outName);

                    var dst = BitmapConverter.ToMat(bmp);
                    Cv2.ImWrite(outPath, dst);
                    dst.Dispose();

                    frameA += interval;
                    frameB += interval;
                });
            }
            new ToastContentBuilder().AddText("書き出し完了しました").Show();

        }

        private void pictureBoxVideo_Paint(object sender, PaintEventArgs e)
        {
            lock(videoCaptureA)
            {
                videoCaptureA.Set(VideoCaptureProperties.PosFrames, hScrollBarA.Value);
                videoCaptureA.Read(matA);

                videoCaptureB.Set(VideoCaptureProperties.PosFrames, hScrollBarB.Value);
                videoCaptureB.Read(matB);

                if (!matA.Empty())
                {
                    using (var imageA = BitmapConverter.ToBitmap(matA))
                    {
                        e.Graphics.DrawImage(imageA,
                        new RectangleF(0, 0, pictureBoxVideo.Width, pictureBoxVideo.Height / 2),
                        new RectangleF(0, imageA.Height * 2 / 5, imageA.Width, imageA.Height / 2),
                        GraphicsUnit.Pixel);
                    }
                }
                if (!matB.Empty())
                {
                    using (var imageB = BitmapConverter.ToBitmap(matB))
                    {
                        e.Graphics.DrawImage(imageB,
                            new RectangleF(0, pictureBoxVideo.Height / 2, pictureBoxVideo.Width, pictureBoxVideo.Height / 2),
                            new RectangleF(0, imageB.Height * 2 / 5, imageB.Width, imageB.Height / 2),
                            GraphicsUnit.Pixel);
                    }
                }
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
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
    }
}
