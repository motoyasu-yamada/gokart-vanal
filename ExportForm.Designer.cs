
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
      this.lengthMillis = new System.Windows.Forms.ComboBox();
      this.imageDecompositionIntervalMillis = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.exportImages = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.progressOfExportImages = new System.Windows.Forms.ProgressBar();
      this.fileNameTemplate = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.folder = new System.Windows.Forms.TextBox();
      this.chooseFolder = new System.Windows.Forms.Button();
      this.workerToExportImages = new System.ComponentModel.BackgroundWorker();
      this.SuspendLayout();
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(12, 69);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(69, 12);
      this.label9.TabIndex = 20;
      this.label9.Text = "ファイル名(&N):";
      // 
      // lengthMillis
      // 
      this.lengthMillis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.lengthMillis.FormattingEnabled = true;
      this.lengthMillis.Items.AddRange(new object[] {
            "1500",
            "3000",
            "5000",
            "7000"});
      this.lengthMillis.Location = new System.Drawing.Point(107, 124);
      this.lengthMillis.Name = "lengthMillis";
      this.lengthMillis.Size = new System.Drawing.Size(86, 20);
      this.lengthMillis.TabIndex = 12;
      // 
      // imageDecompositionIntervalMillis
      // 
      this.imageDecompositionIntervalMillis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.imageDecompositionIntervalMillis.FormattingEnabled = true;
      this.imageDecompositionIntervalMillis.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500"});
      this.imageDecompositionIntervalMillis.Location = new System.Drawing.Point(107, 162);
      this.imageDecompositionIntervalMillis.Name = "imageDecompositionIntervalMillis";
      this.imageDecompositionIntervalMillis.Size = new System.Drawing.Size(86, 20);
      this.imageDecompositionIntervalMillis.TabIndex = 13;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(202, 128);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(31, 12);
      this.label3.TabIndex = 14;
      this.label3.Text = "ミリ秒";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 128);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(84, 12);
      this.label5.TabIndex = 16;
      this.label5.Text = "書き出す長さ(&L):";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 166);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(89, 12);
      this.label6.TabIndex = 17;
      this.label6.Text = "書き出し間隔(&V):";
      // 
      // exportImages
      // 
      this.exportImages.Location = new System.Drawing.Point(302, 247);
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
      this.label4.Location = new System.Drawing.Point(202, 166);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(31, 12);
      this.label4.TabIndex = 19;
      this.label4.Text = "ミリ秒";
      // 
      // progressOfExportImages
      // 
      this.progressOfExportImages.Location = new System.Drawing.Point(12, 211);
      this.progressOfExportImages.Name = "progressOfExportImages";
      this.progressOfExportImages.Size = new System.Drawing.Size(446, 23);
      this.progressOfExportImages.TabIndex = 20;
      // 
      // fileNameTemplate
      // 
      this.fileNameTemplate.Location = new System.Drawing.Point(12, 86);
      this.fileNameTemplate.Name = "fileNameTemplate";
      this.fileNameTemplate.Size = new System.Drawing.Size(349, 19);
      this.fileNameTemplate.TabIndex = 4;
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
      // ExportForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(477, 295);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.progressOfExportImages);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.imageDecompositionIntervalMillis);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.exportImages);
      this.Controls.Add(this.lengthMillis);
      this.Controls.Add(this.fileNameTemplate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.folder);
      this.Controls.Add(this.chooseFolder);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ExportForm";
      this.Text = "書き出し";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox lengthMillis;
    private System.Windows.Forms.ComboBox imageDecompositionIntervalMillis;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button exportImages;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox fileNameTemplate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox folder;
    private System.Windows.Forms.Button chooseFolder;
    private System.ComponentModel.BackgroundWorker workerToExportImages;
    private System.Windows.Forms.ProgressBar progressOfExportImages;
  }
}