using gokart_vanal.logger;
using gokart_vanal.models;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using Windows.UI.Xaml.Controls;

namespace gokart_vanal
{
  public class FramePlaybackData : INotifyPropertyChanged
  {
    private VideoCapture videoCapture;

    public VideoCapture VideoCapture
    {
      get { return this.videoCapture; }
      set
      {
        if (videoCapture != null)
        {
          videoCapture.Dispose();
        }
        videoCapture = value;
        currentMat = null;
        currentMatFrame = -1;
      }
    }

    public Session Session { get; set; }

    private Mat currentMat;
    private int currentMatFrame = -1;

    public Mat CurrentMat
    {
      get
      {
        if (VideoCapture == null)
        {
          return null;
        }
        var requireToRetreive = currentMatFrame != CurrentFramePos || currentMat == null;
        if (requireToRetreive)
        {
          var frameStarted = Environment.TickCount;
          VideoCapture.Set(VideoCaptureProperties.PosFrames, CurrentFramePos);
          currentMatFrame = CurrentFramePos;
          currentMat = VideoCapture.RetrieveMat();
          var frameElapsed = (Environment.TickCount - frameStarted);
          Debug.WriteLine($"CurrentMat:{frameElapsed}");
        }
        return currentMat;
        
      }
    }

    private int currentFramePos;
    public int CurrentFramePos
    {
      get { return currentFramePos; }
      set
      {
        if (currentFramePos == value)
        {
          return;
        }
        
        currentFramePos = value;
        currentMat = null;
        currentMatFrame = -1;
        NotifyPropertyChanged(nameof(CurrentFramePos));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
