using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using GsmComm.PduConverter;
using GsmComm.GsmCommunication;


namespace SMS
{
	/// <summary>
	/// Summary description for Send.
	/// </summary>
	public class Send : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_destination_numbers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_text_remaining;
		private System.Windows.Forms.Button btnSendMessage;
		private System.Windows.Forms.Button BtnClear;
		private System.Windows.Forms.TextBox txt_message;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.CheckBox chkUnicode;
		private System.Windows.Forms.CheckBox chkAlert;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtSendTimes;
		private System.Windows.Forms.CheckBox chkMultipleTimes;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        		
		private delegate void SetTextCallback(string text);

		public Send()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Send));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_destination_numbers = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_message = new System.Windows.Forms.TextBox();
			this.txt_text_remaining = new System.Windows.Forms.TextBox();
			this.btnSendMessage = new System.Windows.Forms.Button();
			this.BtnClear = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.chkUnicode = new System.Windows.Forms.CheckBox();
			this.chkAlert = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtSendTimes = new System.Windows.Forms.TextBox();
			this.chkMultipleTimes = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(368, 104);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Destination Number :";
			// 
			// txt_destination_numbers
			// 
			this.txt_destination_numbers.Location = new System.Drawing.Point(0, 136);
			this.txt_destination_numbers.Name = "txt_destination_numbers";
			this.txt_destination_numbers.Size = new System.Drawing.Size(224, 20);
			this.txt_destination_numbers.TabIndex = 2;
			this.txt_destination_numbers.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(0, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Message :";
			// 
			// txt_message
			// 
			this.txt_message.Location = new System.Drawing.Point(0, 192);
			this.txt_message.Multiline = true;
			this.txt_message.Name = "txt_message";
			this.txt_message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txt_message.Size = new System.Drawing.Size(224, 112);
			this.txt_message.TabIndex = 4;
			this.txt_message.Text = "";
			this.txt_message.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// txt_text_remaining
			// 
			this.txt_text_remaining.BackColor = System.Drawing.SystemColors.Control;
			this.txt_text_remaining.Enabled = false;
			this.txt_text_remaining.Location = new System.Drawing.Point(224, 288);
			this.txt_text_remaining.Name = "txt_text_remaining";
			this.txt_text_remaining.Size = new System.Drawing.Size(40, 20);
			this.txt_text_remaining.TabIndex = 5;
			this.txt_text_remaining.Text = "160";
			// 
			// btnSendMessage
			// 
			this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSendMessage.Location = new System.Drawing.Point(144, 320);
			this.btnSendMessage.Name = "btnSendMessage";
			this.btnSendMessage.Size = new System.Drawing.Size(80, 24);
			this.btnSendMessage.TabIndex = 16;
			this.btnSendMessage.Text = "Send";
			this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
			// 
			// BtnClear
			// 
			this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.BtnClear.Location = new System.Drawing.Point(56, 320);
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.Size = new System.Drawing.Size(80, 24);
			this.BtnClear.TabIndex = 17;
			this.BtnClear.Text = "Clear";
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(0, 352);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(504, 120);
			this.txtOutput.TabIndex = 56;
			this.txtOutput.Text = "";
			// 
			// chkUnicode
			// 
			this.chkUnicode.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkUnicode.Location = new System.Drawing.Point(16, 56);
			this.chkUnicode.Name = "chkUnicode";
			this.chkUnicode.Size = new System.Drawing.Size(208, 24);
			this.chkUnicode.TabIndex = 58;
			this.chkUnicode.Text = "Send as Unicode (UCS2)";
			// 
			// chkAlert
			// 
			this.chkAlert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAlert.Location = new System.Drawing.Point(16, 24);
			this.chkAlert.Name = "chkAlert";
			this.chkAlert.Size = new System.Drawing.Size(176, 24);
			this.chkAlert.TabIndex = 57;
			this.chkAlert.Text = "Request immediate display (alert)";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkUnicode);
			this.groupBox1.Controls.Add(this.chkAlert);
			this.groupBox1.Controls.Add(this.txtSendTimes);
			this.groupBox1.Controls.Add(this.chkMultipleTimes);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Location = new System.Drawing.Point(240, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 128);
			this.groupBox1.TabIndex = 59;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Option";
			// 
			// txtSendTimes
			// 
			this.txtSendTimes.Location = new System.Drawing.Point(120, 88);
			this.txtSendTimes.Name = "txtSendTimes";
			this.txtSendTimes.Size = new System.Drawing.Size(48, 20);
			this.txtSendTimes.TabIndex = 61;
			this.txtSendTimes.Text = "1";
			// 
			// chkMultipleTimes
			// 
			this.chkMultipleTimes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkMultipleTimes.Location = new System.Drawing.Point(16, 88);
			this.chkMultipleTimes.Name = "chkMultipleTimes";
			this.chkMultipleTimes.TabIndex = 60;
			this.chkMultipleTimes.Text = "Send message";
			// 
			// label19
			// 
			this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label19.Location = new System.Drawing.Point(176, 88);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 23);
			this.label19.TabIndex = 62;
			this.label19.Text = "times";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Send
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 478);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.BtnClear);
			this.Controls.Add(this.btnSendMessage);
			this.Controls.Add(this.txt_text_remaining);
			this.Controls.Add(this.txt_message);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_destination_numbers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Send";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Send SMS";
			this.Load += new System.EventHandler(this.Send_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			int remaining=int.Parse(txt_text_remaining.Text.Trim());
			remaining-=1;
			txt_text_remaining.Text=remaining.ToString();
		}

		private void BtnClear_Click(object sender, System.EventArgs e)
		{
			txt_message.Text="";
			txt_message.Focus();
		}

		private void btnSendMessage_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				// Send an SMS message
				SmsSubmitPdu pdu;
				bool alert = chkAlert.Checked;
				bool unicode = chkUnicode.Checked;
				
				if (!alert && !unicode)
				{
					// The straightforward version
					pdu = new SmsSubmitPdu(txt_message.Text, txt_destination_numbers.Text,"");  // "" indicate SMSC No
				}
				else
				{
					// The extended version with dcs
					byte dcs;
					if (!alert && unicode)
						dcs = DataCodingScheme.NoClass_16Bit;
					else if (alert && !unicode)
						dcs = DataCodingScheme.Class0_7Bit;
					else if (alert && unicode)
						dcs = DataCodingScheme.Class0_16Bit;
					else
						dcs = DataCodingScheme.NoClass_7Bit; // should never occur here

					pdu = new SmsSubmitPdu(txt_message.Text, txt_destination_numbers.Text, "", dcs);
				}

				// Send the same message multiple times if this is set
				int times = chkMultipleTimes.Checked ? int.Parse(txtSendTimes.Text) : 1;

				// Send the message the specified number of times
				for (int i=0;i<times;i++)
				{
					CommSetting.comm.SendMessage(pdu);
					Output("Message {0} of {1} sent.", i+1, times);
					Output("");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Cursor.Current = Cursors.Default;
		}

		

		private void Output(string text)
		{
			if (this.txtOutput.InvokeRequired)
			{
				SetTextCallback stc = new SetTextCallback(Output);
				this.Invoke(stc, new object[] { text });
			}
			else
			{
				txtOutput.AppendText(text);
				txtOutput.AppendText("\r\n");
			}
		}

		private void Send_Load(object sender, System.EventArgs e)
		{
			chkMultipleTimes.Checked=true;		
		}

		private void Output(string text, params object[] args)
		{
			string msg = string.Format(text, args);
			Output(msg);
		}

	}
}
