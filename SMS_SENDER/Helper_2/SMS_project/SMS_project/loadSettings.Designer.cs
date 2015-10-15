namespace SMS_project
{
    partial class loadSettings
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
            this.Serial_Num = new System.Windows.Forms.Label();
            this.Revision_Num = new System.Windows.Forms.Label();
            this.Phone_Model = new System.Windows.Forms.Label();
            this.Phone_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Serial_Num
            // 
            this.Serial_Num.AutoSize = true;
            this.Serial_Num.Location = new System.Drawing.Point(255, 197);
            this.Serial_Num.Name = "Serial_Num";
            this.Serial_Num.Size = new System.Drawing.Size(22, 13);
            this.Serial_Num.TabIndex = 40;
            this.Serial_Num.Text = ".....";
            // 
            // Revision_Num
            // 
            this.Revision_Num.AutoSize = true;
            this.Revision_Num.Location = new System.Drawing.Point(255, 165);
            this.Revision_Num.Name = "Revision_Num";
            this.Revision_Num.Size = new System.Drawing.Size(22, 13);
            this.Revision_Num.TabIndex = 39;
            this.Revision_Num.Text = ".....";
            // 
            // Phone_Model
            // 
            this.Phone_Model.AutoSize = true;
            this.Phone_Model.Location = new System.Drawing.Point(255, 132);
            this.Phone_Model.Name = "Phone_Model";
            this.Phone_Model.Size = new System.Drawing.Size(22, 13);
            this.Phone_Model.TabIndex = 38;
            this.Phone_Model.Text = ".....";
            // 
            // Phone_Name
            // 
            this.Phone_Name.AutoSize = true;
            this.Phone_Name.Location = new System.Drawing.Point(255, 100);
            this.Phone_Name.Name = "Phone_Name";
            this.Phone_Name.Size = new System.Drawing.Size(22, 13);
            this.Phone_Name.TabIndex = 37;
            this.Phone_Name.Text = ".....";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Serial # :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(107, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 35;
            this.label22.Text = "Revision :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(107, 132);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 13);
            this.label21.TabIndex = 34;
            this.label21.Text = "Phone Model :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(107, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Phone Name :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = global::SMS_project.Properties.Resources.Connection_Dead;
            this.pictureBox3.Location = new System.Drawing.Point(402, 57);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 164);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // loadSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 279);
            this.Controls.Add(this.Serial_Num);
            this.Controls.Add(this.Revision_Num);
            this.Controls.Add(this.Phone_Model);
            this.Controls.Add(this.Phone_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "loadSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "loadSettings";
            this.Load += new System.EventHandler(this.loadSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Serial_Num;
        private System.Windows.Forms.Label Revision_Num;
        private System.Windows.Forms.Label Phone_Model;
        private System.Windows.Forms.Label Phone_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}