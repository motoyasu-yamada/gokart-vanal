
namespace gokart_vanal.views
{
  partial class OptionsForm
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
            this.gridTypeList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.layoutTypeList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // gridTypeList
            // 
            this.gridTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridTypeList.FormattingEnabled = true;
            this.gridTypeList.Items.AddRange(new object[] {
            "表示しない",
            "表示する (10x4)",
            "表示する (20x8)"});
            this.gridTypeList.Location = new System.Drawing.Point(117, 24);
            this.gridTypeList.Name = "gridTypeList";
            this.gridTypeList.Size = new System.Drawing.Size(143, 20);
            this.gridTypeList.TabIndex = 0;
            this.gridTypeList.SelectedIndexChanged += new System.EventHandler(this.gridTypeList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "グリッド表示(&G):";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "レイアウト(&L):";
            // 
            // layoutTypeList
            // 
            this.layoutTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutTypeList.FormattingEnabled = true;
            this.layoutTypeList.Items.AddRange(new object[] {
            "縦に並べる",
            "横に並べる"});
            this.layoutTypeList.Location = new System.Drawing.Point(117, 70);
            this.layoutTypeList.Name = "layoutTypeList";
            this.layoutTypeList.Size = new System.Drawing.Size(143, 20);
            this.layoutTypeList.TabIndex = 3;
            this.layoutTypeList.SelectedIndexChanged += new System.EventHandler(this.layoutTypeList_SelectedIndexChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 320);
            this.Controls.Add(this.layoutTypeList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridTypeList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "設定画面";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox gridTypeList;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox layoutTypeList;
    }
}