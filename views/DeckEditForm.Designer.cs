
namespace gokart_vanal
{
  partial class DeckEditForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckEditForm));
      this.label1 = new System.Windows.Forms.Label();
      this.videoPath = new System.Windows.Forms.TextBox();
      this.fps = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.frameCount = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.scalingMethod = new System.Windows.Forms.ComboBox();
      this.scalePercent = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.offsetPercent = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.alfano6Path = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.alfano6Offset = new System.Windows.Forms.TextBox();
      this.setAlfano6OffsetToCurrentFrame = new System.Windows.Forms.Button();
      this.detachVideo = new System.Windows.Forms.Button();
      this.detachAlfano6 = new System.Windows.Forms.Button();
      this.markers = new System.Windows.Forms.ListBox();
      this.deleteMarker = new System.Windows.Forms.Button();
      this.upMarker = new System.Windows.Forms.Button();
      this.downMarker = new System.Windows.Forms.Button();
      this.label11 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(20, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "ファイルパス:";
      // 
      // videoPath
      // 
      this.videoPath.Location = new System.Drawing.Point(86, 19);
      this.videoPath.Name = "videoPath";
      this.videoPath.ReadOnly = true;
      this.videoPath.Size = new System.Drawing.Size(458, 19);
      this.videoPath.TabIndex = 1;
      // 
      // fps
      // 
      this.fps.Location = new System.Drawing.Point(86, 51);
      this.fps.Name = "fps";
      this.fps.ReadOnly = true;
      this.fps.Size = new System.Drawing.Size(165, 19);
      this.fps.TabIndex = 3;
      this.fps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(20, 54);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(28, 12);
      this.label2.TabIndex = 4;
      this.label2.Text = "FPS:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(278, 54);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 12);
      this.label3.TabIndex = 6;
      this.label3.Text = "総フレーム数:";
      // 
      // frameCount
      // 
      this.frameCount.Location = new System.Drawing.Point(351, 51);
      this.frameCount.Name = "frameCount";
      this.frameCount.ReadOnly = true;
      this.frameCount.Size = new System.Drawing.Size(165, 19);
      this.frameCount.TabIndex = 5;
      this.frameCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(20, 93);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(84, 12);
      this.label4.TabIndex = 7;
      this.label4.Text = "スケーリング方法:";
      // 
      // scalingMethod
      // 
      this.scalingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.scalingMethod.FormattingEnabled = true;
      this.scalingMethod.Items.AddRange(new object[] {
            "画面にフィットさせて表示",
            "動画の比率のまま表示"});
      this.scalingMethod.Location = new System.Drawing.Point(111, 89);
      this.scalingMethod.Name = "scalingMethod";
      this.scalingMethod.Size = new System.Drawing.Size(121, 20);
      this.scalingMethod.TabIndex = 8;
      this.scalingMethod.SelectedIndexChanged += new System.EventHandler(this.scalingMethod_SelectedIndexChanged);
      // 
      // scalePercent
      // 
      this.scalePercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.scalePercent.FormattingEnabled = true;
      this.scalePercent.Items.AddRange(new object[] {
            "100",
            "75",
            "50"});
      this.scalePercent.Location = new System.Drawing.Point(111, 124);
      this.scalePercent.Name = "scalePercent";
      this.scalePercent.Size = new System.Drawing.Size(121, 20);
      this.scalePercent.TabIndex = 10;
      this.scalePercent.SelectedIndexChanged += new System.EventHandler(this.scalePercent_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(20, 128);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 12);
      this.label5.TabIndex = 9;
      this.label5.Text = "表示領域:";
      // 
      // offsetPercent
      // 
      this.offsetPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.offsetPercent.FormattingEnabled = true;
      this.offsetPercent.Items.AddRange(new object[] {
            "-25",
            "-20",
            "-15",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "15",
            "20",
            "25"});
      this.offsetPercent.Location = new System.Drawing.Point(369, 124);
      this.offsetPercent.Name = "offsetPercent";
      this.offsetPercent.Size = new System.Drawing.Size(121, 20);
      this.offsetPercent.TabIndex = 12;
      this.offsetPercent.SelectedIndexChanged += new System.EventHandler(this.offsetPercent_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(278, 128);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(49, 12);
      this.label6.TabIndex = 11;
      this.label6.Text = "オフセット:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(496, 127);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(11, 12);
      this.label7.TabIndex = 14;
      this.label7.Text = "%";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(238, 127);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(11, 12);
      this.label8.TabIndex = 13;
      this.label8.Text = "%";
      // 
      // alfano6Path
      // 
      this.alfano6Path.Location = new System.Drawing.Point(83, 173);
      this.alfano6Path.Name = "alfano6Path";
      this.alfano6Path.ReadOnly = true;
      this.alfano6Path.Size = new System.Drawing.Size(461, 19);
      this.alfano6Path.TabIndex = 16;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(17, 176);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(55, 12);
      this.label9.TabIndex = 15;
      this.label9.Text = "ロガーパス:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(17, 206);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(49, 12);
      this.label10.TabIndex = 18;
      this.label10.Text = "オフセット:";
      // 
      // alfano6Offset
      // 
      this.alfano6Offset.Location = new System.Drawing.Point(83, 203);
      this.alfano6Offset.Name = "alfano6Offset";
      this.alfano6Offset.Size = new System.Drawing.Size(165, 19);
      this.alfano6Offset.TabIndex = 17;
      this.alfano6Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.alfano6Offset.TextChanged += new System.EventHandler(this.alfano6Offset_TextChanged);
      // 
      // setAlfano6OffsetToCurrentFrame
      // 
      this.setAlfano6OffsetToCurrentFrame.Location = new System.Drawing.Point(258, 200);
      this.setAlfano6OffsetToCurrentFrame.Name = "setAlfano6OffsetToCurrentFrame";
      this.setAlfano6OffsetToCurrentFrame.Size = new System.Drawing.Size(258, 23);
      this.setAlfano6OffsetToCurrentFrame.TabIndex = 19;
      this.setAlfano6OffsetToCurrentFrame.Text = "現在の動画位置をロガーの開始位置にする";
      this.setAlfano6OffsetToCurrentFrame.UseVisualStyleBackColor = true;
      this.setAlfano6OffsetToCurrentFrame.Click += new System.EventHandler(this.setAlfano6OffsetToCurrentFrame_Click);
      // 
      // detachVideo
      // 
      this.detachVideo.AutoSize = true;
      this.detachVideo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.detachVideo.Image = ((System.Drawing.Image)(resources.GetObject("detachVideo.Image")));
      this.detachVideo.Location = new System.Drawing.Point(550, 17);
      this.detachVideo.Name = "detachVideo";
      this.detachVideo.Size = new System.Drawing.Size(22, 22);
      this.detachVideo.TabIndex = 20;
      this.detachVideo.UseVisualStyleBackColor = true;
      this.detachVideo.Click += new System.EventHandler(this.detachVideo_Click);
      // 
      // detachAlfano6
      // 
      this.detachAlfano6.AutoSize = true;
      this.detachAlfano6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.detachAlfano6.Image = ((System.Drawing.Image)(resources.GetObject("detachAlfano6.Image")));
      this.detachAlfano6.Location = new System.Drawing.Point(550, 171);
      this.detachAlfano6.Name = "detachAlfano6";
      this.detachAlfano6.Size = new System.Drawing.Size(22, 22);
      this.detachAlfano6.TabIndex = 21;
      this.detachAlfano6.UseVisualStyleBackColor = true;
      this.detachAlfano6.Click += new System.EventHandler(this.detachAlfano6_Click);
      // 
      // markers
      // 
      this.markers.FormattingEnabled = true;
      this.markers.ItemHeight = 12;
      this.markers.Location = new System.Drawing.Point(22, 263);
      this.markers.Name = "markers";
      this.markers.Size = new System.Drawing.Size(550, 268);
      this.markers.TabIndex = 22;
      this.markers.SelectedIndexChanged += new System.EventHandler(this.markers_SelectedIndexChanged);
      // 
      // deleteMarker
      // 
      this.deleteMarker.AutoSize = true;
      this.deleteMarker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.deleteMarker.Image = ((System.Drawing.Image)(resources.GetObject("deleteMarker.Image")));
      this.deleteMarker.Location = new System.Drawing.Point(550, 235);
      this.deleteMarker.Name = "deleteMarker";
      this.deleteMarker.Size = new System.Drawing.Size(22, 22);
      this.deleteMarker.TabIndex = 23;
      this.deleteMarker.UseVisualStyleBackColor = true;
      this.deleteMarker.Click += new System.EventHandler(this.deleteMarker_Click);
      // 
      // upMarker
      // 
      this.upMarker.AutoSize = true;
      this.upMarker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.upMarker.Image = ((System.Drawing.Image)(resources.GetObject("upMarker.Image")));
      this.upMarker.Location = new System.Drawing.Point(522, 235);
      this.upMarker.Name = "upMarker";
      this.upMarker.Size = new System.Drawing.Size(22, 22);
      this.upMarker.TabIndex = 24;
      this.upMarker.UseVisualStyleBackColor = true;
      this.upMarker.Click += new System.EventHandler(this.upMarker_Click);
      // 
      // downMarker
      // 
      this.downMarker.AutoSize = true;
      this.downMarker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.downMarker.Image = ((System.Drawing.Image)(resources.GetObject("downMarker.Image")));
      this.downMarker.Location = new System.Drawing.Point(494, 235);
      this.downMarker.Name = "downMarker";
      this.downMarker.Size = new System.Drawing.Size(22, 22);
      this.downMarker.TabIndex = 25;
      this.downMarker.UseVisualStyleBackColor = true;
      this.downMarker.Click += new System.EventHandler(this.downMarker_Click);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(25, 240);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(62, 12);
      this.label11.TabIndex = 26;
      this.label11.Text = "マーカー(&M):";
      // 
      // DeckEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(593, 550);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.downMarker);
      this.Controls.Add(this.upMarker);
      this.Controls.Add(this.deleteMarker);
      this.Controls.Add(this.markers);
      this.Controls.Add(this.detachAlfano6);
      this.Controls.Add(this.detachVideo);
      this.Controls.Add(this.setAlfano6OffsetToCurrentFrame);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.alfano6Offset);
      this.Controls.Add(this.alfano6Path);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.offsetPercent);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.scalePercent);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.scalingMethod);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.frameCount);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.fps);
      this.Controls.Add(this.videoPath);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DeckEditForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "動画デッキの設定";
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeckEditForm_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox videoPath;
    private System.Windows.Forms.TextBox fps;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox frameCount;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox scalingMethod;
    private System.Windows.Forms.ComboBox scalePercent;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox offsetPercent;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox alfano6Path;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox alfano6Offset;
    private System.Windows.Forms.Button setAlfano6OffsetToCurrentFrame;
    private System.Windows.Forms.Button detachVideo;
    private System.Windows.Forms.Button detachAlfano6;
    private System.Windows.Forms.ListBox markers;
    private System.Windows.Forms.Button deleteMarker;
    private System.Windows.Forms.Button upMarker;
    private System.Windows.Forms.Button downMarker;
    private System.Windows.Forms.Label label11;
  }
}