
namespace gokart_vanal
{
  partial class ExportForm
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
      this.label9 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lengthOfVideo = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.exportVideo = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.numberOfImages = new System.Windows.Forms.ComboBox();
      this.intervalOfImages = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.exportImages = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.filename = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.folder = new System.Windows.Forms.TextBox();
      this.chooseFolder = new System.Windows.Forms.Button();
      this.workerToExportImages = new System.ComponentModel.BackgroundWorker();
      this.progressOfExportImages = new System.Windows.Forms.ProgressBar();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(13, 69);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(69, 12);
      this.label9.TabIndex = 20;
      this.label9.Text = "ファイル名(&N):";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(139, 27);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(17, 12);
      this.label7.TabIndex = 20;
      this.label7.Text = "秒";
      // 
      // lengthOfVideo
      // 
      this.lengthOfVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.lengthOfVideo.FormattingEnabled = true;
      this.lengthOfVideo.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "10",
            "15",
            "30",
            "40",
            "50",
            "60"});
      this.lengthOfVideo.Location = new System.Drawing.Point(46, 23);
      this.lengthOfVideo.Name = "lengthOfVideo";
      this.lengthOfVideo.Size = new System.Drawing.Size(86, 20);
      this.lengthOfVideo.TabIndex = 19;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 12);
      this.label1.TabIndex = 21;
      this.label1.Text = "長さ:";
      // 
      // exportVideo
      // 
      this.exportVideo.Enabled = false;
      this.exportVideo.Location = new System.Drawing.Point(16, 55);
      this.exportVideo.Name = "exportVideo";
      this.exportVideo.Size = new System.Drawing.Size(412, 23);
      this.exportVideo.TabIndex = 19;
      this.exportVideo.Text = "書き出し";
      this.exportVideo.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.exportVideo);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.lengthOfVideo);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Enabled = false;
      this.groupBox2.Location = new System.Drawing.Point(12, 249);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(446, 93);
      this.groupBox2.TabIndex = 17;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "動画";
      // 
      // numberOfImages
      // 
      this.numberOfImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.numberOfImages.FormattingEnabled = true;
      this.numberOfImages.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30"});
      this.numberOfImages.Location = new System.Drawing.Point(72, 24);
      this.numberOfImages.Name = "numberOfImages";
      this.numberOfImages.Size = new System.Drawing.Size(86, 20);
      this.numberOfImages.TabIndex = 12;
      // 
      // intervalOfImages
      // 
      this.intervalOfImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.intervalOfImages.FormattingEnabled = true;
      this.intervalOfImages.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500"});
      this.intervalOfImages.Location = new System.Drawing.Point(272, 24);
      this.intervalOfImages.Name = "intervalOfImages";
      this.intervalOfImages.Size = new System.Drawing.Size(86, 20);
      this.intervalOfImages.TabIndex = 13;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(161, 28);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(17, 12);
      this.label3.TabIndex = 14;
      this.label3.Text = "枚";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(14, 28);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 12);
      this.label5.TabIndex = 16;
      this.label5.Text = "画像枚数:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(196, 28);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(73, 12);
      this.label6.TabIndex = 17;
      this.label6.Text = "書き出し間隔:";
      // 
      // exportImages
      // 
      this.exportImages.Location = new System.Drawing.Point(272, 61);
      this.exportImages.Name = "exportImages";
      this.exportImages.Size = new System.Drawing.Size(156, 23);
      this.exportImages.TabIndex = 18;
      this.exportImages.Text = "書き出し";
      this.exportImages.UseVisualStyleBackColor = true;
      this.exportImages.Click += new System.EventHandler(this.exportImages_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(364, 28);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(31, 12);
      this.label4.TabIndex = 19;
      this.label4.Text = "ミリ秒";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.progressOfExportImages);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.exportImages);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.intervalOfImages);
      this.groupBox1.Controls.Add(this.numberOfImages);
      this.groupBox1.Location = new System.Drawing.Point(12, 126);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(446, 102);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "分解画像";
      // 
      // filename
      // 
      this.filename.Location = new System.Drawing.Point(12, 86);
      this.filename.Name = "filename";
      this.filename.Size = new System.Drawing.Size(349, 19);
      this.filename.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(121, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "書き出し先フォルダー(&F):";
      // 
      // folder
      // 
      this.folder.Location = new System.Drawing.Point(12, 38);
      this.folder.Name = "folder";
      this.folder.Size = new System.Drawing.Size(349, 19);
      this.folder.TabIndex = 1;
      // 
      // chooseFolder
      // 
      this.chooseFolder.Location = new System.Drawing.Point(367, 36);
      this.chooseFolder.Name = "chooseFolder";
      this.chooseFolder.Size = new System.Drawing.Size(91, 23);
      this.chooseFolder.TabIndex = 0;
      this.chooseFolder.Text = "選択する(&S)...";
      this.chooseFolder.UseVisualStyleBackColor = true;
      this.chooseFolder.Click += new System.EventHandler(this.chooseFolder_Click);
      // 
      // workerToExportImages
      // 
      this.workerToExportImages.WorkerReportsProgress = true;
      this.workerToExportImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerToExportImages_DoWork);
      this.workerToExportImages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerToExportImages_ProgressChanged);
      this.workerToExportImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerToExportImages_RunWorkerCompleted);
      // 
      // progressOfExportImages
      // 
      this.progressOfExportImages.Location = new System.Drawing.Point(16, 61);
      this.progressOfExportImages.Name = "progressOfExportImages";
      this.progressOfExportImages.Size = new System.Drawing.Size(253, 23);
      this.progressOfExportImages.TabIndex = 20;
      // 
      // ExportForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(484, 360);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.filename);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.folder);
      this.Controls.Add(this.chooseFolder);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ExportForm";
      this.Text = "書き出し";
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox lengthOfVideo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button exportVideo;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox numberOfImages;
    private System.Windows.Forms.ComboBox intervalOfImages;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button exportImages;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox filename;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox folder;
    private System.Windows.Forms.Button chooseFolder;
    private System.ComponentModel.BackgroundWorker workerToExportImages;
    private System.Windows.Forms.ProgressBar progressOfExportImages;
  }
}