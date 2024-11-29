namespace Gruppenseminar2425 {
  partial class Form1 {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.Button buttonTutorial;
      this.buttonOpenFile = new System.Windows.Forms.Button();
      buttonTutorial = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // buttonOpenFile
      // 
      this.buttonOpenFile.Location = new System.Drawing.Point(30, 17);
      this.buttonOpenFile.Name = "buttonOpenFile";
      this.buttonOpenFile.Size = new System.Drawing.Size(177, 54);
      this.buttonOpenFile.TabIndex = 0;
      this.buttonOpenFile.Text = "button1";
      this.buttonOpenFile.UseVisualStyleBackColor = true;
      this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
      // 
      // buttonTutorial
      // 
      buttonTutorial.Location = new System.Drawing.Point(620, 23);
      buttonTutorial.Name = "buttonTutorial";
      buttonTutorial.Size = new System.Drawing.Size(153, 47);
      buttonTutorial.TabIndex = 1;
      buttonTutorial.Text = "Tutorial-Button";
      buttonTutorial.UseVisualStyleBackColor = true;
      buttonTutorial.Click += new System.EventHandler(this.buttonTutorial_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(buttonTutorial);
      this.Controls.Add(this.buttonOpenFile);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
    }
}

