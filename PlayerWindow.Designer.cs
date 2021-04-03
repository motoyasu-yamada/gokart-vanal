
namespace gokart_vanal
{
  partial class PlayerWindow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindow));
      this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
      this.hScrollBarA = new System.Windows.Forms.HScrollBar();
      this.hScrollBarB = new System.Windows.Forms.HScrollBar();
      this.currentFramePosA = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.currentFramePosB = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.markers = new System.Windows.Forms.ToolStripComboBox();
      this.createMarker = new System.Windows.Forms.ToolStripButton();
      this.deleteMarker = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.prev6frames = new System.Windows.Forms.ToolStripButton();
      this.prev1frame = new System.Windows.Forms.ToolStripButton();
      this.next1frame = new System.Windows.Forms.ToolStripButton();
      this.next6frames = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripDefault = new System.Windows.Forms.ToolStrip();
      this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.書き出すToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.動画Aを読み込むToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.動画Bを読み込むToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
      this.toolStripDefault.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBoxVideo
      // 
      this.pictureBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBoxVideo.Location = new System.Drawing.Point(1, 49);
      this.pictureBoxVideo.Name = "pictureBoxVideo";
      this.pictureBoxVideo.Size = new System.Drawing.Size(1433, 561);
      this.pictureBoxVideo.TabIndex = 0;
      this.pictureBoxVideo.TabStop = false;
      this.pictureBoxVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragDrop);
      this.pictureBoxVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragEnter);
      this.pictureBoxVideo.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragOver);
      this.pictureBoxVideo.DragLeave += new System.EventHandler(this.pictureBoxVideo_DragLeave);
      this.pictureBoxVideo.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxVideo_Paint);
      this.pictureBoxVideo.Resize += new System.EventHandler(this.pictureBoxVideo_Resize);
      // 
      // hScrollBarA
      // 
      this.hScrollBarA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBarA.Location = new System.Drawing.Point(1, 29);
      this.hScrollBarA.Maximum = 59411;
      this.hScrollBarA.Name = "hScrollBarA";
      this.hScrollBarA.Size = new System.Drawing.Size(1433, 17);
      this.hScrollBarA.TabIndex = 18;
      this.hScrollBarA.ValueChanged += new System.EventHandler(this.hScrollBarA_ValueChanged);
      // 
      // hScrollBarB
      // 
      this.hScrollBarB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBarB.Location = new System.Drawing.Point(1, 613);
      this.hScrollBarB.Name = "hScrollBarB";
      this.hScrollBarB.Size = new System.Drawing.Size(1433, 18);
      this.hScrollBarB.TabIndex = 20;
      this.hScrollBarB.ValueChanged += new System.EventHandler(this.hScrollBarB_ValueChanged);
      // 
      // currentFramePosA
      // 
      this.currentFramePosA.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
      this.currentFramePosA.Name = "currentFramePosA";
      this.currentFramePosA.Size = new System.Drawing.Size(100, 25);
      this.currentFramePosA.Text = "0";
      this.currentFramePosA.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.currentFramePosA.ToolTipText = "上画面のフレーム位置";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(12, 22);
      this.toolStripLabel1.Text = "/";
      // 
      // currentFramePosB
      // 
      this.currentFramePosB.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
      this.currentFramePosB.Name = "currentFramePosB";
      this.currentFramePosB.Size = new System.Drawing.Size(100, 25);
      this.currentFramePosB.Text = "0";
      this.currentFramePosB.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // markers
      // 
      this.markers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.markers.Enabled = false;
      this.markers.Name = "markers";
      this.markers.Size = new System.Drawing.Size(121, 25);
      this.markers.ToolTipText = "マーカー一覧";
      this.markers.SelectedIndexChanged += new System.EventHandler(this.markers_SelectedIndexChanged);
      // 
      // createMarker
      // 
      this.createMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.createMarker.Image = ((System.Drawing.Image)(resources.GetObject("createMarker.Image")));
      this.createMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.createMarker.Name = "createMarker";
      this.createMarker.Size = new System.Drawing.Size(35, 22);
      this.createMarker.Text = "保存";
      this.createMarker.ToolTipText = "現在の上画面と下画面のフレーム位置をマーカーとして保存します。";
      this.createMarker.Click += new System.EventHandler(this.createMarker_Click);
      // 
      // deleteMarker
      // 
      this.deleteMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.deleteMarker.Enabled = false;
      this.deleteMarker.Image = ((System.Drawing.Image)(resources.GetObject("deleteMarker.Image")));
      this.deleteMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deleteMarker.Name = "deleteMarker";
      this.deleteMarker.Size = new System.Drawing.Size(35, 22);
      this.deleteMarker.Text = "削除";
      this.deleteMarker.ToolTipText = "現在選択しているマーカーを削除します。";
      this.deleteMarker.Click += new System.EventHandler(this.deleteMarker_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // prev6frames
      // 
      this.prev6frames.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.prev6frames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.prev6frames.Image = ((System.Drawing.Image)(resources.GetObject("prev6frames.Image")));
      this.prev6frames.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.prev6frames.Name = "prev6frames";
      this.prev6frames.Size = new System.Drawing.Size(36, 22);
      this.prev6frames.Text = "<< 6";
      this.prev6frames.Click += new System.EventHandler(this.prev6frames_Click);
      // 
      // prev1frame
      // 
      this.prev1frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.prev1frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.prev1frame.Image = ((System.Drawing.Image)(resources.GetObject("prev1frame.Image")));
      this.prev1frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.prev1frame.Name = "prev1frame";
      this.prev1frame.Size = new System.Drawing.Size(28, 22);
      this.prev1frame.Text = "< 1";
      this.prev1frame.Click += new System.EventHandler(this.prev1frame_Click);
      // 
      // next1frame
      // 
      this.next1frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.next1frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.next1frame.Image = ((System.Drawing.Image)(resources.GetObject("next1frame.Image")));
      this.next1frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.next1frame.Name = "next1frame";
      this.next1frame.Size = new System.Drawing.Size(28, 22);
      this.next1frame.Text = "1 >";
      this.next1frame.Click += new System.EventHandler(this.next1frame_Click);
      // 
      // next6frames
      // 
      this.next6frames.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.next6frames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.next6frames.Image = ((System.Drawing.Image)(resources.GetObject("next6frames.Image")));
      this.next6frames.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.next6frames.Name = "next6frames";
      this.next6frames.Size = new System.Drawing.Size(36, 22);
      this.next6frames.Text = "6 >>";
      this.next6frames.ToolTipText = "6 >>";
      this.next6frames.Click += new System.EventHandler(this.next6frames_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripDefault
      // 
      this.toolStripDefault.GripMargin = new System.Windows.Forms.Padding(6);
      this.toolStripDefault.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentFramePosA,
            this.toolStripLabel1,
            this.currentFramePosB,
            this.toolStripSeparator1,
            this.markers,
            this.createMarker,
            this.deleteMarker,
            this.toolStripSeparator2,
            this.prev6frames,
            this.prev1frame,
            this.next1frame,
            this.next6frames,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
      this.toolStripDefault.Location = new System.Drawing.Point(0, 0);
      this.toolStripDefault.Name = "toolStripDefault";
      this.toolStripDefault.Size = new System.Drawing.Size(1437, 25);
      this.toolStripDefault.TabIndex = 21;
      this.toolStripDefault.Text = "toolStrip1";
      // 
      // toolStripDropDownButton1
      // 
      this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.書き出すToolStripMenuItem,
            this.toolStripMenuItem1,
            this.動画Aを読み込むToolStripMenuItem,
            this.動画Bを読み込むToolStripMenuItem});
      this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
      this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new System.Drawing.Size(53, 22);
      this.toolStripDropDownButton1.Text = "メニュー";
      // 
      // 書き出すToolStripMenuItem
      // 
      this.書き出すToolStripMenuItem.Name = "書き出すToolStripMenuItem";
      this.書き出すToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.書き出すToolStripMenuItem.Text = "書き出す(&E) ...";
      this.書き出すToolStripMenuItem.Click += new System.EventHandler(this.export_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 6);
      // 
      // 動画Aを読み込むToolStripMenuItem
      // 
      this.動画Aを読み込むToolStripMenuItem.Name = "動画Aを読み込むToolStripMenuItem";
      this.動画Aを読み込むToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.動画Aを読み込むToolStripMenuItem.Text = "動画Aを読み込む ...";
      // 
      // 動画Bを読み込むToolStripMenuItem
      // 
      this.動画Bを読み込むToolStripMenuItem.Name = "動画Bを読み込むToolStripMenuItem";
      this.動画Bを読み込むToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.動画Bを読み込むToolStripMenuItem.Text = "動画Bを読み込む ...";
      // 
      // PlayerWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1437, 631);
      this.Controls.Add(this.toolStripDefault);
      this.Controls.Add(this.hScrollBarB);
      this.Controls.Add(this.hScrollBarA);
      this.Controls.Add(this.pictureBoxVideo);
      this.ImeMode = System.Windows.Forms.ImeMode.Alpha;
      this.Name = "PlayerWindow";
      this.Text = "車載動画分析";
      this.Activated += new System.EventHandler(this.PlayerWindow_Activated);
      this.Resize += new System.EventHandler(this.PlayerWindow_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
      this.toolStripDefault.ResumeLayout(false);
      this.toolStripDefault.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxVideo;
    private System.Windows.Forms.HScrollBar hScrollBarA;
    private System.Windows.Forms.HScrollBar hScrollBarB;
    private System.Windows.Forms.ToolStripTextBox currentFramePosA;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripTextBox currentFramePosB;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripComboBox markers;
    private System.Windows.Forms.ToolStripButton createMarker;
    private System.Windows.Forms.ToolStripButton deleteMarker;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton prev6frames;
    private System.Windows.Forms.ToolStripButton prev1frame;
    private System.Windows.Forms.ToolStripButton next1frame;
    private System.Windows.Forms.ToolStripButton next6frames;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStrip toolStripDefault;
    private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    private System.Windows.Forms.ToolStripMenuItem 書き出すToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem 動画Aを読み込むToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 動画Bを読み込むToolStripMenuItem;
  }
}