namespace Ruutu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.avaabtn = new System.Windows.Forms.Button();
            this.urlboksi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anna ohjelman URL-osoite:";
            // 
            // avaabtn
            // 
            this.avaabtn.Location = new System.Drawing.Point(197, 25);
            this.avaabtn.Name = "avaabtn";
            this.avaabtn.Size = new System.Drawing.Size(75, 23);
            this.avaabtn.TabIndex = 1;
            this.avaabtn.Text = "Avaa";
            this.avaabtn.UseVisualStyleBackColor = true;
            this.avaabtn.Click += new System.EventHandler(this.avaabtn_Click);
            // 
            // urlboksi
            // 
            this.urlboksi.Location = new System.Drawing.Point(12, 25);
            this.urlboksi.Name = "urlboksi";
            this.urlboksi.Size = new System.Drawing.Size(175, 20);
            this.urlboksi.TabIndex = 2;
            // 
            // Form1
            // 
            this.AcceptButton = this.avaabtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 56);
            this.Controls.Add(this.urlboksi);
            this.Controls.Add(this.avaabtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ruutu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button avaabtn;
        private System.Windows.Forms.TextBox urlboksi;
    }
}

