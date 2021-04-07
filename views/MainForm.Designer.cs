
namespace gokart_vanal
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
      this.hScrollBarA = new System.Windows.Forms.HScrollBar();
      this.hScrollBarB = new System.Windows.Forms.HScrollBar();
      this.currentFramePosA = new System.Windows.Forms.ToolStripTextBox();
      this.currentFramePosB = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.markersA = new System.Windows.Forms.ToolStripComboBox();
      this.createMarkerA = new System.Windows.Forms.ToolStripButton();
      this.prev6frames = new System.Windows.Forms.ToolStripButton();
      this.prev1frame = new System.Windows.Forms.ToolStripButton();
      this.next1frame = new System.Windows.Forms.ToolStripButton();
      this.next6frames = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripDefault = new System.Windows.Forms.ToolStrip();
      this.deckA = new System.Windows.Forms.ToolStripButton();
      this.jumpToLapA = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.deckB = new System.Windows.Forms.ToolStripButton();
      this.jumpToLapB = new System.Windows.Forms.ToolStripComboBox();
      this.markersB = new System.Windows.Forms.ToolStripComboBox();
      this.createMarkerB = new System.Windows.Forms.ToolStripButton();
      this.export = new System.Windows.Forms.ToolStripButton();
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
      this.currentFramePosA.Enabled = false;
      this.currentFramePosA.Name = "currentFramePosA";
      this.currentFramePosA.Size = new System.Drawing.Size(75, 25);
      this.currentFramePosA.Text = "0";
      this.currentFramePosA.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.currentFramePosA.ToolTipText = "A画面(上または左)のフレーム位置";
      // 
      // currentFramePosB
      // 
      this.currentFramePosB.AutoSize = false;
      this.currentFramePosB.Enabled = false;
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
      // markersA
      // 
      this.markersA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.markersA.Enabled = false;
      this.markersA.Name = "markersA";
      this.markersA.Size = new System.Drawing.Size(100, 25);
      this.markersA.ToolTipText = "A画面のマーカー一覧";
      this.markersA.SelectedIndexChanged += new System.EventHandler(this.markersA_SelectedIndexChanged);
      // 
      // createMarkerA
      // 
      this.createMarkerA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.createMarkerA.Image = ((System.Drawing.Image)(resources.GetObject("createMarkerA.Image")));
      this.createMarkerA.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.createMarkerA.Name = "createMarkerA";
      this.createMarkerA.Size = new System.Drawing.Size(23, 22);
      this.createMarkerA.ToolTipText = "A画面の現在のフレーム位置をマーカーとして保存します。";
      this.createMarkerA.Click += new System.EventHandler(this.createMarkerA_Click);
      // 
      // prev6frames
      // 
      this.prev6frames.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.prev6frames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.prev6frames.ForeColor = System.Drawing.SystemColors.ControlText;
      this.prev6frames.Image = ((System.Drawing.Image)(resources.GetObject("prev6frames.Image")));
      this.prev6frames.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.prev6frames.Name = "prev6frames";
      this.prev6frames.Size = new System.Drawing.Size(23, 22);
      this.prev6frames.ToolTipText = "A/B両画面を6フレーム戻す";
      this.prev6frames.Click += new System.EventHandler(this.prev6frames_Click);
      // 
      // prev1frame
      // 
      this.prev1frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.prev1frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.prev1frame.Image = ((System.Drawing.Image)(resources.GetObject("prev1frame.Image")));
      this.prev1frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.prev1frame.Name = "prev1frame";
      this.prev1frame.Size = new System.Drawing.Size(23, 22);
      this.prev1frame.ToolTipText = "A/B両画面を1フレーム戻す";
      this.prev1frame.Click += new System.EventHandler(this.prev1frame_Click);
      // 
      // next1frame
      // 
      this.next1frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.next1frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.next1frame.Image = ((System.Drawing.Image)(resources.GetObject("next1frame.Image")));
      this.next1frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.next1frame.Name = "next1frame";
      this.next1frame.Size = new System.Drawing.Size(23, 22);
      this.next1frame.ToolTipText = "A/B両画面を1フレーム進める";
      this.next1frame.Click += new System.EventHandler(this.next1frame_Click);
      // 
      // next6frames
      // 
      this.next6frames.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.next6frames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.next6frames.Image = ((System.Drawing.Image)(resources.GetObject("next6frames.Image")));
      this.next6frames.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.next6frames.Name = "next6frames";
      this.next6frames.Size = new System.Drawing.Size(23, 22);
      this.next6frames.Text = "6 >>";
      this.next6frames.ToolTipText = "A/B両画面を6フレーム進める";
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
            this.prev6frames,
            this.prev1frame,
            this.next1frame,
            this.next6frames,
            this.toolStripSeparator3,
            this.deckA,
            this.currentFramePosA,
            this.jumpToLapA,
            this.markersA,
            this.createMarkerA,
            this.toolStripSeparator4,
            this.deckB,
            this.currentFramePosB,
            this.jumpToLapB,
            this.markersB,
            this.createMarkerB,
            this.toolStripSeparator1,
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
      this.deckA.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deckA.Name = "deckA";
      this.deckA.Size = new System.Drawing.Size(28, 22);
      this.deckA.Text = "&A...";
      this.deckA.ToolTipText = "A画面(上または左)を設定する";
      this.deckA.Click += new System.EventHandler(this.deckA_Click);
      // 
      // jumpToLapA
      // 
      this.jumpToLapA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.jumpToLapA.Enabled = false;
      this.jumpToLapA.Name = "jumpToLapA";
      this.jumpToLapA.Size = new System.Drawing.Size(100, 25);
      this.jumpToLapA.ToolTipText = "A画面を指定したラップへ移動する";
      this.jumpToLapA.SelectedIndexChanged += new System.EventHandler(this.jumpToLapA_SelectedIndexChanged);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // deckB
      // 
      this.deckB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.deckB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.deckB.Name = "deckB";
      this.deckB.Size = new System.Drawing.Size(27, 22);
      this.deckB.Text = "&B...";
      this.deckB.ToolTipText = "B画面(下または右)を設定する";
      this.deckB.Click += new System.EventHandler(this.deckB_Click);
      // 
      // jumpToLapB
      // 
      this.jumpToLapB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.jumpToLapB.Enabled = false;
      this.jumpToLapB.Name = "jumpToLapB";
      this.jumpToLapB.Size = new System.Drawing.Size(100, 25);
      this.jumpToLapB.ToolTipText = "B画面を指定したラップへ移動する";
      this.jumpToLapB.SelectedIndexChanged += new System.EventHandler(this.jumpToLapB_SelectedIndexChanged);
      // 
      // markersB
      // 
      this.markersB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.markersB.Enabled = false;
      this.markersB.Name = "markersB";
      this.markersB.Size = new System.Drawing.Size(100, 25);
      this.markersB.ToolTipText = "B画面のマーカー一覧";
      // 
      // createMarkerB
      // 
      this.createMarkerB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.createMarkerB.Image = ((System.Drawing.Image)(resources.GetObject("createMarkerB.Image")));
      this.createMarkerB.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.createMarkerB.Name = "createMarkerB";
      this.createMarkerB.Size = new System.Drawing.Size(23, 22);
      this.createMarkerB.ToolTipText = "B画面の現在のフレーム位置をマーカーとして保存します。";
      this.createMarkerB.Click += new System.EventHandler(this.createMarkerB_Click);
      // 
      // export
      // 
      this.export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.export.Name = "export";
      this.export.Size = new System.Drawing.Size(63, 22);
      this.export.Text = "書き出す...";
      this.export.Click += new System.EventHandler(this.export_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1437, 631);
      this.Controls.Add(this.toolStripDefault);
      this.Controls.Add(this.hScrollBarB);
      this.Controls.Add(this.hScrollBarA);
      this.Controls.Add(this.pictureBoxVideo);
      this.ImeMode = System.Windows.Forms.ImeMode.Alpha;
      this.Name = "MainForm";
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
    private System.Windows.Forms.ToolStripComboBox markersA;
    private System.Windows.Forms.ToolStripButton createMarkerA;
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
    private System.Windows.Forms.ToolStripComboBox markersB;
    private System.Windows.Forms.ToolStripButton createMarkerB;
  }
}