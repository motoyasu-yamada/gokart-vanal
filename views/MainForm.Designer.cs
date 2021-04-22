
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.hScrollBarA = new System.Windows.Forms.HScrollBar();
      this.hScrollBarB = new System.Windows.Forms.HScrollBar();
      this.currentFramePosA = new System.Windows.Forms.ToolStripTextBox();
      this.currentFramePosB = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.markersA = new System.Windows.Forms.ToolStripComboBox();
      this.movePrev100ms = new System.Windows.Forms.ToolStripButton();
      this.movePrev1Frame = new System.Windows.Forms.ToolStripButton();
      this.moveNext1Frame = new System.Windows.Forms.ToolStripButton();
      this.moveNext100ms = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripDefault = new System.Windows.Forms.ToolStrip();
      this.moveMenu = new System.Windows.Forms.ToolStripDropDownButton();
      this.deckA = new System.Windows.Forms.ToolStripButton();
      this.jumpToLapA = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.deckB = new System.Windows.Forms.ToolStripButton();
      this.jumpToLapB = new System.Windows.Forms.ToolStripComboBox();
      this.markersB = new System.Windows.Forms.ToolStripComboBox();
      this.moveMenuA = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.moveMenuB = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.moveMenuButtonB = new System.Windows.Forms.Button();
      this.moveMenuButtonA = new System.Windows.Forms.Button();
      this.createMarkerA = new System.Windows.Forms.ToolStripButton();
      this.createMarkerB = new System.Windows.Forms.ToolStripButton();
      this.export = new System.Windows.Forms.ToolStripButton();
      this.options = new System.Windows.Forms.ToolStripButton();
      this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
      this.toolStripDefault.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
      this.SuspendLayout();
      // 
      // hScrollBarA
      // 
      this.hScrollBarA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBarA.LargeChange = 6;
      this.hScrollBarA.Location = new System.Drawing.Point(20, 25);
      this.hScrollBarA.Maximum = 6;
      this.hScrollBarA.Name = "hScrollBarA";
      this.hScrollBarA.Size = new System.Drawing.Size(980, 20);
      this.hScrollBarA.TabIndex = 18;
      this.hScrollBarA.ValueChanged += new System.EventHandler(this.hScrollBarA_ValueChanged);
      // 
      // hScrollBarB
      // 
      this.hScrollBarB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.hScrollBarB.LargeChange = 6;
      this.hScrollBarB.Location = new System.Drawing.Point(20, 445);
      this.hScrollBarB.Maximum = 6;
      this.hScrollBarB.Name = "hScrollBarB";
      this.hScrollBarB.Size = new System.Drawing.Size(980, 20);
      this.hScrollBarB.TabIndex = 20;
      this.hScrollBarB.ValueChanged += new System.EventHandler(this.hScrollBarB_ValueChanged);
      // 
      // currentFramePosA
      // 
      this.currentFramePosA.AutoSize = false;
      this.currentFramePosA.Enabled = false;
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
      this.currentFramePosB.Enabled = false;
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
      // markersA
      // 
      this.markersA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.markersA.Enabled = false;
      this.markersA.Name = "markersA";
      this.markersA.Size = new System.Drawing.Size(100, 25);
      this.markersA.ToolTipText = "A画面のマーカー一覧";
      this.markersA.SelectedIndexChanged += new System.EventHandler(this.markersA_SelectedIndexChanged);
      // 
      // movePrev100ms
      // 
      this.movePrev100ms.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.movePrev100ms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.movePrev100ms.ForeColor = System.Drawing.SystemColors.ControlText;
      this.movePrev100ms.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.movePrev100ms.Name = "movePrev100ms";
      this.movePrev100ms.Size = new System.Drawing.Size(63, 22);
      this.movePrev100ms.Text = "<< 100ms";
      this.movePrev100ms.ToolTipText = "A/B両画面を6フレーム戻す";
      this.movePrev100ms.Click += new System.EventHandler(this.movePrev100ms_Click);
      // 
      // movePrev1Frame
      // 
      this.movePrev1Frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.movePrev1Frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.movePrev1Frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.movePrev1Frame.Name = "movePrev1Frame";
      this.movePrev1Frame.Size = new System.Drawing.Size(32, 22);
      this.movePrev1Frame.Text = "< 1f";
      this.movePrev1Frame.ToolTipText = "A/B両画面を1フレーム戻す";
      this.movePrev1Frame.Click += new System.EventHandler(this.movePrev1Frame_Click);
      // 
      // moveNext1Frame
      // 
      this.moveNext1Frame.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.moveNext1Frame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.moveNext1Frame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.moveNext1Frame.Name = "moveNext1Frame";
      this.moveNext1Frame.Size = new System.Drawing.Size(32, 22);
      this.moveNext1Frame.Text = "1f >";
      this.moveNext1Frame.ToolTipText = "A/B両画面を1フレーム進める(右カーソルキー)";
      this.moveNext1Frame.Click += new System.EventHandler(this.moveNext1Frame_Click);
      // 
      // moveNext100ms
      // 
      this.moveNext100ms.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
      this.moveNext100ms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.moveNext100ms.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.moveNext100ms.Name = "moveNext100ms";
      this.moveNext100ms.Size = new System.Drawing.Size(63, 22);
      this.moveNext100ms.Text = "100ms >>";
      this.moveNext100ms.ToolTipText = "A/B両画面を100ms進める (上矢印キー)";
      this.moveNext100ms.Click += new System.EventHandler(this.moveNext100ms_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripDefault
      // 
      this.toolStripDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.toolStripDefault.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStripDefault.GripMargin = new System.Windows.Forms.Padding(6);
      this.toolStripDefault.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.toolStripDefault.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movePrev100ms,
            this.movePrev1Frame,
            this.moveNext1Frame,
            this.moveNext100ms,
            this.moveMenu,
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
            this.export,
            this.options});
      this.toolStripDefault.Location = new System.Drawing.Point(0, 0);
      this.toolStripDefault.Name = "toolStripDefault";
      this.toolStripDefault.Size = new System.Drawing.Size(967, 25);
      this.toolStripDefault.TabIndex = 1;
      this.toolStripDefault.Text = "デフォルト";
      // 
      // moveMenu
      // 
      this.moveMenu.Name = "moveMenu";
      this.moveMenu.Size = new System.Drawing.Size(13, 22);
      this.moveMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.moveMenu_DropDownItemClicked);
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
      this.markersB.SelectedIndexChanged += new System.EventHandler(this.markersB_SelectedIndexChanged);
      // 
      // moveMenuA
      // 
      this.moveMenuA.Name = "moveMenuA";
      this.moveMenuA.Size = new System.Drawing.Size(61, 4);
      this.moveMenuA.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.moveMenuA_ItemClicked);
      // 
      // moveMenuB
      // 
      this.moveMenuB.Name = "moveMenuA";
      this.moveMenuB.Size = new System.Drawing.Size(61, 4);
      this.moveMenuB.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.moveMenuB_ItemClicked);
      // 
      // moveMenuButtonB
      // 
      this.moveMenuButtonB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.moveMenuButtonB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.moveMenuButtonB.Image = ((System.Drawing.Image)(resources.GetObject("moveMenuButtonB.Image")));
      this.moveMenuButtonB.Location = new System.Drawing.Point(0, 445);
      this.moveMenuButtonB.Name = "moveMenuButtonB";
      this.moveMenuButtonB.Size = new System.Drawing.Size(20, 20);
      this.moveMenuButtonB.TabIndex = 22;
      this.moveMenuButtonB.UseVisualStyleBackColor = true;
      this.moveMenuButtonB.Click += new System.EventHandler(this.moveMenuButtonB_Click);
      // 
      // moveMenuButtonA
      // 
      this.moveMenuButtonA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.moveMenuButtonA.Image = ((System.Drawing.Image)(resources.GetObject("moveMenuButtonA.Image")));
      this.moveMenuButtonA.Location = new System.Drawing.Point(0, 25);
      this.moveMenuButtonA.Name = "moveMenuButtonA";
      this.moveMenuButtonA.Size = new System.Drawing.Size(20, 20);
      this.moveMenuButtonA.TabIndex = 21;
      this.moveMenuButtonA.UseVisualStyleBackColor = true;
      this.moveMenuButtonA.Click += new System.EventHandler(this.moveMenuButtonA_Click);
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
      this.export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.export.Image = global::gokart_vanal.Properties.Resources.ResultToCSV_16x;
      this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.export.Name = "export";
      this.export.Size = new System.Drawing.Size(23, 22);
      this.export.Text = "書き出す...";
      this.export.ToolTipText = "画像の書き出す...";
      this.export.Click += new System.EventHandler(this.export_Click);
      // 
      // options
      // 
      this.options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.options.Image = ((System.Drawing.Image)(resources.GetObject("options.Image")));
      this.options.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.options.Name = "options";
      this.options.Size = new System.Drawing.Size(23, 22);
      this.options.Text = "toolStripButton1";
      this.options.ToolTipText = "設定";
      this.options.Click += new System.EventHandler(this.options_Click);
      // 
      // pictureBoxVideo
      // 
      this.pictureBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBoxVideo.Location = new System.Drawing.Point(0, 45);
      this.pictureBoxVideo.Name = "pictureBoxVideo";
      this.pictureBoxVideo.Size = new System.Drawing.Size(1000, 400);
      this.pictureBoxVideo.TabIndex = 0;
      this.pictureBoxVideo.TabStop = false;
      this.pictureBoxVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragDrop);
      this.pictureBoxVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragEnter);
      this.pictureBoxVideo.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBoxVideo_DragOver);
      this.pictureBoxVideo.DragLeave += new System.EventHandler(this.pictureBoxVideo_DragLeave);
      this.pictureBoxVideo.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxVideo_Paint);
      this.pictureBoxVideo.Resize += new System.EventHandler(this.pictureBoxVideo_Resize);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1000, 465);
      this.Controls.Add(this.moveMenuButtonB);
      this.Controls.Add(this.moveMenuButtonA);
      this.Controls.Add(this.toolStripDefault);
      this.Controls.Add(this.hScrollBarB);
      this.Controls.Add(this.hScrollBarA);
      this.Controls.Add(this.pictureBoxVideo);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.ImeMode = System.Windows.Forms.ImeMode.Alpha;
      this.Name = "MainForm";
      this.Text = "GoKART VANAL - 車載動画分析";
      this.Activated += new System.EventHandler(this.PlayerWindow_Activated);
      this.Resize += new System.EventHandler(this.PlayerWindow_Resize);
      this.toolStripDefault.ResumeLayout(false);
      this.toolStripDefault.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
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
    private System.Windows.Forms.ToolStripButton movePrev100ms;
    private System.Windows.Forms.ToolStripButton movePrev1Frame;
    private System.Windows.Forms.ToolStripButton moveNext1Frame;
    private System.Windows.Forms.ToolStripButton moveNext100ms;
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
    private System.Windows.Forms.ToolStripDropDownButton moveMenu;
    private System.Windows.Forms.Button moveMenuButtonA;
    private System.Windows.Forms.Button moveMenuButtonB;
    private System.Windows.Forms.ContextMenuStrip moveMenuA;
    private System.Windows.Forms.ContextMenuStrip moveMenuB;
    private System.Windows.Forms.ToolStripButton options;
  }
}