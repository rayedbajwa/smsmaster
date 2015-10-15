namespace Helper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SMS_Text = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rbMessagePhone = new System.Windows.Forms.RadioButton();
            this.rbMessageSIM = new System.Windows.Forms.RadioButton();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.read = new System.Windows.Forms.Button();
            this.smsgrid = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Single_SMS = new System.Windows.Forms.Button();
            this.Cell_Num = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Serial_Num = new System.Windows.Forms.Label();
            this.Revision_Num = new System.Windows.Forms.Label();
            this.Phone_Model = new System.Windows.Forms.Label();
            this.Phone_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.receive = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsgrid)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.receive.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Connection_Dead.JPG");
            this.imageList1.Images.SetKeyName(1, "Connection.JPG");
            this.imageList1.Images.SetKeyName(2, "Grabber.JPG");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Information";
            // 
            // SMS_Text
            // 
            this.SMS_Text.Location = new System.Drawing.Point(146, 120);
            this.SMS_Text.MaxLength = 160;
            this.SMS_Text.Multiline = true;
            this.SMS_Text.Name = "SMS_Text";
            this.SMS_Text.Size = new System.Drawing.Size(186, 163);
            this.SMS_Text.TabIndex = 8;
            this.SMS_Text.Text = "Your Text Message";
            this.toolTip1.SetToolTip(this.SMS_Text, "Maximum 160 Chracters");
            this.SMS_Text.TextChanged += new System.EventHandler(this.SMS_Text_TextChanged);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.DarkGreen;
            this.button9.Location = new System.Drawing.Point(3, 337);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(186, 22);
            this.button9.TabIndex = 21;
            this.button9.Text = "Get COM Port List";
            this.toolTip1.SetToolTip(this.button9, "Click On COM Port To Connect To Phone / Modem");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 181);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ShowCellToolTips = false;
            this.dataGridView3.Size = new System.Drawing.Size(394, 150);
            this.dataGridView3.TabIndex = 22;
            this.toolTip1.SetToolTip(this.dataGridView3, "Click On The COM Port To Connect To Phone / Modem");
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rbMessagePhone);
            this.tabPage3.Controls.Add(this.rbMessageSIM);
            this.tabPage3.Controls.Add(this.txtOutput);
            this.tabPage3.Controls.Add(this.read);
            this.tabPage3.Controls.Add(this.smsgrid);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(419, 382);
            this.tabPage3.TabIndex = 6;
            this.tabPage3.Text = "receive";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rbMessagePhone
            // 
            this.rbMessagePhone.AutoSize = true;
            this.rbMessagePhone.Location = new System.Drawing.Point(345, 194);
            this.rbMessagePhone.Name = "rbMessagePhone";
            this.rbMessagePhone.Size = new System.Drawing.Size(60, 19);
            this.rbMessagePhone.TabIndex = 60;
            this.rbMessagePhone.TabStop = true;
            this.rbMessagePhone.Text = "Phone";
            this.rbMessagePhone.UseVisualStyleBackColor = true;
            // 
            // rbMessageSIM
            // 
            this.rbMessageSIM.AutoSize = true;
            this.rbMessageSIM.Location = new System.Drawing.Point(294, 194);
            this.rbMessageSIM.Name = "rbMessageSIM";
            this.rbMessageSIM.Size = new System.Drawing.Size(45, 19);
            this.rbMessageSIM.TabIndex = 59;
            this.rbMessageSIM.TabStop = true;
            this.rbMessageSIM.Text = "Sim";
            this.rbMessageSIM.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(-25, 235);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(448, 144);
            this.txtOutput.TabIndex = 58;
            // 
            // read
            // 
            this.read.Location = new System.Drawing.Point(164, 207);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(75, 23);
            this.read.TabIndex = 1;
            this.read.Text = "Read";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // smsgrid
            // 
            this.smsgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.smsgrid.Location = new System.Drawing.Point(22, 19);
            this.smsgrid.Name = "smsgrid";
            this.smsgrid.Size = new System.Drawing.Size(372, 160);
            this.smsgrid.TabIndex = 0;
            this.smsgrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.smsgrid_CellClick);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel2);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(419, 382);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "About Me";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 376);
            this.panel2.TabIndex = 0;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(96, 219);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(219, 95);
            this.label30.TabIndex = 3;
            this.label30.Text = "SMS Sender Ver 1.0\r\n\r\nDeveloped By FaHaD\r\n\r\ncodeprojecthelper@gmail.com";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label30.DoubleClick += new System.EventHandler(this.label30_DoubleClick);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(118, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(175, 26);
            this.label27.TabIndex = 1;
            this.label27.Text = "BULK SMS SENDER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::Helper.Properties.Resources.Grabber;
            this.pictureBox1.Image = global::Helper.Properties.Resources.Grabber;
            this.pictureBox1.Location = new System.Drawing.Point(159, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(419, 382);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Multiple SMS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(140, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 60);
            this.button1.TabIndex = 40;
            this.button1.Text = "Open Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Red;
            this.button7.Location = new System.Drawing.Point(276, 39);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 29);
            this.button7.TabIndex = 31;
            this.button7.Text = "Check Values";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkGreen;
            this.button4.Location = new System.Drawing.Point(276, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 29);
            this.button4.TabIndex = 32;
            this.button4.Text = "Send SMS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(3, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 60);
            this.button3.TabIndex = 29;
            this.button3.Text = "Open Excel File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(89, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(229, 19);
            this.label25.TabIndex = 39;
            this.label25.Text = "M U L T I P L E  -  S M S  -  I N F O";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DarkRed;
            this.label24.Location = new System.Drawing.Point(52, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(323, 26);
            this.label24.TabIndex = 27;
            this.label24.Text = "M U L T I P L E  -  S M S -  S E N D E R";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(413, 255);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Single_SMS);
            this.tabPage2.Controls.Add(this.SMS_Text);
            this.tabPage2.Controls.Add(this.Cell_Num);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(419, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Single SMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 353);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 27);
            this.button2.TabIndex = 19;
            this.button2.Text = "Add new contact";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Max 160 Characters";
            // 
            // Single_SMS
            // 
            this.Single_SMS.Enabled = false;
            this.Single_SMS.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Single_SMS.Location = new System.Drawing.Point(146, 316);
            this.Single_SMS.Name = "Single_SMS";
            this.Single_SMS.Size = new System.Drawing.Size(186, 32);
            this.Single_SMS.TabIndex = 15;
            this.Single_SMS.Text = "S E N D";
            this.Single_SMS.UseVisualStyleBackColor = true;
            this.Single_SMS.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cell_Num
            // 
            this.Cell_Num.Location = new System.Drawing.Point(146, 94);
            this.Cell_Num.Name = "Cell_Num";
            this.Cell_Num.Size = new System.Drawing.Size(186, 23);
            this.Cell_Num.TabIndex = 7;
            this.Cell_Num.Text = "+92";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(79, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "S I N G L E  -  S M S - S E N D E R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "MESSAGE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "CELL NUMBER";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Serial_Num);
            this.panel1.Controls.Add(this.Revision_Num);
            this.panel1.Controls.Add(this.Phone_Model);
            this.panel1.Controls.Add(this.Phone_Name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.dataGridView3);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 368);
            this.panel1.TabIndex = 0;
            // 
            // Serial_Num
            // 
            this.Serial_Num.AutoSize = true;
            this.Serial_Num.Location = new System.Drawing.Point(153, 151);
            this.Serial_Num.Name = "Serial_Num";
            this.Serial_Num.Size = new System.Drawing.Size(22, 15);
            this.Serial_Num.TabIndex = 31;
            this.Serial_Num.Text = ".....";
            this.Serial_Num.Click += new System.EventHandler(this.Serial_Num_Click);
            // 
            // Revision_Num
            // 
            this.Revision_Num.AutoSize = true;
            this.Revision_Num.Location = new System.Drawing.Point(153, 119);
            this.Revision_Num.Name = "Revision_Num";
            this.Revision_Num.Size = new System.Drawing.Size(22, 15);
            this.Revision_Num.TabIndex = 30;
            this.Revision_Num.Text = ".....";
            this.Revision_Num.Click += new System.EventHandler(this.Revision_Num_Click);
            // 
            // Phone_Model
            // 
            this.Phone_Model.AutoSize = true;
            this.Phone_Model.Location = new System.Drawing.Point(153, 86);
            this.Phone_Model.Name = "Phone_Model";
            this.Phone_Model.Size = new System.Drawing.Size(22, 15);
            this.Phone_Model.TabIndex = 29;
            this.Phone_Model.Text = ".....";
            this.Phone_Model.Click += new System.EventHandler(this.Phone_Model_Click);
            // 
            // Phone_Name
            // 
            this.Phone_Name.AutoSize = true;
            this.Phone_Name.Location = new System.Drawing.Point(153, 54);
            this.Phone_Name.Name = "Phone_Name";
            this.Phone_Name.Size = new System.Drawing.Size(22, 15);
            this.Phone_Name.TabIndex = 28;
            this.Phone_Name.Text = ".....";
            this.Phone_Name.Click += new System.EventHandler(this.Phone_Name_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Serial # :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 119);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 15);
            this.label22.TabIndex = 26;
            this.label22.Text = "Revision :";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 15);
            this.label21.TabIndex = 25;
            this.label21.Text = "Phone Model :";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 15);
            this.label20.TabIndex = 24;
            this.label20.Text = "Phone Name :";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.Red;
            this.button10.Location = new System.Drawing.Point(211, 337);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(186, 22);
            this.button10.TabIndex = 23;
            this.button10.Text = "Disconnect Phone";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkRed;
            this.label23.Location = new System.Drawing.Point(3, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(266, 26);
            this.label23.TabIndex = 19;
            this.label23.Text = "C O N N E C T I O N - S E T U P";
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = global::Helper.Properties.Resources.Connection_Dead;
            this.pictureBox3.Location = new System.Drawing.Point(300, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 164);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // receive
            // 
            this.receive.Controls.Add(this.tabPage1);
            this.receive.Controls.Add(this.tabPage2);
            this.receive.Controls.Add(this.tabPage4);
            this.receive.Controls.Add(this.tabPage6);
            this.receive.Controls.Add(this.tabPage3);
            this.receive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receive.Location = new System.Drawing.Point(12, 12);
            this.receive.Name = "receive";
            this.receive.SelectedIndex = 0;
            this.receive.Size = new System.Drawing.Size(427, 410);
            this.receive.TabIndex = 0;
            this.receive.Enter += new System.EventHandler(this.Receive_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 428);
            this.Controls.Add(this.receive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S - M - S";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsgrid)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.receive.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.DataGridView smsgrid;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Single_SMS;
        private System.Windows.Forms.TextBox SMS_Text;
        private System.Windows.Forms.TextBox Cell_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Serial_Num;
        private System.Windows.Forms.Label Revision_Num;
        private System.Windows.Forms.Label Phone_Model;
        private System.Windows.Forms.Label Phone_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabControl receive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbMessageSIM;
        private System.Windows.Forms.RadioButton rbMessagePhone;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

