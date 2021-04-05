
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
      this.deckA = new System.Windows.Forms.ToolStripButton();
      this.deckB = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.export = new System.Windows.Forms.ToolStripButton();
      this.jumpToLapA = new System.Windows.Forms.ToolStripComboBox();
      this.jumpToLapB = new System.Windows.Forms.ToolStripComboBox();
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
      this.currentFramePosA.AutoSize = false;
      this.currentFramePosA.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
      this.currentFramePosA.Name = "currentFramePosA";
      this.currentFramePosA.Size = new System.Drawing.Size(75, 25);
      this.currentFramePosA.Text = "0";
      this.currentFramePosA.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.currentFramePosA.ToolTipText = "A画面(上または左)のフレーム位置";
      // 
      // currentFramePosB
      // 
      this.currentFramePosB.AutoSize = false;
      this.currentFramePosB.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
      this.currentFramePosB.Name = "currentFramePosB";
      this.currentFramePosB.Size = new System.Drawing.Size(75, 25);
      this.currentFramePosB.Text = "0";
      this.currentFramePosB.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.currentFramePosB.ToolTipText = "B画面(下または右)のフレーム位置";
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
      this.createMarker.Size = new System.Drawing.Size(44, 22);
      this.createMarker.Text = "保存...";
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
      this.toolStripDefault.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.toolStripDefault.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deckA,
            this.jumpToLapA,
            this.currentFramePosA,
            this.toolStripSeparator4,
            this.deckB,
            this.jumpToLapB,
            this.currentFramePosB,
            this.toolStripSeparator1,
            this.prev6frames,
            this.prev1frame,
            this.next1frame,
            this.next6frames,
            this.toolStripSeparator3,
            this.markers,
            this.createMarker,
            this.deleteMarker,
            this.toolStripSeparator2,
            this.export});
      this.toolStripDefault.Location = new System.Drawing.Point(0, 0);
      this.toolStripDefault.Name = "toolStripDefault";
      this.toolStripDefault.Size = new System.Drawing.Size(1437, 25);
      this.toolStripDefault.TabIndex = 1;
      this.toolStripDefault.Text = "デフォルト";
      // 
      // deckA
      // 
      this.deckA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.deckA.Image = ((System.Drawing.Image)(resources.GetObject("deckA.Image")));
      this.deckA.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deckA.Name = "deckA";
      this.deckA.Size = new System.Drawing.Size(44, 22);
      this.deckA.Text = "A(&A)...";
      this.deckA.Click += new System.EventHandler(this.deckA_Click);
      // 
      // deckB
      // 
      this.deckB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.deckB.Image = ((System.Drawing.Image)(resources.GetObject("deckB.Image")));
      this.deckB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deckB.Name = "deckB";
      this.deckB.Size = new System.Drawing.Size(42, 22);
      this.deckB.Text = "B(&B)...";
      this.deckB.Click += new System.EventHandler(this.deckB_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // export
      // 
      this.export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.export.Image = ((System.Drawing.Image)(resources.GetObject("export.Image")));
      this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.export.Name = "export";
      this.export.Size = new System.Drawing.Size(63, 22);
      this.export.Text = "書き出す...";
      this.export.Click += new System.EventHandler(this.export_Click);
      // 
      // jumpToLapA
      // 
      this.jumpToLapA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.jumpToLapA.Name = "jumpToLapA";
      this.jumpToLapA.Size = new System.Drawing.Size(121, 25);
      this.jumpToLapA.SelectedIndexChanged += new System.EventHandler(this.jumpToLapA_SelectedIndexChanged);
      // 
      // jumpToLapB
      // 
      this.jumpToLapB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.jumpToLapB.Name = "jumpToLapB";
      this.jumpToLapB.Size = new System.Drawing.Size(121, 25);
      this.jumpToLapB.SelectedIndexChanged += new System.EventHandler(this.jumpToLapB_SelectedIndexChanged);
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
    private System.Windows.Forms.ToolStripButton deckB;
    private System.Windows.Forms.ToolStripButton deckA;
    private System.Windows.Forms.ToolStripButton export;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripComboBox jumpToLapA;
    private System.Windows.Forms.ToolStripComboBox jumpToLapB;
  }
}