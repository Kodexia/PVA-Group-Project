namespace TEST_9._10
{
  partial class Form1
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.AnswerLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(59, 99);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(605, 31);
      this.textBox1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(54, 37);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(348, 25);
      this.label1.TabIndex = 1;
      this.label1.Text = "Zadejte řadu čísel oddšelná čárkou";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(73, 71);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(197, 25);
      this.label2.TabIndex = 2;
      this.label2.Text = "(např. \"10,20.5,30\")";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(191, 182);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(322, 90);
      this.button1.TabIndex = 3;
      this.button1.Text = "Spočítat průměr";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // AnswerLabel
      // 
      this.AnswerLabel.Font = new System.Drawing.Font("ROG Fonts", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AnswerLabel.Location = new System.Drawing.Point(12, 275);
      this.AnswerLabel.Name = "AnswerLabel";
      this.AnswerLabel.Size = new System.Drawing.Size(697, 191);
      this.AnswerLabel.TabIndex = 4;
      this.AnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(747, 475);
      this.Controls.Add(this.AnswerLabel);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label AnswerLabel;
  }
}

