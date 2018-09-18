namespace ServisDB.Forme
{

  partial class dlgReports
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
      this.lbReports = new System.Windows.Forms.ListBox();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbReports
      // 
      this.lbReports.FormattingEnabled = true;
      this.lbReports.ItemHeight = 16;
      this.lbReports.Location = new System.Drawing.Point(33, 33);
      this.lbReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.lbReports.Name = "lbReports";
      this.lbReports.ScrollAlwaysVisible = true;
      this.lbReports.Size = new System.Drawing.Size(463, 292);
      this.lbReports.TabIndex = 0;
      this.lbReports.DoubleClick += new System.EventHandler(this.lbReports_DoubleClick);
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(167, 335);
      this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(100, 28);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(275, 335);
      this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(100, 28);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Zatvori";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // dlgReports
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.LightSteelBlue;
      this.ClientSize = new System.Drawing.Size(531, 383);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lbReports);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "dlgReports";
      this.Text = "Izvještaji";
      this.Load += new System.EventHandler(this.dlgReports_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lbReports;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnClose;
  }
}